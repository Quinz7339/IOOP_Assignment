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
        string userId;
        string roomId;
        string roomSelected;
        string resDate;
        string resStartTime;
        string resEndTime;

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

        public studentResRoom()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnResRoom.Height;
            pnlNav.Top = btnResRoom.Top;
            pnlNav.Left = btnResRoom.Left;
            btnResRoom.BackColor = Color.FromArgb(46, 51, 73);

            conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\\Library_Reservation_Database.mdf; Integrated Security = True; Connect Timeout = 30");

            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");
            setDateTime();
            setTimeCombo();
            setRoomID();
            cboEndTime.Enabled = false;
            userId = "Usr0001 ";
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

        private void setTimeCombo()
        {
            //display start and end time
            DateTime startTime_Start = DateTime.Parse("08:00AM");
            DateTime startTime_End = DateTime.Parse("08:30PM");

            // available time has 30min interval
            for (DateTime tm = startTime_Start; tm < startTime_End; tm = tm.AddMinutes(30))
            {
                //conn.Open();

                string strSQL = "SELECT * FROM RESERVATION_INFO_T WHERE reserveStartTime = @Tm";

                // create the command object
                cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("@Tm", tm);

                // execute the command and store the result into the data reader
                //dr = cmd.ExecuteReader();

                // check if any record exist in the data reader
                //if (dr.HasRows)
                { // record found

                    cboStartTime.Items.Remove(tm.ToString("HH:mm tt"));
                }
                //else // record not found
                {
                    cboStartTime.Items.Add(tm.ToString("HH:mm tt"));
                }
            }
            // close the connection
            conn.Close();
        }

        private void setRoomID()
        {
            int idNum = 001;

            conn.Open();

            string strSQL = "SELECT * FROM RESERVATION_INFO_T WHERE roomId = @RoomSelected + @IdNum";

            // create the command object
            cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@RoomSelected", roomSelected);
            cmd.Parameters.AddWithValue("@IdNum", idNum.ToString());

            // execute the command and store the result into the data reader
            //dr = cmd.ExecuteReader();

            //// check if any record exist in the data reader
            //if (dr.HasRows)
            //{ // record found
            //    for (int num = idNum; num < 004; num = +1)
            //        continue;
            //}
            //else // record not found
            //{
            //    roomId = idNum.ToString();
            //}

            // close the connection
            conn.Close();
        }

        private void btnAmber_Click(object sender, EventArgs e)
        {
            roomSelected = ("Amber");
            lblRoomSelected.Text = roomSelected;
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            roomSelected = ("BlackThorn");
            lblRoomSelected.Text = roomSelected;
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            roomSelected = ("Cedar");
            lblRoomSelected.Text = roomSelected;
        }

        private void btnDapgne_Click(object sender, EventArgs e)
        {
            roomSelected = ("Daphne");
            lblRoomSelected.Text = roomSelected;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            resDate = dtpResDate.Value.ToString("dd / MMM / yyyy");
            resStartTime = cboStartTime.SelectedItem.ToString();
            resEndTime = cboEndTime.SelectedItem.ToString();

            // clears the listbox before displaying new items
            lstReceipt.Items.Clear();

            lstReceipt.Items.Add("Date: " + DateTime.Now.ToString("dd / MMM / yyyy"));
            lstReceipt.Items.Add("Time: " + DateTime.Now.ToString("hh:mm tt"));
            lstReceipt.Items.Add("\n"); // displays a new empty line

            lstReceipt.Items.Add("Room Booked:\t" + roomSelected);
            lstReceipt.Items.Add("Reserved Date:\t" + resDate);
            lstReceipt.Items.Add("Reserved Start Time:\t" + resStartTime);
            lstReceipt.Items.Add("Reserved End Time:\t" + resEndTime);

            //Submit to databse
            string reserveStatus = "Pending Approve";

            studentResRoomController stuResRoomCtl = new studentResRoomController();

            int i = stuResRoomCtl.addReservation(roomId, DateTime.Now.ToString("dd / MMM / yyyy"), DateTime.Now.ToString("hh:mm tt"), resDate, resStartTime, resEndTime, reserveStatus, userId);
            if (i > 0)
            {
                MessageBox.Show("Record has been successfully added");
            }
            else
            {
                MessageBox.Show("Record faild to add");
            }
        }

        private void cboStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEndTime.Items.Clear();
            cboEndTime.Enabled = true;

            string selectedStartTime = cboStartTime.SelectedItem.ToString();
            //available time has 30min interval
            for (DateTime tm = DateTime.Parse(selectedStartTime).AddHours(1); tm <= DateTime.Parse(selectedStartTime).AddHours(6) && tm <= DateTime.Parse("09:00PM"); tm = tm.AddMinutes(30))
            {
                cboEndTime.Items.Add(tm.ToString("HH:mm tt"));
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            dtpResDate.CustomFormat = " ";
            dtpResDate.Format = DateTimePickerFormat.Custom;
            cboStartTime.ResetText();
            cboEndTime.ResetText();
            lstReceipt.Items.Clear();
        }
    }
}

