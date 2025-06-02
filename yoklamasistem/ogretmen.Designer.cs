namespace yoklamasistem
{
    partial class ogretmen
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
            pnlSidebar = new Panel();
            btnHistory = new Button();
            pnlProfile = new Panel();
            lblDate = new Label();
            lblUserName = new Label();
            btnAttendance = new Button();
            pnlContent = new Panel();
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            pnlSidebar.SuspendLayout();
            pnlProfile.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(38, 50, 56);
            pnlSidebar.Controls.Add(btnHistory);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 561);
            pnlSidebar.TabIndex = 0;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.FromArgb(64, 64, 64);
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI", 11F);
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(0, 200);
            btnHistory.Name = "btnHistory";
            btnHistory.Padding = new Padding(20, 0, 0, 0);
            btnHistory.Size = new Size(250, 50);
            btnHistory.TabIndex = 0;
            btnHistory.Text = "Geçmiş Yoklamalar";
            btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // pnlProfile
            // 
            pnlProfile.BackColor = Color.FromArgb(30, 39, 44);
            pnlProfile.Controls.Add(lblDate);
            pnlProfile.Controls.Add(lblUserName);
            pnlProfile.Location = new Point(0, 0);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(250, 150);
            pnlProfile.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.ForeColor = Color.FromArgb(97, 97, 97);
            lblDate.Location = new Point(12, 20);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(162, 19);
            lblDate.TabIndex = 1;
            lblDate.Text = "[Gün, DD MMMM YYYY]";
            lblDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(0, 110);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(90, 21);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "[Ad Soyad]";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAttendance
            // 
            btnAttendance.BackColor = Color.FromArgb(64, 64, 64);
            btnAttendance.FlatStyle = FlatStyle.Flat;
            btnAttendance.Font = new Font("Segoe UI", 11F);
            btnAttendance.ForeColor = Color.White;
            btnAttendance.Location = new Point(0, 150);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Padding = new Padding(20, 0, 0, 0);
            btnAttendance.Size = new Size(250, 50);
            btnAttendance.TabIndex = 2;
            btnAttendance.Text = "Yoklama Al";
            btnAttendance.TextAlign = ContentAlignment.MiddleLeft;
            btnAttendance.UseVisualStyleBackColor = false;
            btnAttendance.Click += btnAttendance_Click;
            btnAttendance.MouseHover += btnAttendance_MouseHover;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(250, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(534, 561);
            pnlContent.TabIndex = 3;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(227, 242, 253);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(494, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblHeaderTitle.ForeColor = Color.FromArgb(13, 71, 161);
            lblHeaderTitle.Location = new Point(135, 35);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(223, 30);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Yoklama Takip Sistemi";
            // 
            // ogretmen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(784, 561);
            Controls.Add(pnlContent);
            Controls.Add(btnAttendance);
            Controls.Add(pnlProfile);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ogretmen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Öğretmen Paneli";
            pnlSidebar.ResumeLayout(false);
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlProfile;
        private Label lblUserName;
        private Button btnAttendance;
        private Button btnHistory;
        private Panel pnlContent;
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblDate;
    }
}