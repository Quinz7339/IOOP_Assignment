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
            cboResId.Enabled = false;
            lblBefore.Hide();
            lblAfter.Hide();
            pnlBefore.Hide();
            pnlAfter.Hide();
            lblStatus.Text = "Please select an action below";
        }

        private void btnChangeRoom_Click(object sender, EventArgs e)
        {
            modResStatus = "Modify";
            lblStatus.Text = "Please select a reservation ID from the dropdown menu";
            pnlBefore.Hide();
            pnlAfter.Hide();
            cboResId.Items.Clear();
            cboResId.Enabled = true;
            string ModResStr = "SELECT reserveId FROM RESERVATION_INFO_T WHERE userId = @userId AND reserveStatus IN ('PENDING','APPROVED')";
            using (SqlConnection ModResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                ModResConn.Open();

                using (SqlCommand ModResCmd = new SqlCommand(ModResStr, ModResConn))
                {
                    ModResCmd.Parameters.AddWithValue("@userId", Controllers.userID);
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

        private void cboResId_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Please select a Room Name at the bottom.";
            lblBefore.Show();
            pnlBefore.Show();
            lblAfter.Show();
            pnlAfter.Show();
            string checkResStr = "SELECT res.reserveId, res.roomId, ro.roomName, res.reserveDate, res.reserveStartTime, res.reserveEndTime FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND reserveId = @resId";
            using (SqlConnection checkResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                checkResConn.Open();
                using (SqlCommand checkResCmd = new SqlCommand(checkResStr, checkResConn))
                {
                    string[] getResId = cboResId.SelectedItem.ToString().Split(' ');
                    checkResCmd.Parameters.AddWithValue("@userId", Controllers.userID);
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
                            lblPrevStartTime.Text = getStartTime[1] + getStartTime[2];
                            lblPrevEndTime.Text = getEndTime[1] + getEndTime[2];
                        }
                    }
                }
            }
            lblAftResId.Text = lblPrevResId.Text;
            lblAftRoomId.Text = lblPrevRoomId.Text;
            lblAftRoomName.Text = lblPrevRoomName.Text;
            lblAftReserveDate.Text = lblPrevReserveDate.Text;
            lblAftReserveStartTime.Text = lblPrevStartTime.Text;
            lblAftReserveEndTime.Text = lblPrevEndTime.Text;

        }
        private void checkRoom(string roomPrefix, string roomName, string reserveDate, string reserveStartTime, string reserveEndTime)
        {
            List<string> roomIds = new List<string>();
            using (SqlConnection getRoomIdConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                getRoomIdConn.Open();
                string getRoomIdStr = "Select roomId FROM ROOM_INFO_T WHERE roomName = @roomName";
                using (SqlCommand getRoomIdCmd = new SqlCommand(getRoomIdStr, getRoomIdConn))
                {
                    getRoomIdCmd.Parameters.AddWithValue("@roomName", roomName);

                    using (SqlDataReader getRoomIdReader = getRoomIdCmd.ExecuteReader())
                    {
                        while (getRoomIdReader.Read())
                        {
                            roomIds.Add(getRoomIdReader[0].ToString());
                        }
                    }
                }
            }

            using (SqlConnection checkRoomConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                checkRoomConn.Open();
                string checkRoomStr = "SELECT roomId, reserveStartTime, reserveEndTime, reserveDate FROM RESERVATION_INFO_T WHERE roomId LIKE @roomPrefix AND reserveDate = @reserveDate AND (reserveStatus = 'PENDING' OR reserveStatus = 'APPROVED')";
                using (SqlCommand checkRoomCmd = new SqlCommand(checkRoomStr, checkRoomConn))
                {
                    checkRoomCmd.Parameters.AddWithValue("@roomPrefix",roomPrefix + "%");
                    DateTime getReserveDate = DateTime.Parse(reserveDate);
                    checkRoomCmd.Parameters.AddWithValue("@reserveDate", getReserveDate);
                    
                    using (SqlDataReader checkRoomReader = checkRoomCmd.ExecuteReader())
                    {
                        while (checkRoomReader.Read())
                        {
                            //parsing the chosen record starttime and endtime into datetime format
                            DateTime selectedStartTime = DateTime.Parse(reserveStartTime);
                            DateTime selectedEndTime = DateTime.Parse(reserveEndTime);

                            //parsing the datetime value of each reservations' start time and end time into datetime format
                            DateTime recordStartTime = DateTime.Parse(checkRoomReader[1].ToString());
                            DateTime recordEndTime = DateTime.Parse(checkRoomReader[2].ToString());

                            //if either of this is true, where the user selected time intesects with any records' time, code blocks below is executed
                            if ((DateTime.Compare(selectedStartTime, recordStartTime) >= 0 && DateTime.Compare(selectedStartTime, recordEndTime) <= 0) || // Check if user selected start time is both (later than a record's start time ) AND (earlier than a record's end time)
                                (DateTime.Compare(selectedEndTime, recordStartTime) >= 0 && DateTime.Compare(selectedEndTime, recordEndTime) <= 0) || // Check if user selected endtime is both (earlier than a record's start time ) AND (laterthan a record's end time)
                                (DateTime.Compare(selectedStartTime, recordStartTime) <= 0 && DateTime.Compare(selectedEndTime, recordEndTime) >= 0)) // Check if user's (selected start time is earlier than a record's start time ) AND (selected end time later than a record's end time)
                            {
                                for (int i = 0; i < roomIds.Count; i++)
                                {
                                    if (roomIds[i] == checkRoomReader[0].ToString())
                                    {
                                        roomIds.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (roomIds.Count == 0)
            {
                lblAftRoomName.Text = "There is no available room";
            }
            else
            {
                roomId = roomIds[0];
                lblAftRoomId.Text = roomId;
                lblAftRoomName.Text = roomName;
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            reserveId = lblPrevResId.Text;
            if (modResStatus == "Modify")
            {
                string updateResStr = "UPDATE RESERVATION_INFO_T SET roomId = @roomId, bookingDate = @date, bookingTime = @modTime, reserveStatus = 'PENDING'  WHERE reserveId = @reserveId";
                using (SqlConnection updateResConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
                {
                    updateResConn.Open();
                    using (SqlCommand updateResCmd = new SqlCommand(updateResStr, updateResConn))
                    {
                        updateResCmd.Parameters.AddWithValue("@roomId", roomId);
                        updateResCmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/M/yyyy"));
                        updateResCmd.Parameters.AddWithValue("@modTime", DateTime.Now.ToString("hh:mm tt"));
                        updateResCmd.Parameters.AddWithValue("@reserveId",reserveId );

                        updateResCmd.ExecuteNonQuery();
                    }
                }
            }
            if (modResStatus == "Cancel")
            {
                string cancelResStr = "UPDATE RESERVATION_INFO_T SET roomId = @roomId, bookingDate = @date, bookingTime = @modTime, reserveStatus = 'CANCELLED'  WHERE reserveId = @reserveId";
                using (SqlConnection cancelResConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
                {
                    cancelResConn.Open();
                    using (SqlCommand cancelResCmd = new SqlCommand(cancelResStr, cancelResConn))
                    {
                        cancelResCmd.Parameters.AddWithValue("@roomId", roomId);
                        cancelResCmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/M/yyyy"));
                        cancelResCmd.Parameters.AddWithValue("@modTime", DateTime.Now.ToString("hh:mm tt"));
                        cancelResCmd.Parameters.AddWithValue("@reserveId", reserveId);

                        cancelResCmd.ExecuteNonQuery();
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

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            modResStatus = "Cancel";
        }
    }

}
