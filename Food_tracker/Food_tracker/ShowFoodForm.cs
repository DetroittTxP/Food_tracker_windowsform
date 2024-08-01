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
    public partial class ShowFoodForm : Form
    {
        public ShowFoodForm()
        {
            InitializeComponent();
            LoadFoodData(); 
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        public void LoadFoodData()
        {
            using (SqlConnection conn = new SqlConnection(MainForm.ConnectionString))
            {
                string sql = "SELECT * FROM Foods";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    conn.Close();
                }
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string cals = txtCal.Text;
            string protein = txtProtein.Text;
            string carbs = txtCarbs.Text;
            string fats = txtFats.Text;

            try
            {
                using (SqlConnection con = new SqlConnection(MainForm.ConnectionString))
                {
                    string query = "INSERT INTO Foods (Name, Calories, Protein, Carbs, Fat) VALUES (@Name, @Calories, @Protein, @Carbs, @Fat)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Calories", cals);
                        cmd.Parameters.AddWithValue("@Protein", protein);
                        cmd.Parameters.AddWithValue("@Carbs", carbs);
                        cmd.Parameters.AddWithValue("@Fat", fats);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("INSERT OK");
                        LoadFoodData(); // Refresh data grid view after insertion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ShowFoodForm_Load(object sender, EventArgs e)
        {
            LoadFoodData();
            btnEditFood.Hide();
        }
        public static string foodId = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {

                dataGridView1.Rows[e.RowIndex].Selected = true;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                foodId = row.Cells["FoodId"].Value.ToString();
                btnEditFood.Show();
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            MainForm main = this.MdiParent as MainForm;
            EditFoodForm editf = new EditFoodForm();

            main.CloseForm();

            editf.MdiParent = main;
            editf.WindowState = FormWindowState.Maximized;
            editf.Show();

        }
    }
}
