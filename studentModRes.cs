﻿using System;
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
using System.Globalization;

namespace IOOP_Assignment
{
    public partial class studentModRes : Form
    {
        string modResStatus;
        string roomId;
        string reserveId;
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

        public studentModRes()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnResStatus.Height;
            pnlNav.Top = btnResStatus.Top;
            pnlNav.Left = btnResStatus.Left;
            btnResStatus.BackColor = Color.FromArgb(46, 51, 73);

            lblBefore.Hide();
            lblAfter.Hide();
            pnlBefore.Hide();
            pnlAfter.Hide();
            lblCancel.Hide();
            pnlCancel.Hide();

            btnAmber.Enabled = false;
            btnBlackThorn.Enabled = false;
            btnCedar.Enabled = false;
            btnDaphne.Enabled = false;
            cboResId.Enabled = false;

            lblStatus.Text = "Please select an action below, 'Change Booking' || 'Cancel Booking' ";
        }
        private void studentModRes_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");
        }

        private void loadComboBox()
        {
            Controllers getUsrInfo = new Controllers();

            string ModResStr = "SELECT reserveId FROM RESERVATION_INFO_T WHERE userId = @userId AND reserveStatus IN ('PENDING','APPROVED') AND (reserveDate >= @currentDate AND reserveStartTime > @currentTime)";
            using (SqlConnection ModResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                ModResConn.Open();

                using (SqlCommand ModResCmd = new SqlCommand(ModResStr, ModResConn))
                {
                    string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
                    string currentTime = DateTime.Now.ToString("hh:mm:ss tt");
                    string currentDateTime = currentDate + ' ' + currentTime;
                    ModResCmd.Parameters.AddWithValue("@currentDate", currentDate);
                    ModResCmd.Parameters.AddWithValue("@currentTime", DateTime.ParseExact(currentDateTime, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));
                    ModResCmd.Parameters.AddWithValue("@userId", getUsrInfo.UserID);

                    using (SqlDataReader ModResDr = ModResCmd.ExecuteReader())
                    {
                        while (ModResDr.Read())
                        {
                            cboResId.Items.Add("Reservation ID: " + ModResDr[0].ToString());
                        }
                    }
                }
            }
        }

        private void btnChangeRoom_Click(object sender, EventArgs e)
        {
            modResStatus = "Modify";
            lblStatus.Text = "Please select a reservation ID from the dropdown menu";

            lblBefore.Hide();
            pnlBefore.Hide();

            lblAfter.Hide();
            pnlAfter.Hide();

            lblCancel.Hide();
            pnlCancel.Hide();

            cboResId.Items.Clear();
            cboResId.Enabled = true;

            loadComboBox();
        }
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            modResStatus = "Cancel";
            lblStatus.Text = "Please select a reservation ID from the dropdown menu";

            lblBefore.Hide();
            pnlBefore.Hide();

            lblAfter.Hide();
            pnlAfter.Hide();

            btnAmber.Enabled = false;
            btnBlackThorn.Enabled = false;
            btnCedar.Enabled = false;
            btnDaphne.Enabled = false;

            cboResId.Items.Clear();
            cboResId.Enabled = true;

            loadComboBox();
        }
        private void cboResId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modResStatus == "Modify")
            {
                lblStatus.Text = "Please select a Room Name at the bottom.";

                lblBefore.Show();
                pnlBefore.Show();
                lblAfter.Show();
                pnlAfter.Show();
                displayModData();

                btnAmber.Enabled = true;
                btnBlackThorn.Enabled = true;
                btnCedar.Enabled = true;
                btnDaphne.Enabled = true;

                lblAftResId.Text = lblPrevResId.Text;
                lblAftRoomId.Text = lblPrevRoomId.Text;
                lblAftRoomName.Text = lblPrevRoomName.Text;
                lblAftReserveDate.Text = lblPrevReserveDate.Text;
                lblAftReserveStartTime.Text = lblPrevStartTime.Text;
                lblAftReserveEndTime.Text = lblPrevEndTime.Text;
            }
            else
            {
                lblCancel.Show();
                lblCancel.Text = "Is this the reservation you want to cancel?";
                pnlCancel.Show();
                displayCancelData();
            }

        }

        private void displayModData()
        {
            //instatiate object to use the getUserInfo method from the Controllers class
            Controllers getUsrInfo = new Controllers();

            string checkResStr = "SELECT res.reserveId, res.roomId, ro.roomName, res.reserveDate, res.reserveStartTime, res.reserveEndTime FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND reserveId = @resId";
            using (SqlConnection checkResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                checkResConn.Open();
                using (SqlCommand checkResCmd = new SqlCommand(checkResStr, checkResConn))
                {
                    string[] getResId = cboResId.SelectedItem.ToString().Split(' ');
                    checkResCmd.Parameters.AddWithValue("@userId", getUsrInfo.UserID);
                    checkResCmd.Parameters.AddWithValue("@resId", getResId[2]);

                    using (SqlDataReader checkResDr = checkResCmd.ExecuteReader())
                    {
                        while (checkResDr.Read())
                        {
                            lblPrevResId.Text = checkResDr[0].ToString();
                            lblPrevRoomId.Text = checkResDr[1].ToString();
                            lblPrevRoomName.Text = checkResDr[2].ToString();

                            string[] getResDate = checkResDr[3].ToString().Split(' ');
                            string[] getStartTime = checkResDr[4].ToString().Split(' ');
                            string[] getEndTime = checkResDr[5].ToString().Split(' ');

                            lblPrevReserveDate.Text = getResDate[0];
                            lblPrevStartTime.Text = DateTime.Parse(getStartTime[1] + getStartTime[2]).ToString("hh:mm tt");
                            lblPrevEndTime.Text = DateTime.Parse(getEndTime[1] + getEndTime[2]).ToString("hh:mm tt");
                        }
                    }
                }
            }
        }


        private void displayCancelData()
        {
            Controllers getUsrInfo = new Controllers();

            roomId = lblCancelRoomId.Text;
            string checkResStr = "SELECT res.reserveId, res.roomId, ro.roomName, res.reserveDate, res.reserveStartTime, res.reserveEndTime FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND reserveId = @resId";
            using (SqlConnection checkResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                checkResConn.Open();
                using (SqlCommand checkResCmd = new SqlCommand(checkResStr, checkResConn))
                {
                    string[] getResId = cboResId.SelectedItem.ToString().Split(' ');
                    checkResCmd.Parameters.AddWithValue("@userId", getUsrInfo.UserID);
                    checkResCmd.Parameters.AddWithValue("@resId", getResId[2]);

                    using (SqlDataReader checkResDr = checkResCmd.ExecuteReader())
                    {
                        while (checkResDr.Read())
                        {
                            lblCancelId.Text = checkResDr[0].ToString();
                            lblCancelRoomId.Text = checkResDr[1].ToString();
                            lblCancelRoomName.Text = checkResDr[2].ToString();

                            string[] getResDate = checkResDr[3].ToString().Split(' ');
                            string[] getStartTime = checkResDr[4].ToString().Split(' ');
                            string[] getEndTime = checkResDr[5].ToString().Split(' ');

                            lblCancelReserveDate.Text = getResDate[0];
                            lblCancelStartTime.Text = DateTime.Parse(getStartTime[1] + getStartTime[2]).ToString("hh:mm tt");
                            lblCancelEndTime.Text = DateTime.Parse(getEndTime[1] + getEndTime[2]).ToString("hh:mm tt");
                        }
                    }
                }
            }
        }

        //will only be called after the buttons with the room Names are clicked
        private void checkRoom(string roomPrefix, string roomName, string reserveDate, string reserveStartTime, string reserveEndTime)
        {
            DateTime aReserveDate = DateTime.Parse(reserveDate);
            string bReserveDate = aReserveDate.ToString("yyyy-M-dd");

            Controllers usableRoomId = new Controllers();
            roomId = usableRoomId.getUsableRoomId(roomPrefix, bReserveDate.ToString(), reserveStartTime, reserveEndTime);
            //checkRoom(string roomPrefix, string roomName, string reserveDate, string reserveStartTime, string reserveEndTime)
            if (roomId == "")
            {
                lblAftRoomName.Text = "There is no available room for the selected room type.";
            }
            else
            {
                lblAftRoomId.Text = roomId;
                lblAftRoomName.Text = roomName;
            }
        }

        //method to check whether user has selected the same room type for modifcation
        private int sameRoom()
        {
            if (lblAftRoomName.Text.Trim() == lblPrevRoomName.Text.Trim())
            {
                return 1;
            }
            else if (lblAftRoomName.Text.Trim() != lblPrevRoomName.Text.Trim()) 
            { 
                return 0; 
            }
            else
            {
                return -1;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            int check = sameRoom();
            Controllers ModRes = new Controllers();
            if (modResStatus == null)
            {
                MessageBox.Show("Please select a mode of operation.", "Notifcation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (reserveId == null)
                {
                    MessageBox.Show("No reservation ID was selected.", "Kindly retry and select a reservation ID.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (modResStatus == "Modify")
                    {
                        if (check == 1)
                        {
                            reserveId = lblPrevResId.Text.Trim();
                            if (ModRes.UpdateReserv(roomId.Trim(), reserveId) == 1)
                            {
                                MessageBox.Show("Modification Succesful!", "Your reservation has been modified.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnReset.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Modification Failed!", "Kindly retry.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (check == 0)
                        {
                            MessageBox.Show("Please select a different room.", "Notifcation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnReset.PerformClick();
                        }
                    }
                    else if (modResStatus == "Cancel")
                    {
                        reserveId = lblCancelId.Text;
                        if (ModRes.CancelReserv(roomId.Trim(), reserveId) == 1)
                        {
                            MessageBox.Show("Cancellation Successful!", "Your reservation has been cancelled.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnReset.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Cancellation Failed!", "Kindly retry.");
                            btnReset.PerformClick();
                        }
                    }
                }
            }
        }


        private void btnAmber_Click(object sender, EventArgs e)
        {
            string aftRoomName = "Amber";
            string aftRoomPrefix = "AM";
            lblAftRoomName.Text = aftRoomName;
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            string aftRoomName = "BlackThorn";
            string aftRoomPrefix = "BT";
            lblAftRoomName.Text = aftRoomName;
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            string aftRoomName = "Cedar";
            string aftRoomPrefix = "CD";
            lblAftRoomName.Text = aftRoomName;
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnDaphne_Click(object sender, EventArgs e)
        {
            string aftRoomName = "Daphne";
            string aftRoomPrefix = "DN";
            lblAftRoomName.Text = aftRoomName;
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            studentDashboard dsb = new studentDashboard();
            dsb.Show();
            this.Hide();
        }

        private void btnResRoom_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnResRoom.Height;
            pnlNav.Top = btnResRoom.Top;
            pnlNav.Left = btnResRoom.Left;
            btnResRoom.BackColor = Color.FromArgb(46, 51, 73);
            
            studentResRoom ResRoom = new studentResRoom();
            ResRoom.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);

            studentUpdateInfo uptInfo = new studentUpdateInfo();
            uptInfo.Show();
            this.Hide();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblBefore.Hide();
            pnlBefore.Hide();
            
            lblAfter.Hide();
            pnlAfter.Hide();
            
            lblCancel.Hide();
            pnlCancel.Hide();

            cboResId.Items.Clear();

            modResStatus = null;
            cboResId.Enabled = false;
            lblStatus.Text = "Please select an action below, 'Change Booking' || 'Cancel Booking' ";
        }

        private void btnDashboad_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResRoom_Leave(object sender, EventArgs e)
        {
            btnResRoom.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResStatus_Leave(object sender, EventArgs e)
        {
            btnResStatus.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnUpdate_Leave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnLogout_Leave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(24, 30, 54);
        }
    }

}
