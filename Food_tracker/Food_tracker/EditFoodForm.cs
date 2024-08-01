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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Food_tracker
{
    public partial class EditFoodForm : Form
    {

        string foodId = ShowFoodForm.foodId;
        public EditFoodForm()
        {
            InitializeComponent();
        }

        private void txtEditFoodCal_TextChanged(object sender, EventArgs e)
        {

        }


        private void SwitchForm()
        {
            MainForm main = this.MdiParent as MainForm;
            ShowFoodForm sf = new ShowFoodForm();

            main.CloseForm();

            sf.MdiParent = main;
            sf.WindowState = FormWindowState.Maximized;
            sf.Show();
        }


        private void btnOnEdit_Click(object sender, EventArgs e)
        {
            string id = txtEditFOodid.Text;
            string Cal = txtEditFoodCal.Text;
            string carbs = txtEditFoodCarb.Text;
            string fat = txtEditFoodFat.Text;
            string protein = txtEditFoodPro.Text;
            string name = txtEditFoodName.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(MainForm.ConnectionString))
                {
                    string sql = "UPDATE Foods SET Name = @name , Calories = @cal , Protein = @protein , Carbs = @carbs , Fat = @fat WHERE FoodId = @foodid";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@cal", Cal);
                        cmd.Parameters.AddWithValue("@protein", protein);
                        cmd.Parameters.AddWithValue("@carbs", carbs);
                        cmd.Parameters.AddWithValue("@fat", fat);
                        cmd.Parameters.AddWithValue("@foodid", id);
                        cmd.ExecuteNonQuery(); 
                        conn.Close();

                        MessageBox.Show("Update Success", "ok", MessageBoxButtons.OK);
                      
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
            finally
            {
                SwitchForm();
            }
             
             
        }



        private void EditFoodForm_Load(object sender, EventArgs e)
        {
            txtEditFOodid.Enabled = false;
            lblTest.Text = foodId.ToString();


            using(SqlConnection conn = new SqlConnection(MainForm.ConnectionString))
            {
                string sql = "SELECT * FROM Foods WHERE FoodId = @foodId";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@foodId", foodId.ToString());



                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);



                    conn.Close();

                    if(dt.Rows.Count > 0 )
                    {
                        DataRow row = dt.Rows[0];
                        string foddname = row["Name"].ToString();
                        string cals = row["Calories"].ToString();
                        string pro = row["Protein"].ToString();
                        string carbs = row["Carbs"].ToString();
                        string fat = row["Fat"].ToString();

                        txtEditFOodid.Text = foodId.ToString();
                        txtEditFoodCal.Text = cals;
                        txtEditFoodCarb.Text = carbs;
                        txtEditFoodFat.Text = fat;  
                        txtEditFoodPro.Text = pro;
                        txtEditFoodName.Text = foddname;

                    }
                }
            }


        }
    }
}
