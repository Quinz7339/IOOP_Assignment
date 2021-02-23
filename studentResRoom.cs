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
using System.Globalization;

namespace IOOP_Assignment
{
    public partial class studentResRoom : Form
    {
        string roomId;
        string roomSelected;
        string selectedRoomPrefix;


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
            fieldsClear();
            dtpResDate.Enabled = false;
            User userInfo = new User();

            lblUserId.Text = userInfo.UserID;
            lblUsername.Text = userInfo.UserFullName;
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
        }

        private void btnModRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnModRes.Height;
            pnlNav.Top = btnModRes.Top;
            pnlNav.Left = btnModRes.Left;
            btnModRes.BackColor = Color.FromArgb(46, 51, 73);

            studentModRes resStatus = new studentModRes();
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
            if (MessageBox.Show("Are you sure you want to logout from the current session?", "Logging Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login_Page login = new Login_Page();
                login.Show();
            }
        }

        private void btnDashboad_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResRoom_Leave(object sender, EventArgs e)
        {
            btnResRoom.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnModRes_Leave(object sender, EventArgs e)
        {
            btnModRes.BackColor = Color.FromArgb(24, 30, 54);
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

        private void fieldsClear()
        {
            cboStartTime.Items.Clear();
            cboEndTime.Items.Clear();
            lstReceipt.Items.Clear();
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void setStartTimeCombo()
        {
            fieldsClear();
            setDateTime();

            //display start and end time
            DateTime startTime_Start = DateTime.Parse("08:00AM");
            DateTime startTime_End = DateTime.Parse("09:00PM");
            
            for (DateTime tm = startTime_Start; tm < startTime_End; tm = tm.AddMinutes(30))
            {
                cboStartTime.Items.Add(tm.ToString("hh:mm tt"));
            }
            
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
            Controllers usableRoomId = new Controllers();

            roomId = usableRoomId.getUsableRoomId(selectedRoomPrefix, dtpResDate.Value.ToString("yyyy-M-dd"), cboStartTime.SelectedItem.ToString(), cboEndTime.SelectedItem.ToString());

            //executes if there are no available roomIds for the given room type
            if (roomId == "")
            {
                MessageBox.Show("Sorry. The selected room is not available during the selected time frame. Please try it with a different time frame or select another room type.","Room selected is not available.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                fieldsClear();
                dtpResDate.Enabled = false;
            }
            //executes if there are available roomId for the given room type
            else
            {
                lblRoomSelected.Text = roomId;
                btnSubmit.Enabled = true;
            }
        }

        private void btnAmber_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "Amber";
            selectedRoomPrefix = "AM";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "BlackThorn";
            selectedRoomPrefix = "BT";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "Cedar";
            selectedRoomPrefix = "CD";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
        }

        private void btnDaphne_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            roomSelected = "Daphne";
            selectedRoomPrefix = "DN";
            lblRoomSelected.Text = roomSelected;
            dtpResDate.Enabled = true;
            cboStartTime.Enabled = true;
            setStartTimeCombo();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // clears the listbox before displaying new items
            lstReceipt.Items.Clear();

            //adding reservation info to the list
            lstReceipt.Items.Add("Date: " + DateTime.Now.ToString("dd / MM / yyyy"));
            lstReceipt.Items.Add("Time: " + DateTime.Now.ToString("hh:mm tt"));
            lstReceipt.Items.Add("\n"); // displays a new empty line
            lstReceipt.Items.Add("Room Booked:\t\t" + roomId);
            lstReceipt.Items.Add("Reserved Date:\t\t" + dtpResDate.Value.ToString());
            lstReceipt.Items.Add("Reserved Start Time:\t" + cboStartTime.SelectedItem.ToString());
            lstReceipt.Items.Add("Reserved End Time:\t" + cboEndTime.SelectedItem.ToString());

 
            Controllers stuResRoomCtl = new Controllers();
            User userInfo = new User();

            //attempts to insert the given reservation info into the database
            int i = stuResRoomCtl.addReservation(roomId, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm tt"), dtpResDate.Value.ToString("yyyy-M-dd"), cboStartTime.SelectedItem.ToString(), cboEndTime.SelectedItem.ToString(), "", userInfo.UserID);
            
            // shows meesage box based on the status of Inserting the reservation info 
            if (i > 0)
            {
                MessageBox.Show("Record has been successfully added","Your reservation has been booked",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Record failed to be added","Your reservation has failed to be booked. Kindly try again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtpResDate.Enabled = false;
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
        }

        //Reset user input data / user inputteed reservation info
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblRoomSelected.Text = "";
            cboStartTime.ResetText();
            cboEndTime.ResetText();
            lstReceipt.Items.Clear();
            dtpResDate.Enabled = false;
            cboStartTime.Enabled = false;
            cboEndTime.Enabled = false;
        }
    }
}

