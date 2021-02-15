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


namespace IOOP_Assignment
{
    public partial class Login_Page : Form
    {
        public string usrId;
        string userRole = Controllers.userRole;
        readonly string usr = "Usrxxxx";
        readonly string pw = "8 characters or longer";

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
            txtUsername.Text = usr;
            txtUsername.ForeColor = SystemColors.GrayText;
            txtPassword.Text = pw;
            txtPassword.ForeColor = SystemColors.GrayText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = usr;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtPassword.Text == pw)
            {
                txtPassword.Text = pw;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == usr)
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == pw)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // method to check if any record exist in the Database
            Controllers getUserId = new Controllers();

            if (getUserId.getUserId(txtUsername.Text, txtPassword.Text) == true)
            {
                userRole = Controllers.userRole;
                //opens student's side of program
                if (userRole == "S")
                {
                    studentDashboard dsb = new studentDashboard();
                    dsb.Show();
                }

                //opens librarian's side of program
                else
                {
                    //work in progress....
                    MessageBox.Show("Bruh", "Hi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //login sucess, hides this form 
                this.Hide();
            }
            else 
            {
                //login failed
                MessageBox.Show("Incorrect Username or Password. Please try again.", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
