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

        public Librarian_PastRes()
        {
            InitializeComponent();
            this.Size = new Size(960, 575);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboad.Height;
            pnlNav.Top = btnDashboad.Top;
            pnlNav.Left = btnDashboad.Left;
            btnDashboad.BackColor = Color.FromArgb(46, 51, 73);
            
        }

        private void Login_Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
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

            Librarian_PendingRes LibPendingRes = new Librarian_PendingRes();
            LibPendingRes.Show();
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
            this.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        }

        private void btnResReport_Click_2(object sender, EventArgs e)
        {
            pnlNav.Height = btnResReport.Height;
            pnlNav.Top = btnResReport.Top;
            pnlNav.Left = btnResReport.Left;
            btnResReport.BackColor = Color.FromArgb(46, 51, 73);

            Librarian_ReservationRep LibReservationRep = new Librarian_ReservationRep();
            LibReservationRep.Show();
            this.Hide();
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
    }
}
