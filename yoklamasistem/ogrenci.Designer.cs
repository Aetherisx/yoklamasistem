namespace yoklamasistem
{
    partial class ogrenci
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
            pnlHeader = new Panel();
            lblWelcome = new Label();
            lblDate = new Label();
            dgvDevamsizlik = new DataGridView();
            colDersAdi = new DataGridViewTextBoxColumn();
            colDevamsizlik = new DataGridViewTextBoxColumn();
            btnCikis = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDevamsizlik).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(227, 242, 253);
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(984, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.FromArgb(227, 242, 253);
            lblWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblWelcome.ForeColor = Color.FromArgb(13, 71, 161);
            lblWelcome.Location = new Point(20, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(226, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Hoşgeldiniz, [Ad Soyad]";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.BackColor = Color.FromArgb(227, 242, 253);
            lblDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDate.ForeColor = Color.FromArgb(97, 97, 97);
            lblDate.Location = new Point(800, 20);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 17);
            lblDate.TabIndex = 2;
            lblDate.Text = "label1";
            lblDate.Click += lblDate_Click;
            // 
            // dgvDevamsizlik
            // 
            dgvDevamsizlik.BackgroundColor = Color.White;
            dgvDevamsizlik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevamsizlik.Columns.AddRange(new DataGridViewColumn[] { colDersAdi, colDevamsizlik });
            dgvDevamsizlik.Location = new Point(50, 100);
            dgvDevamsizlik.Name = "dgvDevamsizlik";
            dgvDevamsizlik.RowHeadersVisible = false;
            dgvDevamsizlik.Size = new Size(900, 450);
            dgvDevamsizlik.TabIndex = 3;
            // 
            // colDersAdi
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 33, 33);
            colDersAdi.DefaultCellStyle = dataGridViewCellStyle1;
            colDersAdi.HeaderText = "Ders Adı";
            colDersAdi.Name = "colDersAdi";
            colDersAdi.Width = 300;
            // 
            // colDevamsizlik
            // 
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.Format = "{0}/{1}";
            colDevamsizlik.DefaultCellStyle = dataGridViewCellStyle2;
            colDevamsizlik.HeaderText = "Devamsızlık";
            colDevamsizlik.Name = "colDevamsizlik";
            colDevamsizlik.Width = 300;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = Color.FromArgb(244, 67, 54);
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCikis.ForeColor = Color.White;
            btnCikis.Location = new Point(800, 559);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(150, 40);
            btnCikis.TabIndex = 4;
            btnCikis.Text = "ÇIKIŞ";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // ogrenci
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 611);
            Controls.Add(btnCikis);
            Controls.Add(dgvDevamsizlik);
            Controls.Add(lblDate);
            Controls.Add(lblWelcome);
            Controls.Add(pnlHeader);
            Cursor = Cursors.Hand;
            Name = "ogrenci";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Öğrenci Paneli";
            Load += ogrenci_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDevamsizlik).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblDate;
        private DataGridView dgvDevamsizlik;
        private DataGridViewTextBoxColumn colDersAdi;
        private DataGridViewTextBoxColumn colDevamsizlik;
        private Button btnCikis;
    }
}