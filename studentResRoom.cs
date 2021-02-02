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
    public partial class studentResRoom : Form
    {
        string roomType;
        string date;
        double time;

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

        private void Login_Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
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
            this.Close();
        }

        private void setDateTime()
        {
            //Booking date between 2 days to 32 days after today
            dtpResDate.MinDate = DateTime.Now.AddDays(2);
            dtpResDate.MaxDate = DateTime.Now.AddDays(32);
        }

        public static DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            var modTicks = dt.Ticks % d.Ticks;
            var delta = modTicks != 0 ? d.Ticks - modTicks : 0;
            return new DateTime(dt.Ticks + delta, dt.Kind);
        }

        private void setTimeCombo()
        {
            DateTime dt = DateTime.Now;
            var dateTime = new DateTime(dt.Year, dt.Month, dt.Day, 20, 0, 0);         //dt.Date.ToShortDateString() + "20:00";
            var dateTime1 = new DateTime(dt.Year, dt.Month, dt.Day, 8, 0, 0);

            while (dt <= Convert.ToDateTime(dateTime) && dt >= Convert.ToDateTime(dateTime1))
            {
                DateTime dt1 = RoundUp(DateTime.Now,TimeSpan.FromMinutes(15));
                time = cboTime.Items.Add(dt1.ToShortTimeString());
            }
            //    //set current date and time to dt
            //    DateTime dt = DateTime.Now;

            //    for (int i = 1; i <= 30; i += 5)
            //    {
            //        dt = dt.AddMinutes(i);
            //        time = cboTime.Items.Add(dt.ToShortTimeString());
            //    }
        }

    private void btnAmber_Click(object sender, EventArgs e)
        {
            roomType = ("Amber");
            lblRoomSelected.Text = roomType;
        }

        private void btnBlackThorn_Click(object sender, EventArgs e)
        {
            roomType = ("BlackThorn");
            lblRoomSelected.Text = roomType;
        }

        private void btnCedar_Click(object sender, EventArgs e)
        {
            roomType = ("Cedar");
            lblRoomSelected.Text = roomType;
        }

        private void btnDapgne_Click(object sender, EventArgs e)
        {
            roomType = ("Daphne");
            lblRoomSelected.Text = roomType;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            date = dtpResDate.Value.ToShortDateString();
            // clears the listbox before displaying new items
            lstReceipt.Items.Clear();

            lstReceipt.Items.Add("Date: " + DateTime.Now.ToShortDateString());
            lstReceipt.Items.Add("Time: " + DateTime.Now.ToShortTimeString());
            lstReceipt.Items.Add("\n"); // displays a new empty line

            lstReceipt.Items.Add("Room Booked:\t" + roomType);
            lstReceipt.Items.Add("Booked Date:\t" + date);
            lstReceipt.Items.Add("Booked Time:\t" + time);
        }


    }

}
