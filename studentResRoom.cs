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

namespace IOOP_Assignment
{
    public partial class studentResRoom : Form
    {
        string roomType;
        string date;
        string startTime;
        string endTime;

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

        }

        private void StudentResRoom(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd / MMM / yyyy      hh / mm / tt");
            setDateTime();
            setTimeCombo();
        }

        private void btnDashboad_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);
            studentDashboard dsb = new studentDashboard();
            dsb.ShowDialog();
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

        private void setDateTime()
        {
            //Booking date between 2 days to 32 days after today
            dtpResDate.MinDate = DateTime.Now.AddDays(2);
            dtpResDate.MaxDate = DateTime.Now.AddDays(32);
        }

        private void setTimeCombo()
        {
            //display start and end time
            DateTime sStart = DateTime.Parse("08:00AM");
            DateTime sEnd = DateTime.Parse("08:30PM");

            // available time has 30min interval
            for (DateTime tm = sStart; tm < sEnd; tm = tm.AddMinutes(30))
                cboStartTime.Items.Add(tm.ToString("08:30PM"));

            //DateTime eStart = DateTime.Parse("8:00AM");
            //DateTime eEnd = DateTime.Parse("8:30PM");
            //for (DateTime tm = eStart; tm < eEnd; tm = tm.AddMinutes(30))
            //    cboEndTime.Items.Add(tm.ToString("HH:mm tt"));



            //comboBox1.Items.Remove("Tokyo");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            date = dtpResDate.Value.ToString("dd / MMM / yyyy");
            startTime = cboStartTime.SelectedItem.ToString();
            endTime = cboStartTime.SelectedItem.ToString();
            // clears the listbox before displaying new items
            lstReceipt.Items.Clear();

            lstReceipt.Items.Add("Date: " + DateTime.Now.ToString("dd / MMM / yyyy"));
            lstReceipt.Items.Add("Time: " + DateTime.Now.ToString("hh / mm / tt"));
            lstReceipt.Items.Add("\n"); // displays a new empty line

            lstReceipt.Items.Add("Room Booked:\t" + roomType);
            lstReceipt.Items.Add("Booked Date:\t" + date);
            lstReceipt.Items.Add("Booked Start Time:\t" + startTime);
            lstReceipt.Items.Add("Booked End Time:\t" + endTime);
        }

        private void btnDapgne_Click(object sender, EventArgs e)
        {
            roomType = ("Daphne");
            lblRoomSelected.Text = roomType;
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            roomType = ("BlackThorn");
            lblRoomSelected.Text = roomType;
        }

        private void btnAmber_Click(object sender, EventArgs e)
        {
            roomType = ("Amber");
            lblRoomSelected.Text = roomType;
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            roomType = ("Cedar");
            lblRoomSelected.Text = roomType;
        }
    }
}

