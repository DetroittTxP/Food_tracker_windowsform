using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_tracker
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }


        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text;
            string hashpassword = HashPassword(txtRegispassword.Text);


            try
            {
                using (SqlConnection conn = new SqlConnection(MainForm.ConnectionString))
                {
                    string query = "INSERT INTO Users (Username,Password) VALUES (@username,@password) ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashpassword);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Register Success", "ok", MessageBoxButtons.OK);

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERROR : {ex.Message}", "ok", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
               LoginForm loginForm = new LoginForm();
                MainForm main = this.MdiParent as MainForm;

                if(main != null)
                {
                    main.CloseForm();

                    loginForm.MdiParent = main;
                    loginForm.WindowState = FormWindowState.Maximized;
                    loginForm.Show();
                }


            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
