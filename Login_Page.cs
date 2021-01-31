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
            //commands for USER_PASSWORD_T for authentication purposes
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=C:\\Users\\phili\\source\\repos\\IOOP_Assignment\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PASSWORD_T WHERE userId = @usrId AND pwd= @pwd");
            conn.Open();

            //concentate TextBox values to SQL string
            cmd.Parameters.AddWithValue("@usrId", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);

            //establish cmd connection
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();

            //commands for USER_INFO_T for display purposes

            // check if any record exist in the data reader
            if (dr.HasRows)
            { // log in success

                dr.Read(); // read the data
                
                //full_name = dr["fullname"].tostring();
                //messagebox.show("welcome " + full_name + ". you have logged in successfully", "login success", messageboxbuttons.ok, messageboxicon.information);
                //studentdashboard dsb = new dashboard();
                //dsb.fullname = fullname;
                //dsb.show();
                MessageBox.Show("Hi", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();

            }
            else // login fail
            {
                MessageBox.Show("Incorrect Username or Password OR you do not have the authority to access the system", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // close the connection
            conn.Close();
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
