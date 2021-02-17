namespace IOOP_Assignment
{
    partial class Librarian_PendingRes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResReport = new System.Windows.Forms.Button();
            this.btnPastRes = new System.Windows.Forms.Button();
            this.btnPendingRes = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDashboad = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNav = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPendingRes = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.dgvPendingRes = new System.Windows.Forms.DataGridView();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnResReport);
            this.panel1.Controls.Add(this.btnPastRes);
            this.panel1.Controls.Add(this.btnPendingRes);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnDashboad);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 888);
            this.panel1.TabIndex = 0;
            // 
            // btnResReport
            // 
            this.btnResReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnResReport.FlatAppearance.BorderSize = 0;
            this.btnResReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResReport.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnResReport.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnResReport.Location = new System.Drawing.Point(0, 463);
            this.btnResReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResReport.Name = "btnResReport";
            this.btnResReport.Size = new System.Drawing.Size(279, 77);
            this.btnResReport.TabIndex = 11;
            this.btnResReport.Text = "Reservation Report";
            this.btnResReport.UseVisualStyleBackColor = false;
            this.btnResReport.Click += new System.EventHandler(this.btnResReport_Click_2);
            this.btnResReport.Leave += new System.EventHandler(this.btnResReport_Leave);
            // 
            // btnPastRes
            // 
            this.btnPastRes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnPastRes.FlatAppearance.BorderSize = 0;
            this.btnPastRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPastRes.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPastRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnPastRes.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPastRes.Location = new System.Drawing.Point(0, 390);
            this.btnPastRes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPastRes.Name = "btnPastRes";
            this.btnPastRes.Size = new System.Drawing.Size(279, 77);
            this.btnPastRes.TabIndex = 10;
            this.btnPastRes.Text = "Past Reservations";
            this.btnPastRes.UseVisualStyleBackColor = false;
            this.btnPastRes.Click += new System.EventHandler(this.btnPastRes_Click);
            this.btnPastRes.Leave += new System.EventHandler(this.btnPastRes_Leave);
            // 
            // btnPendingRes
            // 
            this.btnPendingRes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnPendingRes.FlatAppearance.BorderSize = 0;
            this.btnPendingRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingRes.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnPendingRes.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPendingRes.Location = new System.Drawing.Point(0, 313);
            this.btnPendingRes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPendingRes.Name = "btnPendingRes";
            this.btnPendingRes.Size = new System.Drawing.Size(279, 77);
            this.btnPendingRes.TabIndex = 7;
            this.btnPendingRes.Text = "Pending Reservations";
            this.btnPendingRes.UseVisualStyleBackColor = false;
            this.btnPendingRes.Click += new System.EventHandler(this.btnPendingRes_Click);
            this.btnPendingRes.Leave += new System.EventHandler(this.btnPendingRes_Leave);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnUpdate.Location = new System.Drawing.Point(0, 538);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(279, 77);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update Info";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.Leave += new System.EventHandler(this.btnUpdate_Leave);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLogout.Location = new System.Drawing.Point(0, 811);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(279, 77);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.Leave += new System.EventHandler(this.btnLogout_Leave);
            // 
            // btnDashboad
            // 
            this.btnDashboad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnDashboad.FlatAppearance.BorderSize = 0;
            this.btnDashboad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboad.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashboad.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnDashboad.Location = new System.Drawing.Point(0, 237);
            this.btnDashboad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDashboad.Name = "btnDashboad";
            this.btnDashboad.Size = new System.Drawing.Size(279, 77);
            this.btnDashboad.TabIndex = 1;
            this.btnDashboad.Text = "Dashboard";
            this.btnDashboad.UseVisualStyleBackColor = false;
            this.btnDashboad.Click += new System.EventHandler(this.btnDashboad_Click);
            this.btnDashboad.Leave += new System.EventHandler(this.btnDashboad_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 237);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "User position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(78, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IOOP_Assignment.Properties.Resources.User_profile_pic;
            this.pictureBox1.Location = new System.Drawing.Point(90, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 237);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(22, 153);
            this.pnlNav.TabIndex = 1;
            // 
            // lblPendingRes
            // 
            this.lblPendingRes.AutoSize = true;
            this.lblPendingRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblPendingRes.Location = new System.Drawing.Point(318, 34);
            this.lblPendingRes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPendingRes.Name = "lblPendingRes";
            this.lblPendingRes.Size = new System.Drawing.Size(446, 47);
            this.lblPendingRes.TabIndex = 2;
            this.lblPendingRes.Text = "Pending Reservations";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.btnClose.Location = new System.Drawing.Point(1347, 40);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 46);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1022, 49);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(171, 29);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "Date and Time";
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPending.Location = new System.Drawing.Point(321, 106);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(89, 25);
            this.lblPending.TabIndex = 6;
            this.lblPending.Text = "Pending ";
            // 
            // dgvPendingRes
            // 
            this.dgvPendingRes.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvPendingRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingRes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.a,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvPendingRes.Location = new System.Drawing.Point(286, 151);
            this.dgvPendingRes.Name = "dgvPendingRes";
            this.dgvPendingRes.RowHeadersWidth = 62;
            this.dgvPendingRes.RowTemplate.Height = 28;
            this.dgvPendingRes.Size = new System.Drawing.Size(1106, 689);
            this.dgvPendingRes.TabIndex = 8;
            this.dgvPendingRes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendingRes_CellContentClick);
            // 
            // a
            // 
            this.a.HeaderText = "Name";
            this.a.MinimumWidth = 8;
            this.a.Name = "a";
            this.a.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TP number";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Room";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Booked date";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Booked time";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Booking date";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Booking time";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Approve";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 150;
            // 
            // Librarian_PendingRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1552, 888);
            this.Controls.Add(this.dgvPendingRes);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPendingRes);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Librarian_PendingRes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Page_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDashboad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel pnlNav;
        private System.Windows.Forms.Label lblPendingRes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnPendingRes;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.DataGridView dgvPendingRes;
        private System.Windows.Forms.Button btnPastRes;
        private System.Windows.Forms.Button btnResReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
    }
}

