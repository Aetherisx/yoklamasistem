namespace yoklamasistem
{
    partial class yoklamaal
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            panel1 = new Panel();
            cmbDersler = new ComboBox();
            dtpYoklamaTarihi = new DateTimePicker();
            dgvStudents = new DataGridView();
            ogrencino = new DataGridViewTextBoxColumn();
            adsoyad = new DataGridViewTextBoxColumn();
            durum = new DataGridViewComboBoxColumn();
            uyari = new DataGridViewTextBoxColumn();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(0, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 100);
            panel1.TabIndex = 0;
            // 
            // cmbDersler
            // 
            cmbDersler.BackColor = Color.White;
            cmbDersler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDersler.Font = new Font("Segoe UI", 11F);
            cmbDersler.FormattingEnabled = true;
            cmbDersler.Location = new Point(20, 30);
            cmbDersler.Name = "cmbDersler";
            cmbDersler.Size = new Size(400, 28);
            cmbDersler.TabIndex = 1;
            cmbDersler.SelectedIndexChanged += cmbDersler_SelectedIndexChanged;
            // 
            // dtpYoklamaTarihi
            // 
            dtpYoklamaTarihi.Font = new Font("Segoe UI", 11F);
            dtpYoklamaTarihi.Format = DateTimePickerFormat.Short;
            dtpYoklamaTarihi.Location = new Point(450, 30);
            dtpYoklamaTarihi.Name = "dtpYoklamaTarihi";
            dtpYoklamaTarihi.Size = new Size(200, 27);
            dtpYoklamaTarihi.TabIndex = 2;
            dtpYoklamaTarihi.ValueChanged += dtpYoklamaTarihi_ValueChanged;
            // 
            // dgvStudents
            // 
            dataGridViewCellStyle7.BackColor = Color.FromArgb(250, 250, 250);
            dgvStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { ogrencino, adsoyad, durum, uyari });
            dgvStudents.GridColor = Color.FromArgb(224, 224, 224);
            dgvStudents.Location = new Point(0, 180);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(784, 380);
            dgvStudents.TabIndex = 3;
            // 
            // ogrencino
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ogrencino.DefaultCellStyle = dataGridViewCellStyle8;
            ogrencino.HeaderText = "Öğrenci No";
            ogrencino.Name = "ogrencino";
            ogrencino.Width = 150;
            // 
            // adsoyad
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            adsoyad.DefaultCellStyle = dataGridViewCellStyle9;
            adsoyad.HeaderText = "Ad Soyad";
            adsoyad.Name = "adsoyad";
            adsoyad.Width = 150;
            // 
            // durum
            // 
            durum.HeaderText = "Durum";
            durum.Items.AddRange(new object[] { "Geldi", "Gelmedi" });
            durum.Name = "durum";
            durum.Width = 150;
            // 
            // uyari
            // 
            uyari.HeaderText = "Uyarı Durumu";
            uyari.Name = "uyari";
            uyari.Width = 300;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(660, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            btnSave.MouseHover += btnSave_MouseHover;
            // 
            // yoklamaal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnSave);
            Controls.Add(dgvStudents);
            Controls.Add(dtpYoklamaTarihi);
            Controls.Add(cmbDersler);
            Controls.Add(panel1);
            Name = "yoklamaal";
            Text = "Yoklama Alma";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbDersler;
        private DateTimePicker dtpYoklamaTarihi;
        private DataGridView dgvStudents;
        private Button btnSave;
        private DataGridViewTextBoxColumn ogrencino;
        private DataGridViewTextBoxColumn adsoyad;
        private DataGridViewComboBoxColumn durum;
        private DataGridViewTextBoxColumn uyari;
    }
}