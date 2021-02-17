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

        
        string strPending;
        string reserveId;
        string userId;
        string roomId;
        string bookingDate;
        string bookingTime;
        string reserveDate;
        string reserveStartTime;
        string reserveEndTime;
        string approveOrReject;

        //connect to sql
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");

        SqlDataAdapter daPending;
        DataSet dsPending;
        SqlCommand cmd;

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

        private void dgvLoad()
        {
            dgvPending.Update();
            dgvPending.Refresh();

            strPending = "SELECT userId AS [User ID], reserveId As [Reserve ID], roomId As [Room Id], bookingDate As [Booking Date], bookingTime As [Booking Time], reserveDate AS [Reserve Date], reserveStartTime AS [Reserve Start Time], reserveEndTime AS [Reserve End Time] FROM RESERVATION_INFO_T WHERE reserveStatus = 'PENDING'";

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
            for (int i = 0; i < 3; i++)
            {
                dgvPending.Columns[i].Width = 55;
            }

            for (int i = 3; i < 8; i++)
            {
                dgvPending.Columns[i].Width = 70;
            }

            // format the date and time column to use the date format dd MMM yyyy
            dgvPending.Columns[3].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvPending.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            dgvPending.Columns[5].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvPending.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            dgvPending.Columns[7].DefaultCellStyle.Format = "hh:mm tt";

            conn.Close(); // close the connection

            // create the datagridview column buttons
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();

            // add the datagridview column buttons
            dgvPending.Columns.Add(btn1);
            dgvPending.Columns.Add(btn2);

            // setting for 1st button
            btn1.HeaderText = "APPROVE";
            btn1.Text = "Approve";
            btn1.Name = "btnApprove";
            btn1.UseColumnTextForButtonValue = true;

            // for second button
            btn2.HeaderText = "REJECT";
            btn2.Text = "Reject";
            btn2.Name = "btnReject";
            btn2.UseColumnTextForButtonValue = true;
        }

        private void Pending_Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
            dgvLoad();
        }

        private void dgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                userId = dgvPending.Rows[e.RowIndex].Cells[0].Value.ToString();
                reserveId = dgvPending.Rows[e.RowIndex].Cells[1].Value.ToString();
                roomId = dgvPending.Rows[e.RowIndex].Cells[2].Value.ToString();
                bookingDate = dgvPending.Rows[e.RowIndex].Cells[3].Value.ToString();
                bookingTime = dgvPending.Rows[e.RowIndex].Cells[4].Value.ToString();
                reserveDate = dgvPending.Rows[e.RowIndex].Cells[5].Value.ToString();
                reserveStartTime = dgvPending.Rows[e.RowIndex].Cells[6].Value.ToString();
                reserveEndTime = dgvPending.Rows[e.RowIndex].Cells[7].Value.ToString();
                approveOrReject = "APPROVED";
                MessageBox.Show("Reserve Id of " + reserveId + " is APPROVED");
            }
            if (e.ColumnIndex == 9)
            {
                userId = dgvPending.Rows[e.RowIndex].Cells[0].Value.ToString();
                reserveId = dgvPending.Rows[e.RowIndex].Cells[1].Value.ToString();
                roomId = dgvPending.Rows[e.RowIndex].Cells[2].Value.ToString();
                bookingDate = dgvPending.Rows[e.RowIndex].Cells[3].Value.ToString();
                bookingTime = dgvPending.Rows[e.RowIndex].Cells[4].Value.ToString();
                reserveDate = dgvPending.Rows[e.RowIndex].Cells[5].Value.ToString();
                reserveStartTime = dgvPending.Rows[e.RowIndex].Cells[6].Value.ToString();
                reserveEndTime = dgvPending.Rows[e.RowIndex].Cells[7].Value.ToString();
                approveOrReject = "REJECTED";
                MessageBox.Show("Reserve Id of " + reserveId + " is REJECTED");
            }
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
            btnDashboad.BackColor = Color.FromArgb(24, 30, 54);
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

        private void btnUpdateDgv_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("Update RESERVATION_INFO_T SET reserveStatus=@status WHERE userId=@usrId AND reserveId=@resId AND roomId=@rmId AND bookingDate=@bookDate AND bookingTime=@bookTime AND reserveDate=@resDate AND reserveStartTime=@resStartTime AND reserveEndTime=@resEndTime", conn);
            cmd.Parameters.Add("status", approveOrReject);
            cmd.Parameters.Add("usrid", userId);
            cmd.Parameters.Add("resid", reserveId);
            cmd.Parameters.Add("rmid", roomId);
            cmd.Parameters.Add("bookDate", bookingDate);
            cmd.Parameters.Add("bookTime", bookingTime);
            cmd.Parameters.Add("resDate", reserveDate);
            cmd.Parameters.Add("resStartTime", reserveStartTime);
            cmd.Parameters.Add("resEndTime", reserveEndTime);
            cmd.ExecuteNonQuery();

            dgvPending.Update();
            dgvPending.Refresh();

            conn.Close();
        }
    } 
}

