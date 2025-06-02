namespace yoklamasistem
{
    partial class devamsizlik
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvWarnings = new DataGridView();
            colStudentID = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colAbsenceCount = new DataGridViewTextBoxColumn();
            colWarningAction = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvWarnings).BeginInit();
            SuspendLayout();
            // 
            // dgvWarnings
            // 
            dgvWarnings.AllowUserToAddRows = false;
            dgvWarnings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 248, 225);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dgvWarnings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvWarnings.BackgroundColor = Color.FromArgb(255, 253, 231);
            dgvWarnings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWarnings.Columns.AddRange(new DataGridViewColumn[] { colStudentID, colStudentName, colCourseName, colAbsenceCount, colWarningAction });
            dgvWarnings.GridColor = Color.FromArgb(255, 224, 178);
            dgvWarnings.Location = new Point(0, 70);
            dgvWarnings.Name = "dgvWarnings";
            dgvWarnings.ReadOnly = true;
            dgvWarnings.RowHeadersVisible = false;
            dgvWarnings.ScrollBars = ScrollBars.Vertical;
            dgvWarnings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarnings.Size = new Size(884, 493);
            dgvWarnings.TabIndex = 0;
            // 
            // colStudentID
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 33, 33);
            colStudentID.DefaultCellStyle = dataGridViewCellStyle2;
            colStudentID.Frozen = true;
            colStudentID.HeaderText = "Öğrenci No";
            colStudentID.Name = "colStudentID";
            colStudentID.ReadOnly = true;
            colStudentID.Width = 150;
            // 
            // colStudentName
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(13, 71, 161);
            colStudentName.DefaultCellStyle = dataGridViewCellStyle3;
            colStudentName.HeaderText = "Ad Soyad";
            colStudentName.Name = "colStudentName";
            colStudentName.ReadOnly = true;
            colStudentName.ToolTipText = "Öğrencinin Tam Adı";
            colStudentName.Width = 200;
            // 
            // colCourseName
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(97, 97, 97);
            colCourseName.DefaultCellStyle = dataGridViewCellStyle4;
            colCourseName.HeaderText = "Ders Adı";
            colCourseName.Name = "colCourseName";
            colCourseName.ReadOnly = true;
            colCourseName.Width = 200;
            // 
            // colAbsenceCount
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle5.Format = "{0}/{1}";
            colAbsenceCount.DefaultCellStyle = dataGridViewCellStyle5;
            colAbsenceCount.HeaderText = "Devamsızlık";
            colAbsenceCount.Name = "colAbsenceCount";
            colAbsenceCount.ReadOnly = true;
            colAbsenceCount.Width = 200;
            // 
            // colWarningAction
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 87, 34);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle6.ForeColor = Color.White;
            colWarningAction.DefaultCellStyle = dataGridViewCellStyle6;
            colWarningAction.FlatStyle = FlatStyle.Flat;
            colWarningAction.HeaderText = "İşlem";
            colWarningAction.Name = "colWarningAction";
            colWarningAction.ReadOnly = true;
            colWarningAction.Text = "Uyarı Gönder";
            colWarningAction.ToolTipText = "Öğrenciye devamsızlık uyarısı gönderir";
            colWarningAction.Width = 150;
            // 
            // devamsizlik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dgvWarnings);
            Name = "devamsizlik";
            Text = "Devamsızlık Uyarıları";
            ((System.ComponentModel.ISupportInitialize)dgvWarnings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvWarnings;
        private DataGridViewTextBoxColumn colStudentID;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colAbsenceCount;
        private DataGridViewButtonColumn colWarningAction;
    }
}