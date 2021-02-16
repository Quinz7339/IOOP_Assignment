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
using System.Diagnostics;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    public partial class studentResRoom : Form
    {
        string userId = Controllers.userID;
        string userName = Controllers.userName;
        string roomId;
        string roomSelected;
        string roomSelectedPrefix;
        string resDate;
        string resStartTime;
        string resEndTime;

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

        public studentResRoom()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnResRoom.Height;
            pnlNav.Top = btnResRoom.Top;
            pnlNav.Left = btnResRoom.Left;
            btnResRoom.BackColor = Color.FromArgb(46, 51, 73);

            lblDateTime.Text = DateTime.Now.ToString("dd MM yyyy      hh:mm tt");
            setDateTime();
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
            lblUserId.Text = userId;
            lblUsername.Text = userName;
        }
         
        private void btnDashboad_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);

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
        }

        private void btnResStatus_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnResStatus.Height;
            pnlNav.Top = btnResStatus.Top;
            pnlNav.Left = btnResStatus.Left;
            btnResStatus.BackColor = Color.FromArgb(46, 51, 73);

            studentResStatus resStatus = new studentResStatus();
            resStatus.Show();
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
            btnDashboad.BackColor = Color.FromArgb(24, 30, 54);
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

        private void setDateTime()
        {
            //Booking date between 2 days to 32 days after today
            dtpResDate.MinDate = DateTime.Now.AddDays(2);
            dtpResDate.MaxDate = DateTime.Now.AddDays(32);
        }

        private void setRoomID(string roomName)
        {
            int idNum = 001;
            using (SqlConnection setRoomIDConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                string setRoomIDStr = "SELECT * FROM RESERVATION_INFO_T WHERE roomId = @RoomSelected + @IdNum";
                setRoomIDConn.Open();

                using (SqlCommand setRoomIDCmd = new SqlCommand(setRoomIDStr, setRoomIDConn))
                {
                    // create the command object
                    setRoomIDCmd.Parameters.AddWithValue("@RoomSelected", roomSelected);
                    setRoomIDCmd.Parameters.AddWithValue("@IdNum", idNum.ToString());

                    // execute the command and store the result into the data reader
                    dr = setRoomIDCmd.ExecuteReader();

                    // check if any record exist in the data reader
                    if (dr.HasRows)
                    { // record found
                        for (int num = idNum; num < 004; num = +1)
                            continue;
                    }
                    else // record not found
                    {
                        roomId = idNum.ToString();
                    }
                }
            }
        }


        private void setStartTimeCombo()
        {
            setDateTime();
            cboStartTime.Items.Clear();
            cboEndTime.Items.Clear();
            lstReceipt.Items.Clear();
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
            //display start and end time
            //DateTime dateToReserve = DateTime.Parse();
            DateTime startTime_Start = DateTime.Parse("08:00AM");
            DateTime startTime_End = DateTime.Parse("09:00PM");
            
            for (DateTime tm = startTime_Start; tm < startTime_End; tm = tm.AddHours(1))
            {
                cboStartTime.Items.Add(tm.ToString("hh:mm tt"));
            }
            
            //using (SqlConnection setTimeComboConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            //{
            //    string setTimeComboStr = "SELECT * FROM RESERVATION_INFO_T WHERE reserveDate = @resDate AND reserveStartTime = @reserveStartTime";
            //    setTimeComboConn.Open();

            //    using (SqlCommand setTimeComboCmd = new SqlCommand(setTimeComboStr, setTimeComboConn))
            //    {
            //        setTimeComboCmd.Parameters.AddWithValue("@resDate", resDate.ToString());
            //        //setTimeComboCmd.Parameters.AddWithValue("@reserveStartTime", tm.ToString("HH:mm tt"));

            //        // execute the command and store the result into the data reader
            //        dr = setTimeComboCmd.ExecuteReader();
            //        // available time has 30min interval
            //        for (DateTime tm = startTime_Start; tm < startTime_End; tm = tm.AddMinutes(30))
            //        {
                        
            //            // check if any record exist in the data reader
            //            if (dr.Read())
            //            {
            //                cboStartTime.Items.Remove(tm.ToString("HH:mm tt"));
            //            }
            //            else // record not found
            //            {
            //                cboStartTime.Items.Add(tm.ToString("HH:mm tt"));
            //            }
            //        }
            //    }
            //}
        }
        private void dtpResDate_ValueChanged(object sender, EventArgs e)
        {
            cboStartTime.Enabled = true;
        }

        //add time based on input on StartTime
        private void cboStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEndTime.Items.Clear();

            string selectedStartTime = cboStartTime.SelectedItem.ToString();
            //available time has 30min interval
            for (DateTime tm = DateTime.Parse(selectedStartTime).AddHours(1); tm <= DateTime.Parse(selectedStartTime).AddHours(6) && tm <= DateTime.Parse("09:00PM"); tm = tm.AddMinutes(30))
            {
                cboEndTime.Items.Add(tm.ToString("hh:mm tt"));
            }
            cboEndTime.Enabled = true;
        }

        private void cboEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make this array automatically filled with the room id from ROOM_INFO_T

            //load roomId into an array
            using (SqlConnection checkRoomConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                checkRoomConn.Open();
                string checkRoomStr = "SELECT roomId, reserveStartTime, reserveEndTime FROM RESERVATION_INFO_T WHERE roomId LIKE @roomPrefix AND reserveDate = @reserveDate AND (reserveStatus = 'PENDING' OR reserveStatus = 'APPROVED')";
                using (SqlCommand checkRoomCmd = new SqlCommand(checkRoomStr, checkRoomConn))
                {
                    checkRoomCmd.Parameters.AddWithValue("@roomPrefix", roomSelectedPrefix + "%");
                    checkRoomCmd.Parameters.AddWithValue("@reserveDate", dtpResDate.Value.ToString("yyyy-M-dd"));

                    using (SqlDataReader checkRoomReader = checkRoomCmd.ExecuteReader())
                    {
                        while (checkRoomReader.Read())
                        {
                            DateTime selectedStartTime = DateTime.Parse(cboStartTime.SelectedItem.ToString());
                            DateTime selectedEndTime = DateTime.Parse(cboStartTime.SelectedItem.ToString());
                            
                            DateTime recordStartTime = DateTime.Parse(checkRoomReader[1].ToString());
                            DateTime recordEndTime = DateTime.Parse(checkRoomReader[2].ToString());
                            

                            //fix this
                            if ((DateTime.Compare(selectedStartTime, recordStartTime) <= 0 && DateTime.Compare(selectedEndTime, recordStartTime)<=0) && 
                                    (DateTime.Compare(selectedStartTime, recordEndTime) >=0 && DateTime.Compare(selectedEndTime, recordEndTime) >= 0)))
                            {
                                roomId = checkRoomReader[0].ToString();
                                MessageBox.Show(roomId, "test", MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                }
            }
            //after the array comparing is done, use the reminaing elements from the roomId(array) to determine which buttons would be enabled
            //depending on the number of times a prefix of given a room exist in the roomId(array), output the number of times it appears in the their respective button

            //remove roomId that exist in the database based on the date and time
            //using (SqlConnection checkRoomConn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            //{
            //    checkRoomConn.Open();

            //    //if there is a reservation on the date AND time, then the room is not viable

            //    //string checkRoomStr = "SELECT reserveDate, reserveStartTime, reserveEndTime, reserveStatus FROM RESERVATION_INFO_T WHERE reserveDate = @reserveDate";
            //    string checkRoomStr = "SELECT roomId, reserveStartTime, reserveEndTime FROM RESERVATION_INFO_T  WHERE reserveDate = @reserveDate AND (reserveStatus = 'PENDING' AND reserveStatus = 'APPROVED')";

            //    //to determine which specific of a given room type is available, output in terms of roomId
            //    using (SqlCommand checkRoomCmd = new SqlCommand(checkRoomStr, checkRoomConn))
            //    {
            //        checkRoomCmd.Parameters.AddWithValue("@reserveDate", dtpResDate.Value.ToString("dd / MMM / yyyy"));
            //        using (SqlDataReader checkRoomReader = checkRoomCmd.ExecuteReader())
            //        {
            //            while (checkRoomReader.Read())
            //            {
            //                //if checkRoomReader's 2nd element is equals to any element in the array (roomId), the same ID would be removed from the roomId array
            //               if (checkRoomReader.[0] = 


            //            }

            //        }
            //    }
            //}



        }

        private void btnAmber_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "Amber";
            roomSelectedPrefix = "AM";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
            //setRoomID(roomSelected);
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "BlackThorn";
            roomSelectedPrefix = "BT";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
            //setRoomID(roomSelected);
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "Cedar";
            roomSelectedPrefix = "CD";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
            //setRoomID(roomSelected); 
        }

        private void btnDaphne_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "Daphne";
            roomSelectedPrefix = "DN";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
            //setRoomID(roomSelected);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //changing user input data to string
            resDate = dtpResDate.Value.ToString("dd/MM/yyyy");
            resStartTime = cboStartTime.SelectedItem.ToString();
            resEndTime = cboEndTime.SelectedItem.ToString();

            // clears the listbox before displaying new items
            lstReceipt.Items.Clear();

            //adding reservation info to the list
            lstReceipt.Items.Add("Date: " + DateTime.Now.ToString("dd / MM / yyyy"));
            lstReceipt.Items.Add("Time: " + DateTime.Now.ToString("hh:mm tt"));
            lstReceipt.Items.Add("\n"); // displays a new empty line
            lstReceipt.Items.Add("Room Booked:\t" + roomSelected);
            lstReceipt.Items.Add("Reserved Date:\t" + resDate);
            lstReceipt.Items.Add("Reserved Start Time:\t" + resStartTime);
            lstReceipt.Items.Add("Reserved End Time:\t" + resEndTime);

            string reserveStatus = "Pending Approve";
            Controllers stuResRoomCtl = new Controllers();

            //attempts to insert the given reservation info into the database
            int i = stuResRoomCtl.addReservation(roomId, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm tt"), resDate, resStartTime, resEndTime, reserveStatus, userId);
            
            // shows meesage box based on the status of Inserting the reservation info 
            if (i > 0)
            {
                MessageBox.Show("Record has been successfully added");
            }
            else
            {
                MessageBox.Show("Record failed to be added");
            }
            dtpResDate.Enabled = false;
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
        }

        //Reset user input data / user inputteed reservation info
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            //dtpResDate.CustomFormat = " ";
            //dtpResDate.Format = DateTimePickerFormat.Custom;
            cboStartTime.ResetText();
            cboEndTime.ResetText();
            lstReceipt.Items.Clear();
            dtpResDate.Enabled = false;
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
        }


    }
}

