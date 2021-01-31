using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    public partial class Login_Page : Form
    {
        public string fullname;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
              int nLeftRect,
              int nTopRect,
              int nRightRect,
              int nBottomRect,
              int nWidthEllipse,
              int nHeightEllipse

          );

        public Login_Page()
        {
            InitializeComponent();
            this.Size = new Size(700, 450);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBLab.mdf;Integrated Security=True;Connect Timeout=30");
            string strSQL = "SELECT * FROM Users WHERE Username='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "'";
            conn.Open();      

            //declare sqlcommand variable and sql data reader
            cmd = new SqlCommand(strSQL, conn);            
            dr = cmd.ExecuteReader();

            // check if any record exist in the data reader
            if (dr.HasRows)
            { // log in success
                dr.Read(); // read the data
                fullname = dr["Fullname"].ToString();
                MessageBox.Show("Welcome " + fullname + ". You have logged in successfully", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentDashboard dsb = new Dashboard();
                dsb.fullname = fullname;
                dsb.Show();

            }
            else // login fail
            {
                MessageBox.Show("Incorrect Username or Password OR you do not have the authority to access the system", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // close the connection
            conn.Close();
            this.Hide();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
