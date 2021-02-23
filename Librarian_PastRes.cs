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
    public partial class Librarian_PastRes : Form
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

        //connect to sql
        string strApproved;
        string strRejected;
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");

        SqlDataAdapter daApproved; 
        SqlDataAdapter daRejected;
        DataSet dsApproved;
        DataSet dsRejected;

        public Librarian_PastRes()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnPastRes.Height;
            pnlNav.Top = btnPastRes.Top;
            pnlNav.Left = btnPastRes.Left;
            btnPastRes.BackColor = Color.FromArgb(46, 51, 73);
            dgvApproved.Size = new Size (720, 150);
            dgvRejected.Size = new Size(720, 150);
        }

        private void pastRes_Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
            dgvApproved.Update();
            dgvApproved.Refresh();
            dgvRejected.Update();
            dgvRejected.Refresh();

            strApproved = "SELECT userId AS [User ID], reserveId As [Reserve ID], roomId As [Room Id], bookingDate As [Booking Date], bookingTime As [Booking Time], reserveDate AS [Reserve Date], reserveStartTime AS [Reserve Start Time], reserveEndTime AS [Reserve End Time], reserveStatus As [Reserve Status] FROM RESERVATION_INFO_T WHERE reserveStatus = 'APPROVED'";

            strRejected = "SELECT userId AS [User ID], reserveId As [Reserve ID], roomId As [Room Id], bookingDate As [Booking Date], bookingTime As [Booking Time], reserveDate AS [Reserve Date], reserveStartTime AS [Reserve Start Time], reserveEndTime AS [Reserve End Time], reserveStatus As [Reserve Status] FROM RESERVATION_INFO_T WHERE reserveStatus = 'REJECTED'";

            conn.Open();

            daApproved = new SqlDataAdapter(strApproved, conn);
            daRejected = new SqlDataAdapter(strRejected, conn);

            // dataset is a virtual copy of a database
            // a dataset can contain one or more datatables
            dsApproved = new DataSet("RESERVATION_INFO_T");
            dsRejected = new DataSet("RESERVATION_INFO_T");

            // use the data adapter to fill the dataset 
            // with the result of the Select query
            daApproved.Fill(dsApproved, "RESERVATION_INFO_T");
            daRejected.Fill(dsRejected, "RESERVATION_INFO_T");

            // display the result on the datagridview
            dgvApproved.DataSource = dsApproved.Tables["RESERVATION_INFO_T"];
            dgvRejected.DataSource = dsRejected.Tables["RESERVATION_INFO_T"];

            //format the cells' width
            for (int i = 0; i < 3; i++)
            {
                dgvApproved.Columns[i].Width = 60;
            }

            for (int i = 3; i < 8; i++)
            {
                dgvApproved.Columns[i].Width = 80;
            }

            for (int i = 0; i < 3; i++)
            {
                dgvRejected.Columns[i].Width = 60;
            }

            for (int i = 3; i < 8; i++)
            {
                dgvRejected.Columns[i].Width = 80;
            }

            // format the date and time column to use the date format dd MMM yyyy
            dgvApproved.Columns[3].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvApproved.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            dgvApproved.Columns[5].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvApproved.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            dgvApproved.Columns[7].DefaultCellStyle.Format = "hh:mm tt";

            dgvRejected.Columns[3].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvRejected.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            dgvRejected.Columns[5].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvRejected.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            dgvRejected.Columns[7].DefaultCellStyle.Format = "hh:mm tt";

            conn.Close(); // close the connection
        }

        private void btnDashboad_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_Dashboard LibDash = new Librarian_Dashboard();
            LibDash.Show();
            this.Hide();
        }

        private void btnPendingRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPendingRes.Height;
            pnlNav.Top = btnPendingRes.Top;
            pnlNav.Left = btnPendingRes.Left;
            btnPendingRes.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_PendingRes LibPendingRes = new Librarian_PendingRes();
            LibPendingRes.Show();
            this.Hide();
        }

        private void btnPastRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPastRes.Height;
            pnlNav.Top = btnPastRes.Top;
            pnlNav.Left = btnPastRes.Left;
            btnPastRes.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnResReport_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);
            Librarian_Report LibReport = new Librarian_Report();
            LibReport.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
            Librarian_Update LibUpdate = new Librarian_Update();
            LibUpdate.Show();
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
            btnDashboard.BackColor = Color.FromArgb(24, 30,54);
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
    }
}
