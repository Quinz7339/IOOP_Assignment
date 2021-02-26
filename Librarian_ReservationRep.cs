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
    public partial class Librarian_ReservationRep : Form
    {
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

        public Librarian_ReservationRep()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Lib_Res_Report_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");
            dtpMonthlyReport.Format = DateTimePickerFormat.Custom;
            dtpMonthlyReport.CustomFormat = "MMMM/yyyy";
            dtpMonthlyReport.ShowUpDown = true;

            User userInfo = new User();
            lblUsername.Text = userInfo.UserFullName;
            lblUserId.Text = userInfo.UserID;
        }

        private void btnPendingRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPendingRes.Height;
            pnlNav.Top = btnPendingRes.Top;
            pnlNav.Left = btnPendingRes.Left;
            btnPendingRes.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_PendingRes LibPendingRes = new Librarian_PendingRes();
            LibPendingRes.ShowDialog();
            this.Hide();
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

            Librarian_UpdateInfo updtInfo = new Librarian_UpdateInfo();
            updtInfo.Show();
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

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }


        private void btnUpdate_Leave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnLogout_Leave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(24, 30, 54);
        }

      
        private void btnPastRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPastRes.Height;
            pnlNav.Top = btnPastRes.Top;
            pnlNav.Left = btnPastRes.Left;
            btnPastRes.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_PastRes LibPastRes = new Librarian_PastRes();
            LibPastRes.ShowDialog();
            this.Hide();
        }

        private void btnResReport_Click_2(object sender, EventArgs e)
        {
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_Dashboard LibDash = new Librarian_Dashboard();
            LibDash.Show();
            this.Hide();
        }

        private void btnCheckPending_Click(object sender, EventArgs e)
        {
            Librarian_PendingRes LibPendingRes = new Librarian_PendingRes();
            LibPendingRes.ShowDialog();
            this.Hide();
        }

        private void btnCheckPast_Click(object sender, EventArgs e)
        {
            Librarian_PastRes LibPastRes = new Librarian_PastRes();
            LibPastRes.ShowDialog();
            this.Hide();
        }

        private void btnDailyRep_Click(object sender, EventArgs e)
        {
            //save date selected into variable d
            DateTime d = DateTime.Parse(dtpDailyReport.Text);
            
            //define the connection string
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");

            //declare the SQL statement
            SqlCommand command = new SqlCommand($"Select * from RESERVATION_INFO_T where reserveDate = '{d.ToString("yyyy-MM-dd")}'", con);

            //declare data adapter 
            SqlDataAdapter da = new SqlDataAdapter(command);

            //create an instance for the dataset
            dailyRep dsD = new dailyRep();

            //let dataset value be stored in s
            DataSet s = new DataSet();

            //using the data adapter to fill the dataset with the data from RESERVATION_INFO_T table
            da.Fill(s, "RESERVATION_INFO_T");
            
            //create an instance of the report
            dReport rpt = new dReport();

            //set the data source of the report to the dataset
            rpt.SetDataSource(s);

            //tie the crystal report viewer to the report
            crystalReportViewer1.ReportSource = rpt;

        }

        private void btnMonthlyRep_Click(object sender, EventArgs e)
        {
            //save date selected into variable m
            DateTime m = DateTime.Parse(dtpMonthlyReport.Text);

            //declare thisMonth variable
            string thisMonth = m.ToString("yyyy-MM-dd");

            //declare nextMonth variable
            string nextMonth = m.AddMonths(1).ToString("yyyy-MM-dd");

            //declare the SQL statement
            string selectSQL = $"SELECT j.reserveDate, o.roomName, j.roomId, j.userId, j.reserveId, j.reserveStartTime, j.reserveEndTime, j.reserveStatus FROM ROOM_INFO_T o INNER JOIN RESERVATION_INFO_T j ON o.roomId = j.roomId where reserveDate >= '{thisMonth}' and reserveDate < '{nextMonth}'";

            //define the connection string
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");

            //declare SQL command 
            SqlCommand command = new SqlCommand(selectSQL, con);

            //declare data adapter 
            SqlDataAdapter da = new SqlDataAdapter(command);

            //create an instance for the dataset
            monthlyRep dsM = new monthlyRep();

            //let dataset value be stored in s
            DataSet s = new DataSet();

            //using the data adapter to fill the dataset with the data from RESERVATION_ROOM_T datatable
            da.Fill(s, "RESERVATION_ROOM_T");

            //create an instance of the report
            mReport rpt = new mReport();

            //set the data source of the report to the dataset
            rpt.SetDataSource(s);

            //tie the crystal report viewer to the report
            crystalReportViewer1.ReportSource = rpt;
        }

        private void btnPendingRes_Leave(object sender, EventArgs e)
        {
            btnPendingRes.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPastRes_Leave(object sender, EventArgs e)
        {
            btnPastRes.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResReport_Leave(object sender, EventArgs e)
        {
            btnResReport.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
