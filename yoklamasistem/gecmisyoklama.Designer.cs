namespace yoklamasistem
{
    partial class gecmisyoklama
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
            pnlFilter = new Panel();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            cmbFilterClass = new ComboBox();
            btnSearch = new Button();
            dgvAttendanceHistory = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colClassName = new DataGridViewTextBoxColumn();
            colAttendanceRate = new DataGridViewTextBoxColumn();
            colTotalAbsence = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAttendanceHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.WhiteSmoke;
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlFilter.Location = new Point(0, 70);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(784, 100);
            pnlFilter.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 11F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(20, 30);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(150, 27);
            dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 11F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(190, 30);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(150, 27);
            dtpEndDate.TabIndex = 2;
            // 
            // cmbFilterClass
            // 
            cmbFilterClass.Font = new Font("Segoe UI", 11F);
            cmbFilterClass.FormattingEnabled = true;
            cmbFilterClass.Location = new Point(370, 30);
            cmbFilterClass.Name = "cmbFilterClass";
            cmbFilterClass.Size = new Size(300, 28);
            cmbFilterClass.TabIndex = 3;
            cmbFilterClass.Text = "Tüm Dersler";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(33, 150, 243);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(676, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 50);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvAttendanceHistory
            // 
            dgvAttendanceHistory.AllowUserToAddRows = false;
            dgvAttendanceHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvAttendanceHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAttendanceHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendanceHistory.Columns.AddRange(new DataGridViewColumn[] { colDate, colClassName, colAttendanceRate, colTotalAbsence });
            dgvAttendanceHistory.GridColor = Color.FromArgb(224, 224, 224);
            dgvAttendanceHistory.Location = new Point(0, 169);
            dgvAttendanceHistory.Name = "dgvAttendanceHistory";
            dgvAttendanceHistory.ReadOnly = true;
            dgvAttendanceHistory.RowHeadersVisible = false;
            dgvAttendanceHistory.ScrollBars = ScrollBars.Vertical;
            dgvAttendanceHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendanceHistory.Size = new Size(784, 393);
            dgvAttendanceHistory.TabIndex = 5;
            dgvAttendanceHistory.CellContentClick += dgvAttendanceHistory_CellContentClick;
            // 
            // colDate
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            colDate.DefaultCellStyle = dataGridViewCellStyle2;
            colDate.HeaderText = "Tarih";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 150;
            // 
            // colClassName
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(13, 71, 161);
            colClassName.DefaultCellStyle = dataGridViewCellStyle3;
            colClassName.HeaderText = "Ders Adı";
            colClassName.Name = "colClassName";
            colClassName.ReadOnly = true;
            colClassName.ToolTipText = "Dersin adını gösterir";
            colClassName.Width = 150;
            // 
            // colAttendanceRate
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(97, 97, 97);
            dataGridViewCellStyle4.Format = "{0}/{1}";
            colAttendanceRate.DefaultCellStyle = dataGridViewCellStyle4;
            colAttendanceRate.HeaderText = "Katılım";
            colAttendanceRate.Name = "colAttendanceRate";
            colAttendanceRate.ReadOnly = true;
            colAttendanceRate.Width = 150;
            // 
            // colTotalAbsence
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(97, 97, 97);
            colTotalAbsence.DefaultCellStyle = dataGridViewCellStyle5;
            colTotalAbsence.HeaderText = "Toplam Devamsız";
            colTotalAbsence.Name = "colTotalAbsence";
            colTotalAbsence.ReadOnly = true;
            colTotalAbsence.Width = 200;
            // 
            // gecmisyoklama
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(dgvAttendanceHistory);
            Controls.Add(btnSearch);
            Controls.Add(cmbFilterClass);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(pnlFilter);
            Name = "gecmisyoklama";
            Text = "Geçmiş Yoklamalar";
            Load += gecmisyoklama_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAttendanceHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilter;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbFilterClass;
        private Button btnSearch;
        private DataGridView dgvAttendanceHistory;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colClassName;
        private DataGridViewTextBoxColumn colAttendanceRate;
        private DataGridViewTextBoxColumn colTotalAbsence;
    }
}