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

            lblStatus.Text = "Please select an action below, 'Change Room' || 'Cancel Booking' ";
        }
        private void studentModRes_Load(object sender, EventArgs e)
        {
            User userInfo = new User();

            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");
            lblUsername.Text = userInfo.UserFullName;
            lblUserId.Text = userInfo.UserID;
        }

        private void loadComboBox()
        {
            User userInfo = new User();

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
                    ModResCmd.Parameters.AddWithValue("@userId", userInfo.UserID);

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
            User userInfo = new User();

            string checkResStr = "SELECT res.reserveId, res.roomId, ro.roomName, res.reserveDate, res.reserveStartTime, res.reserveEndTime FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND reserveId = @resId";
            using (SqlConnection checkResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                checkResConn.Open();
                using (SqlCommand checkResCmd = new SqlCommand(checkResStr, checkResConn))
                {
                    string[] getResId = cboResId.SelectedItem.ToString().Split(' ');
                    checkResCmd.Parameters.AddWithValue("@userId", userInfo.UserID);
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
            User userInfo = new User();

            roomId = lblCancelRoomId.Text;
            string checkResStr = "SELECT res.reserveId, res.roomId, ro.roomName, res.reserveDate, res.reserveStartTime, res.reserveEndTime FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND reserveId = @resId";
            using (SqlConnection checkResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                checkResConn.Open();
                using (SqlCommand checkResCmd = new SqlCommand(checkResStr, checkResConn))
                {
                    string[] getResId = cboResId.SelectedItem.ToString().Split(' ');
                    checkResCmd.Parameters.AddWithValue("@userId", userInfo.UserID);
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
        private void sameRoom()
        {
            if (lblAftRoomName.Text.Trim() == lblPrevRoomName.Text.Trim())
            {
                MessageBox.Show("Please select a different room type/name.", "Same room type selected.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReset.PerformClick();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            reserveId = lblPrevResId.Text.Trim();
            Controllers ModRes = new Controllers();
            if (modResStatus == null)
            {
                MessageBox.Show("Please select a mode of operation.", "Notifcation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (reserveId == null)
                {
                    MessageBox.Show("Kindly retry and select a reservation ID.", "No reservation ID was selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (modResStatus == "Modify")
                    {
                        if (reserveId == lblPrevResId.Text.Trim())
                        {
                            MessageBox.Show("Kindly retry and select a room type.", "No room type selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (ModRes.UpdateReserv(roomId.Trim(), reserveId) == 1)
                            {
                                MessageBox.Show("Your reservation has been modified.", "Modification Succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnReset.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Kindly retry.", "Modification Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (modResStatus == "Cancel")
                    {
                        reserveId = lblCancelId.Text.Trim();
                        if (ModRes.CancelReserv(roomId.Trim(), reserveId) == 1)
                        {
                            MessageBox.Show("Your reservation has been cancelled.", "Cancellation Successful!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnReset.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Kindly retry.", "Cancellation Failed!");
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
            sameRoom();
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            string aftRoomName = "BlackThorn";
            string aftRoomPrefix = "BT";
            lblAftRoomName.Text = aftRoomName;
            sameRoom();
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            string aftRoomName = "Cedar";
            string aftRoomPrefix = "CD";
            lblAftRoomName.Text = aftRoomName;
            sameRoom();
            checkRoom(aftRoomPrefix, aftRoomName, lblPrevReserveDate.Text, lblPrevStartTime.Text, lblPrevEndTime.Text);
        }

        private void btnDaphne_Click(object sender, EventArgs e)
        {
            string aftRoomName = "Daphne";
            string aftRoomPrefix = "DN";
            lblAftRoomName.Text = aftRoomName;
            sameRoom();
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
            btnAmber.Enabled = false;
            btnBlackThorn.Enabled = false;
            btnCedar.Enabled = false;
            btnDaphne.Enabled = false;
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
