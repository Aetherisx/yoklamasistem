namespace yoklamasistem
{
    partial class dersatama
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlFiltre = new Panel();
            cmbKullaniciTipi = new ComboBox();
            cmbKullanicilar = new ComboBox();
            btnCıkıs = new Button();
            dgvAtananDersler = new DataGridView();
            coldersid = new DataGridViewTextBoxColumn();
            colDersAdi = new DataGridViewTextBoxColumn();
            colKaldir = new DataGridViewButtonColumn();
            dgvTumDersler = new DataGridView();
            coldersidd = new DataGridViewTextBoxColumn();
            coldersadii = new DataGridViewTextBoxColumn();
            colEkle = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAtananDersler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTumDersler).BeginInit();
            SuspendLayout();
            // 
            // pnlFiltre
            // 
            pnlFiltre.BackColor = Color.WhiteSmoke;
            pnlFiltre.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltre.Dock = DockStyle.Top;
            pnlFiltre.Location = new Point(0, 0);
            pnlFiltre.Name = "pnlFiltre";
            pnlFiltre.Size = new Size(950, 60);
            pnlFiltre.TabIndex = 0;
            pnlFiltre.Paint += pnlFiltre_Paint;
            // 
            // cmbKullaniciTipi
            // 
            cmbKullaniciTipi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKullaniciTipi.FormattingEnabled = true;
            cmbKullaniciTipi.Items.AddRange(new object[] { "Öğretmenler", "Öğrenciler" });
            cmbKullaniciTipi.Location = new Point(10, 20);
            cmbKullaniciTipi.Name = "cmbKullaniciTipi";
            cmbKullaniciTipi.Size = new Size(150, 23);
            cmbKullaniciTipi.TabIndex = 1;
            cmbKullaniciTipi.SelectedIndexChanged += cmbKullaniciTipi_SelectedIndexChanged;
            // 
            // cmbKullanicilar
            // 
            cmbKullanicilar.FormattingEnabled = true;
            cmbKullanicilar.Location = new Point(170, 20);
            cmbKullanicilar.Name = "cmbKullanicilar";
            cmbKullanicilar.Size = new Size(250, 23);
            cmbKullanicilar.TabIndex = 2;
            cmbKullanicilar.SelectedIndexChanged += cmbKullanicilar_SelectedIndexChanged;
            // 
            // btnCıkıs
            // 
            btnCıkıs.BackColor = Color.FromArgb(244, 67, 54);
            btnCıkıs.FlatStyle = FlatStyle.Flat;
            btnCıkıs.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCıkıs.ForeColor = Color.White;
            btnCıkıs.Location = new Point(800, 12);
            btnCıkıs.Name = "btnCıkıs";
            btnCıkıs.Size = new Size(130, 30);
            btnCıkıs.TabIndex = 5;
            btnCıkıs.Text = "Çıkış";
            btnCıkıs.UseVisualStyleBackColor = false;
            btnCıkıs.Click += btnCıkıs_Click;
            // 
            // dgvAtananDersler
            // 
            dgvAtananDersler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAtananDersler.Columns.AddRange(new DataGridViewColumn[] { coldersid, colDersAdi, colKaldir });
            dgvAtananDersler.Dock = DockStyle.Top;
            dgvAtananDersler.Location = new Point(0, 60);
            dgvAtananDersler.Name = "dgvAtananDersler";
            dgvAtananDersler.RowHeadersVisible = false;
            dgvAtananDersler.Size = new Size(950, 300);
            dgvAtananDersler.TabIndex = 6;
            dgvAtananDersler.CellContentClick += dgvAtananDersler_CellContentClick;
            // 
            // coldersid
            // 
            coldersid.HeaderText = "Ders ID";
            coldersid.Name = "coldersid";
            coldersid.Visible = false;
            // 
            // colDersAdi
            // 
            colDersAdi.HeaderText = "Ders Adı";
            colDersAdi.Name = "colDersAdi";
            colDersAdi.Width = 300;
            // 
            // colKaldir
            // 
            colKaldir.HeaderText = "İşlem";
            colKaldir.Name = "colKaldir";
            colKaldir.Text = "Kaldır";
            colKaldir.Width = 200;
            // 
            // dgvTumDersler
            // 
            dgvTumDersler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTumDersler.Columns.AddRange(new DataGridViewColumn[] { coldersidd, coldersadii, colEkle });
            dgvTumDersler.Dock = DockStyle.Fill;
            dgvTumDersler.Location = new Point(0, 360);
            dgvTumDersler.Name = "dgvTumDersler";
            dgvTumDersler.RowHeadersVisible = false;
            dgvTumDersler.Size = new Size(950, 340);
            dgvTumDersler.TabIndex = 7;
            dgvTumDersler.CellContentClick += dgvTumDersler_CellContentClick;
            // 
            // coldersidd
            // 
            coldersidd.HeaderText = "Ders ID";
            coldersidd.Name = "coldersidd";
            coldersidd.Visible = false;
            // 
            // coldersadii
            // 
            coldersadii.HeaderText = "Ders Adı";
            coldersadii.Name = "coldersadii";
            coldersadii.Width = 300;
            // 
            // colEkle
            // 
            colEkle.HeaderText = "İşlem";
            colEkle.Name = "colEkle";
            colEkle.Text = "Ekle";
            colEkle.Width = 200;
            // 
            // dersatama
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvTumDersler);
            Controls.Add(dgvAtananDersler);
            Controls.Add(btnCıkıs);
            Controls.Add(cmbKullanicilar);
            Controls.Add(cmbKullaniciTipi);
            Controls.Add(pnlFiltre);
            Name = "dersatama";
            Size = new Size(950, 700);
            ((System.ComponentModel.ISupportInitialize)dgvAtananDersler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTumDersler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFiltre;
        private ComboBox cmbKullaniciTipi;
        private ComboBox cmbKullanicilar;
        private Button btnCıkıs;
        private DataGridView dgvAtananDersler;
        private DataGridView dgvTumDersler;
        private DataGridViewTextBoxColumn coldersid;
        private DataGridViewTextBoxColumn colDersAdi;
        private DataGridViewButtonColumn colKaldir;
        private DataGridViewTextBoxColumn coldersidd;
        private DataGridViewTextBoxColumn coldersadii;
        private DataGridViewButtonColumn colEkle;
    }
}
