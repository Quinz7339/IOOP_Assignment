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
    public partial class Librarian_UpdateInfo : Form
    {
        readonly string pw = "8 alphanumeric characters or longer";

        SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security = True; Connect Timeout = 30");

        SqlCommand cmdEmail;
        SqlCommand cmdPassword;
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

        public Librarian_UpdateInfo()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);

            User userInfo = new User();
            lblUserName.Text = userInfo.UserFullName;
            lblUserIdL.Text = userInfo.UserID;
        }

        private void Lib_UpdateInfo_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");
            User userInfo = new User();

            txtPassword.Text = pw;
            txtPassword.ForeColor = SystemColors.GrayText;
            txtPassword.UseSystemPasswordChar = false;

            txtConfirmPassword.Text = pw;
            txtConfirmPassword.ForeColor = SystemColors.GrayText;
            txtConfirmPassword.UseSystemPasswordChar = false;

            conn.Open();
            cmdEmail = new SqlCommand("Select full_name, email FROM USER_INFO_T WHERE userId=@userId", conn);
            cmdEmail.Parameters.AddWithValue("@userId", userInfo.UserID);
            SqlDataReader dr = cmdEmail.ExecuteReader();
            while (dr.Read())
            {
                userInfo.Email = dr["email"].ToString();
                txtName.Text = dr["full_name"].ToString();
                txtUserId.Text = userInfo.UserID;
                txtEmail.Text = userInfo.Email;
                txtEmail.ForeColor = SystemColors.GrayText;
            }
            conn.Close();
        }


        private void txtEmail_Enter(object sender, EventArgs e)
        {
            User userInfo = new User();

            if (txtEmail.Text == userInfo.Email)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            User userInfo = new User();

            if (txtEmail.Text == "")
            {
                txtEmail.Text = userInfo.Email;
                txtEmail.ForeColor = SystemColors.GrayText;
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

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtPassword.Text == pw)
            {
                txtPassword.Text = pw;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == pw)
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = Color.Black;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "" || txtConfirmPassword.Text == pw)
            {
                txtConfirmPassword.Text = pw;
                txtConfirmPassword.ForeColor = Color.Gray;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            User userInfo = new User();

            if (txtConfirmPassword.Text == txtPassword.Text)
            {
                conn.Open();

                //if both email and password inputed
                if (txtEmail.Text != userInfo.Email && txtPassword.Text != pw)
                {
                    if (txtPassword.TextLength > 7)
                    {
                        //update email
                        cmdEmail = new SqlCommand("Update USER_INFO_T SET email=@email WHERE userId=@userId", conn);
                        cmdEmail.Parameters.AddWithValue("@userId", userInfo.UserID);
                        cmdEmail.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmdEmail.ExecuteNonQuery();

                        //update password
                        cmdPassword = new SqlCommand("Update USER_PASSWORD_T SET pwd=@password WHERE userId=@userId", conn);
                        cmdPassword.Parameters.AddWithValue("@userId", userInfo.UserID);
                        cmdPassword.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmdPassword.ExecuteNonQuery();

                        MessageBox.Show("User email and password updated !", "Submit Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        //if password inputed less than 8 alphanumeric
                        if (txtPassword.Text != pw && txtPassword.TextLength < 8)
                        {
                            MessageBox.Show("Password must contains at least 8 alphanumeric characters or longer ! Please try again.", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // if only email inputed
                if (txtEmail.Text != userInfo.Email && txtPassword.Text == pw)

                {
                    //update email
                    cmdEmail = new SqlCommand("Update USER_INFO_T SET email=@email WHERE userId=@userId", conn);
                    cmdEmail.Parameters.AddWithValue("@userId", userInfo.UserID);
                    cmdEmail.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdEmail.ExecuteNonQuery();
                    MessageBox.Show("User email updated !", "Submit Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //if only password inputed
                if (txtEmail.Text == userInfo.Email && txtPassword.Text != pw && txtPassword.TextLength > 7)
                {
                    //update password
                    cmdPassword = new SqlCommand("Update USER_PASSWORD_T SET pwd=@password WHERE userId=@userId", conn);
                    cmdPassword.Parameters.AddWithValue("@userId", userInfo.UserID);
                    cmdPassword.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmdPassword.ExecuteNonQuery();
                    MessageBox.Show("User password updated !", "Submit Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //if password inputed less than 8 alphanumeric
                    if (txtPassword.Text != pw && txtPassword.TextLength < 8)
                    {
                        MessageBox.Show("Password must contains at least 8 alphanumeric characters or longer ! Please try again.", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Two password are not match ! Please try again.", "Submit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnReset.PerformClick();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Librarian_UpdateInfo LibUpdate = new Librarian_UpdateInfo();
            LibUpdate.Show();
            this.Hide();
            //User userInfo = new User();
            //txtEmail.Clear();
            //txtEmail.Text = userInfo.Email;
            //txtEmail.ForeColor = SystemColors.GrayText;
            //txtPassword.Clear();
            //txtPassword.Text = pw;
            //txtPassword.ForeColor = Color.Gray;
            //txtPassword.UseSystemPasswordChar = false;
            //txtConfirmPassword.Clear();
            //txtConfirmPassword.Text = pw;
            //txtConfirmPassword.ForeColor = Color.Gray;
            //txtConfirmPassword.UseSystemPasswordChar = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_Dashboard libDash = new Librarian_Dashboard();
            libDash.Show();
            this.Close();

        }
        private void btnPendingRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPendingRes.Height;
            pnlNav.Top = btnPendingRes.Top;
            pnlNav.Left = btnPendingRes.Left;
            btnPendingRes.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_PendingRes libPendingRes = new Librarian_PendingRes();
            libPendingRes.Show();
            this.Close();
        }

        private void btnPastRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPastRes.Height;
            pnlNav.Top = btnPastRes.Top;
            pnlNav.Left = btnPastRes.Left;
            btnPastRes.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_PastRes libPastRes = new Librarian_PastRes();
            libPastRes.Show();
            this.Close();
        }

        private void btnResReport_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnLogout.Height;
            pnlNav.Top = btnLogout.Top;
            pnlNav.Left = btnLogout.Left;
            btnLogout.BackColor = Color.FromArgb(46, 51, 73);

            if (MessageBox.Show("Are you sure you want to logout from the current session?", "Logging Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login_Page login = new Login_Page();
                login.Show();
            }
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPastRes_Leave(object sender, EventArgs e)
        {
            btnPastRes.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResReport_Leave(object sender, EventArgs e)
        {
            btnResReport.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnUpdate_Leave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnLogout_Leave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
