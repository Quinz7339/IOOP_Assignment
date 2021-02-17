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
    public partial class Librarian_PendingRes : Form
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
        string strPending;

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");

        SqlDataAdapter daPending;
        DataSet dsPending;
        SqlCommandBuilder cmdbdl;

        string status;
        int col;
        int row;

        public Librarian_PendingRes()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);
            dgvPending.Size = new Size(720, 392);
        }

        private void Pending_Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();

            strPending = "SELECT userId AS [User ID], reserveId As [Reserve ID], roomId As [Room Id], bookingDate As [Booking Date], bookingTime As [Booking Time], reserveDate AS [Reserve Date], CONCAT(reserveStartTime,'-', reserveEndTime) AS [Reserve Time], reserveStatus As [Reserve Status] FROM RESERVATION_INFO_T WHERE reserveStatus = 'PENDING'";

            conn.Open();

            daPending = new SqlDataAdapter(strPending, conn);


            // dataset is a virtual copy of a database
            // a dataset can contain one or more datatables
            dsPending = new DataSet("RESERVATION_INFO_T");


            // use the data adapter to fill the dataset 
            // with the result of the Select query
            daPending.Fill(dsPending, "RESERVATION_INFO_T");


            // display the result on the datagridview
            dgvPending.DataSource = dsPending.Tables["RESERVATION_INFO_T"];

            //format the cells' width
            for (int i = 0; i < 5; i++)
            {
               dgvPending.Columns[i].Width = 75;
            }
            dgvPending.Columns[6].Width = 120;
            dgvPending.Columns[7].Width = 80;

            // format the date and time column to use the date format dd MMM yyyy
            dgvPending.Columns[3].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvPending.Columns[5].DefaultCellStyle.Format = "dd MMM yyyy";
            //dgvPending.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            //dgvPending.Columns[6].DefaultCellStyle.Format = "hh:mm tt";          

            conn.Close(); // close the connection
        }

        private void dgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            col = e.ColumnIndex;
            row = e.RowIndex;
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPending.Rows[row].Cells[col] = "APPROVED";
                cmdbdl = new SqlCommandBuilder(daPending);
                daPending.Update(dsPending, "RESERVATION_INFO_T");
                MessageBox.Show("Updated", "Room reservation status is" + status, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvPending.Refresh();
        }

        private void btnRejected_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPending.Rows[row].Cells[col].Value = "REJECTED";
                cmdbdl = new SqlCommandBuilder(daPending);
                daPending.Update(dsPending, "RESERVATION_INFO_T");
                MessageBox.Show("Updated", "Room reservation status is" + status, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvPending.Refresh();
            dgvPending.Refresh();
        }
        private void btnDashboad_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);

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
            btnDashboad.BackColor = Color.FromArgb(24, 30,54);
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

        private void btnPastRev_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPastRes.Height;
            pnlNav.Top = btnPastRes.Top;
            pnlNav.Left = btnPastRes.Left;
            btnPastRes.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnResReport_Click_1(object sender, EventArgs e)
        {
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnPastRes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPastRes.Height;
            pnlNav.Top = btnPastRes.Top;
            pnlNav.Left = btnPastRes.Left;
            btnPastRes.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_PastRes LibPastRes = new Librarian_PastRes();
            LibPastRes.Show();
            this.Hide();
        }

        private void btnResReport_Click_2(object sender, EventArgs e)
        {
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);
        }
    }
}
