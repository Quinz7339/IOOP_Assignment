﻿namespace IOOP_Assignment
{
    partial class Librarian_Dashboard
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
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNav = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnCheckPending = new System.Windows.Forms.Button();
            this.btnCheckPast = new System.Windows.Forms.Button();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.btnResReport2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
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
            this.btnResReport.Location = new System.Drawing.Point(0, 301);
            this.btnResReport.Name = "btnResReport";
            this.btnResReport.Size = new System.Drawing.Size(186, 50);
            this.btnResReport.TabIndex = 11;
            this.btnResReport.Text = "Reservation Report";
            this.btnResReport.UseVisualStyleBackColor = false;
            this.btnResReport.Click += new System.EventHandler(this.btnResReport_Click_1);
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
            this.btnPastRes.Location = new System.Drawing.Point(0, 253);
            this.btnPastRes.Name = "btnPastRes";
            this.btnPastRes.Size = new System.Drawing.Size(186, 50);
            this.btnPastRes.TabIndex = 10;
            this.btnPastRes.Text = "Past Reservations";
            this.btnPastRes.UseVisualStyleBackColor = false;
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
            this.btnPendingRes.Location = new System.Drawing.Point(0, 203);
            this.btnPendingRes.Name = "btnPendingRes";
            this.btnPendingRes.Size = new System.Drawing.Size(186, 50);
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
            this.btnUpdate.Location = new System.Drawing.Point(0, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(186, 50);
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
            this.btnLogout.Location = new System.Drawing.Point(0, 527);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(186, 50);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.Leave += new System.EventHandler(this.btnLogout_Leave);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnDashboard.Location = new System.Drawing.Point(0, 154);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(186, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnDashboard.Leave += new System.EventHandler(this.btnDashboard_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 154);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "User position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(52, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IOOP_Assignment.Properties.Resources.User_profile_pic;
            this.pictureBox1.Location = new System.Drawing.Point(60, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 154);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(15, 99);
            this.pnlNav.TabIndex = 1;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblDashboard.Location = new System.Drawing.Point(212, 22);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(156, 31);
            this.lblDashboard.TabIndex = 2;
            this.lblDashboard.Text = "Dashboard";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.btnClose.Location = new System.Drawing.Point(898, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
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
            this.lblDateTime.Location = new System.Drawing.Point(681, 32);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(113, 20);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "Date and Time";
            // 
            // btnCheckPending
            // 
            this.btnCheckPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnCheckPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(151)))), ((int)(((byte)(176)))));
            this.btnCheckPending.Location = new System.Drawing.Point(305, 124);
            this.btnCheckPending.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckPending.Name = "btnCheckPending";
            this.btnCheckPending.Size = new System.Drawing.Size(211, 146);
            this.btnCheckPending.TabIndex = 6;
            this.btnCheckPending.Text = "Check pending reservations?";
            this.btnCheckPending.UseVisualStyleBackColor = false;
            this.btnCheckPending.Click += new System.EventHandler(this.btnCheckPending_Click);
            // 
            // btnCheckPast
            // 
            this.btnCheckPast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnCheckPast.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckPast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(151)))), ((int)(((byte)(176)))));
            this.btnCheckPast.Location = new System.Drawing.Point(627, 124);
            this.btnCheckPast.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckPast.Name = "btnCheckPast";
            this.btnCheckPast.Size = new System.Drawing.Size(211, 146);
            this.btnCheckPast.TabIndex = 7;
            this.btnCheckPast.Text = "Check past reservations?";
            this.btnCheckPast.UseVisualStyleBackColor = false;
            this.btnCheckPast.Click += new System.EventHandler(this.btnCheckPast_Click);
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(151)))), ((int)(((byte)(176)))));
            this.btnUpdateInfo.Location = new System.Drawing.Point(627, 343);
            this.btnUpdateInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(211, 146);
            this.btnUpdateInfo.TabIndex = 8;
            this.btnUpdateInfo.Text = "Update Info?";
            this.btnUpdateInfo.UseVisualStyleBackColor = false;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // btnResReport2
            // 
            this.btnResReport2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnResReport2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResReport2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(151)))), ((int)(((byte)(176)))));
            this.btnResReport2.Location = new System.Drawing.Point(306, 343);
            this.btnResReport2.Margin = new System.Windows.Forms.Padding(2);
            this.btnResReport2.Name = "btnResReport2";
            this.btnResReport2.Size = new System.Drawing.Size(211, 146);
            this.btnResReport2.TabIndex = 9;
            this.btnResReport2.Text = "Print reservation report?";
            this.btnResReport2.UseVisualStyleBackColor = false;
            this.btnResReport2.Click += new System.EventHandler(this.btnResReport_Click_1);
            // 
            // Librarian_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1035, 577);
            this.Controls.Add(this.btnResReport2);
            this.Controls.Add(this.btnUpdateInfo);
            this.Controls.Add(this.btnCheckPast);
            this.Controls.Add(this.btnCheckPending);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Librarian_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Page_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel pnlNav;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnPendingRes;
        private System.Windows.Forms.Button btnPastRes;
        private System.Windows.Forms.Button btnResReport;
        private System.Windows.Forms.Button btnCheckPending;
        private System.Windows.Forms.Button btnCheckPast;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Button btnResReport2;
    }
}
