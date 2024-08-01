using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_tracker
{
    public partial class MainForm : Form
    {


        public static string ConnectionString = "Server=DESKTOP-E8F1SPO\\SQLEXPRESS; Database=food_tracker; Trusted_Connection=True; TrustServerCertificate=True";

        public MainForm()
        {
            InitializeComponent();
        }



        public static string loggedInUsername = "";
        public static int LoggedInId = -1;

        private void MainForm_Load(object sender, EventArgs e)
        {
            CloseForm();

            if (LoggedInId == -1 || loggedInUsername == "")
            {

                LoginForm loginForm = new LoginForm();
                loginForm.MdiParent = this;
                loginForm.WindowState = FormWindowState.Maximized;
                loginForm.Show();

                menuStrip1.Hide();
            }

            UpdateStatusLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void UpdateStatusLabels()
        {
            statusUsername.Text = loggedInUsername;
            statususerId.Text = LoggedInId.ToString();
            
        }

        public void ShowMenuStrip()
        {
            menuStrip1.Show();
        }

        public  void CloseForm()
        {
            foreach(Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void foodlistToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CloseForm();
            ShowFoodForm sFood = new ShowFoodForm();

            sFood.MdiParent = this;
            sFood.WindowState = FormWindowState.Maximized;
            sFood.Show();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
