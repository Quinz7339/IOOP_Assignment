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
    public partial class studentResStatus : Form
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

        public studentResStatus()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnResStatus.Height;
            pnlNav.Top = btnResStatus.Top;
            pnlNav.Left = btnResStatus.Left;
            btnResStatus.BackColor = Color.FromArgb(46, 51, 73);
            dgvModRes.Size = new Size(720, 250);
        }


        private void Mod_Res_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy      hh:mm tt");
            string ModResStr = "SELECT res.roomId As [Room Id], ro.roomName AS [Room Name], res.bookingDate As [Booking Date], res.bookingTime As [Booking Time], res.reserveDate AS [Reserve Date], res.reserveStartTime AS [Reserve Start Time], res.reserveEndTime AS [Reserve End Time], res.reserveStatus AS [Status] FROM RESERVATION_INFO_T  res INNER JOIN ROOM_INFO_T ro ON res.roomId = ro.roomId WHERE userId = @userId AND reserveStatus IN ('APPROVED','PENDING')";
            using (SqlConnection ModResConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Library_Reservation_Database.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                ModResConn.Open();

                // SqlDataAdapater to be used to fill in the dataset that serves as the data source of the datagridview
                using (SqlDataAdapter ModResDa = new SqlDataAdapter(ModResStr, ModResConn))
                {
                    ModResDa.SelectCommand.Parameters.AddWithValue("@userId", Controllers.userID); //adds the parametrized value to the select command of the data adapter
                    DataSet ModResDs = new DataSet("RESERVATION_INFO_T");
                    ModResDa.Fill(ModResDs, "RESERVATION_INFO_T");
                    dgvModRes.DataSource = ModResDs.Tables["RESERVATION_INFO_T"];
                }
            }
            // create the datagridview column buttons
            DataGridViewButtonColumn btnModify = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn();

            // setting for the Modify button in the datagridview
            btnModify.HeaderText = "MODIFY";
            btnModify.Text = "Modify";
            btnModify.UseColumnTextForButtonValue = true;

            //setting for the Cancel button in the datagridview
            btnCancel.HeaderText = "CANCEL";
            btnCancel.Text = "Cancel";
            btnCancel.UseColumnTextForButtonValue = true;

            // add the datagridview column buttons
            dgvModRes.Columns.Add(btnModify);
            dgvModRes.Columns.Add(btnCancel);
            dgvModRes.Columns[0].Width = 60;
            dgvModRes.Columns[1].Width = 80;
            dgvModRes.Columns[2].Width = 70;
            dgvModRes.Columns[3].Width = 60;
            dgvModRes.Columns[4].Width = 70;
            dgvModRes.Columns[5].Width = 60;
            dgvModRes.Columns[6].Width = 60;
            dgvModRes.Columns[7].Width = 60;
            dgvModRes.Columns[8].Width = 50;
            dgvModRes.Columns[9].Width = 50;

            //formating the dates and times format 
            dgvModRes.Columns[2].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvModRes.Columns[3].DefaultCellStyle.Format = "hh:mm tt";
            dgvModRes.Columns[4].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvModRes.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvModRes.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

            for (int i = 0; i < dgvModRes.ColumnCount - 2; i++)
            {
                dgvModRes.Columns[i].ReadOnly = true;
            }
        }
        private void dgvModRes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if modify button is clicked
            if (e.ColumnIndex == 8)
            {
                //get the row value of the cell click event
                //make the 2nd columms of the corresponding to row into a combobox
                //add items into the combobox which is not the original room itself
                //combobox default value is the data from the database

                List<string> roomNames_L = new List<string>() { "Amber", "BlackThorn", "Cedar", "Daphne" };
                string a = dgvModRes.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                dgvModRes.Rows[e.RowIndex].Cells[1].ReadOnly = true;
                DataGridViewComboBoxCell cboRoomNames = new DataGridViewComboBoxCell();
                foreach(string items in roomNames_L)
                {
                    cboRoomNames.Items.Add(items.ToString().Trim());
                }
                var btnMod = (DataGridViewButtonCell)dgvModRes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                btnMod.Value = "Revert";

                //dgvModRes[e.ColumnIndex, e.RowIndex].Value= "Revert";
                dgvModRes[1 , e.RowIndex] = cboRoomNames;
                cboRoomNames.Value = cboRoomNames.Items[0];
                dgvModRes.Rows[e.RowIndex].Cells[1].ReadOnly = false;

            }
            //if cancel is clicked
            if (e.ColumnIndex == 9)
            {
                //userId = dgvPending.Rows[e.RowIndex].Cells[0].Value.ToString();
                //reserveId = dgvPending.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
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
            
            studentResRoom ResRoom = new studentResRoom();
            ResRoom.Show();
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
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
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


    }

}
