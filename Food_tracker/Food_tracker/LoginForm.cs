using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_tracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public static string loggedInUsername = "";
        public static int LoggedInId = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = RegisterForm.HashPassword(txtLoginPassword.Text);

            try
            {
                using(SqlConnection conn = new SqlConnection(MainForm.ConnectionString))
                {
                    string query = "SELECT UserId,Username,Password FROM Users WHERE Username = @username AND Password = @password";

                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(dt);

                        if(dt.Rows.Count > 0)
                        {
                            
                            MainForm.LoggedInId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                            MainForm.loggedInUsername = username;

                            MainForm main = this.MdiParent as MainForm;

                            main.CloseForm();
                            main.UpdateStatusLabels();
                            main.ShowMenuStrip();
                            main.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPassword.Clear();
                            txtLoginUsername.Clear();
                            txtLoginUsername.Focus();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERROR {ex.Message}");
            }
        }

        private void aRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm main = this.MdiParent as MainForm; 

            if (main != null)
            {
                // Close the login form
                main.CloseForm();

           
                RegisterForm registerForm = new RegisterForm();
                registerForm.MdiParent = main;
                registerForm.WindowState = FormWindowState.Maximized;
                registerForm.Show();
            }
        }
    }
}
