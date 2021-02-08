﻿using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Login_Page : Form
    {
        public string usrId;
        readonly string usr = "Usrxxxx";
        readonly string pw = "8 characters or longer";

        SqlConnection conn;
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
            //commands for USER_PASSWORD_T for authentication purposes
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PASSWORD_T WHERE userId = @usrId AND pwd= @pwd");
            conn.Open();

            //concentate TextBox values to SQL string
            cmd.Parameters.AddWithValue("@usrId", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);

            //establish cmd connection
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();

            // check if any record exist in the data reader
            if (dr.HasRows)
            { // log in success
                Controllers.getUserId(txtUsername.Text);
                this.Hide();
            }
            else // login fail
            {
                MessageBox.Show("Incorrect Username or Password OR you do not have the authority to access the system", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // close the connection
            conn.Close();
        }

    }
}
