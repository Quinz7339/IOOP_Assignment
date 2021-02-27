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
    public partial class studentDashboard : Form
    {
        string strUpCom;
        string strPast;

        //Connect to database
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30");

        SqlDataAdapter daUpCom;
        SqlDataAdapter daPast;
        DataSet dsUpCom;
        DataSet dsPast;

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


        public studentDashboard()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);

            //Get user info to display in the application
            User userInfo = new User();
            lblUsername.Text = userInfo.UserFullName;
            lblUserId.Text = userInfo.UserID;
        }

        private void Student_Dashboard_Load(object sender, EventArgs e)
        {
            User userInfo = new User();

            //Display date and time in the application
            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");

            //Get data from database and display in data grid view
            //Create SQl query to get data from database table
            strUpCom = "SELECT res.reserveId AS 'RESERVATION ID', res.roomId AS 'ROOM ID', ro.roomName AS 'ROOM NAME', res.reserveDate AS 'RESERVATION DATE', res.reserveStartTime AS 'START TIME' , res.reserveEndTime AS 'END TIME', res.reserveStatus AS 'STATUS' FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND reserveStatus IN ('PENDING','APPROVED') AND (reserveDate >= @currentDate AND reserveStartTime > @currentTime) ORDER BY reserveId DESC";

            strPast = "SELECT res.reserveId AS 'RESERVATION ID', res.roomId AS 'ROOM ID', ro.roomName AS 'ROOM NAME', res.reserveDate AS 'RESERVATION DATE', res.reserveStartTime AS 'START TIME', res.reserveEndTime AS 'END TIME', res.reserveStatus 'STATUS' FROM RESERVATION_INFO_T res INNER JOIN ROOM_INFO_T ro ON ro.roomId = res.roomId WHERE userId = @userId AND NOT reserveStatus = 'PENDING' AND (reserveDate < @currentDate AND reserveStartTime < @currentTime) ORDER BY reserveId DESC";

            conn.Open(); // Open connection with database

            string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
            string currentTime = DateTime.Now.ToString("hh:mm:ss tt");
            string currentDateTime = currentDate + ' ' + currentTime;

            //Provide details for searching Upcoming reservation
            SqlCommand upComCmd = new SqlCommand(strUpCom, conn);

            upComCmd.Parameters.AddWithValue("@currentDate", currentDate);
            upComCmd.Parameters.AddWithValue("@currentTime", DateTime.ParseExact(currentDateTime, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));
            upComCmd.Parameters.AddWithValue("@userId", userInfo.UserID);
            upComCmd.ExecuteNonQuery();

            //Provide details for searching Past reservation
            SqlCommand pastCmd = new SqlCommand(strPast, conn);

            pastCmd.Parameters.AddWithValue("@currentDate", currentDate);
            pastCmd.Parameters.AddWithValue("@currentTime", DateTime.ParseExact(currentDateTime, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));
            pastCmd.Parameters.AddWithValue("@userId", userInfo.UserID);
            pastCmd.ExecuteNonQuery();

            //  Connect data set and a data source to retrieve data.
            daUpCom = new SqlDataAdapter(upComCmd);
            daPast = new SqlDataAdapter(pastCmd);

            // dataset is a virtual copy of a database
            // a dataset can contain one or more datatables
            dsUpCom = new DataSet("RESERVATION_INFO_T");
            dsPast = new DataSet("RESERVATION_INFO_T");

            // use the data adapter to fill the dataset 
            // with the result of the Select query
            daUpCom.Fill(dsUpCom, "RESERVATION_INFO_T");
            daPast.Fill(dsPast, "RESERVATION_INFO_T");

            // display the result on the datagridview
            dgvUpCom.DataSource = dsUpCom.Tables["RESERVATION_INFO_T"];
            dgvPast.DataSource = dsPast.Tables["RESERVATION_INFO_T"];

            //format the cells' width
            for (int i = 0; i < 6; i++)
            {
                dgvUpCom.Columns[i].Width = 100;
            }

            for (int i = 0; i < 6; i++)
            {
                dgvPast.Columns[i].Width = 100;
            }

            // format the date and time column to use the date format dd MMM yyyy and time format hh:mm tt

            dgvUpCom.Columns[3].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvUpCom.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            dgvUpCom.Columns[5].DefaultCellStyle.Format = "hh:mm tt";

            dgvPast.Columns[3].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvPast.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            dgvPast.Columns[5].DefaultCellStyle.Format = "hh:mm tt";

            conn.Close(); // close the connection

        }

        private void btnDashboad_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);
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
            if (MessageBox.Show("Are you sure you want to logout from the current session?","Logging Out?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login_Page login = new Login_Page();
                login.Show();
            }
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboad.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResRoom_Leave(object sender, EventArgs e)
        {
            btnResRoom.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnResStatus_Leave(object sender, EventArgs e)
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
    }
}
