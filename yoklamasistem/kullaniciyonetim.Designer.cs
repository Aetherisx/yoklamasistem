namespace yoklamasistem
{
    partial class kullaniciyonetim
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            pnlToolBar = new Panel();
            txtArama = new TextBox();
            btnYeni = new Button();
            dataGridView1 = new DataGridView();
            colid = new DataGridViewTextBoxColumn();
            colAd = new DataGridViewTextBoxColumn();
            colSoyad = new DataGridViewTextBoxColumn();
            colKullaniciAdi = new DataGridViewTextBoxColumn();
            colSifre = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewComboBoxColumn();
            colDuzenle = new DataGridViewButtonColumn();
            colSil = new DataGridViewButtonColumn();
            pnlToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlToolBar
            // 
            pnlToolBar.BackColor = Color.WhiteSmoke;
            pnlToolBar.BorderStyle = BorderStyle.FixedSingle;
            pnlToolBar.Controls.Add(txtArama);
            pnlToolBar.Controls.Add(btnYeni);
            pnlToolBar.Dock = DockStyle.Top;
            pnlToolBar.Location = new Point(10, 10);
            pnlToolBar.Name = "pnlToolBar";
            pnlToolBar.Size = new Size(930, 50);
            pnlToolBar.TabIndex = 0;
            // 
            // txtArama
            // 
            txtArama.BorderStyle = BorderStyle.FixedSingle;
            txtArama.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtArama.Location = new Point(675, 11);
            txtArama.Name = "txtArama";
            txtArama.PlaceholderText = "Kullanıcı ara...";
            txtArama.Size = new Size(250, 27);
            txtArama.TabIndex = 1;
            // 
            // btnYeni
            // 
            btnYeni.BackColor = Color.FromArgb(76, 175, 80);
            btnYeni.FlatStyle = FlatStyle.Flat;
            btnYeni.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnYeni.ForeColor = Color.White;
            btnYeni.Location = new Point(3, 7);
            btnYeni.Name = "btnYeni";
            btnYeni.Size = new Size(150, 35);
            btnYeni.TabIndex = 1;
            btnYeni.Text = "Yeni Kullanıcı Ekle";
            btnYeni.UseVisualStyleBackColor = false;
            btnYeni.Click += btnYeni_Click;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colid, colAd, colSoyad, colKullaniciAdi, colSifre, colRol, colDuzenle, colSil });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(10, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(930, 630);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // colid
            // 
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            colid.DefaultCellStyle = dataGridViewCellStyle2;
            colid.HeaderText = "ID";
            colid.Name = "colid";
            colid.Visible = false;
            // 
            // colAd
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            colAd.DefaultCellStyle = dataGridViewCellStyle3;
            colAd.HeaderText = "Ad";
            colAd.Name = "colAd";
            colAd.Width = 150;
            // 
            // colSoyad
            // 
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            colSoyad.DefaultCellStyle = dataGridViewCellStyle4;
            colSoyad.HeaderText = "Soyad";
            colSoyad.Name = "colSoyad";
            colSoyad.Width = 150;
            // 
            // colKullaniciAdi
            // 
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            colKullaniciAdi.DefaultCellStyle = dataGridViewCellStyle5;
            colKullaniciAdi.HeaderText = "Kullanıcı Adı";
            colKullaniciAdi.Name = "colKullaniciAdi";
            colKullaniciAdi.Width = 150;
            // 
            // colSifre
            // 
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            colSifre.DefaultCellStyle = dataGridViewCellStyle6;
            colSifre.HeaderText = "Şifre";
            colSifre.Name = "colSifre";
            colSifre.Width = 150;
            // 
            // colRol
            // 
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            colRol.DefaultCellStyle = dataGridViewCellStyle7;
            colRol.HeaderText = "Rol";
            colRol.Items.AddRange(new object[] { "Öğretmen", "Öğrenci", "Yönetici" });
            colRol.Name = "colRol";
            colRol.Width = 120;
            // 
            // colDuzenle
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            colDuzenle.DefaultCellStyle = dataGridViewCellStyle8;
            colDuzenle.HeaderText = "Düzenle";
            colDuzenle.Name = "colDuzenle";
            colDuzenle.Text = "Düzenle";
            colDuzenle.UseColumnTextForButtonValue = true;
            colDuzenle.Width = 80;
            // 
            // colSil
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            colSil.DefaultCellStyle = dataGridViewCellStyle9;
            colSil.HeaderText = "Sil";
            colSil.Name = "colSil";
            colSil.Resizable = DataGridViewTriState.True;
            colSil.SortMode = DataGridViewColumnSortMode.Automatic;
            colSil.Text = "Sil";
            colSil.Width = 80;
            // 
            // kullaniciyonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(pnlToolBar);
            Name = "kullaniciyonetim";
            Padding = new Padding(10);
            Size = new Size(950, 700);
            pnlToolBar.ResumeLayout(false);
            pnlToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlToolBar;
        private TextBox txtArama;
        private Button btnYeni;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colid;
        private DataGridViewTextBoxColumn colAd;
        private DataGridViewTextBoxColumn colSoyad;
        private DataGridViewTextBoxColumn colKullaniciAdi;
        private DataGridViewTextBoxColumn colSifre;
        private DataGridViewComboBoxColumn colRol;
        private DataGridViewButtonColumn colDuzenle;
        private DataGridViewButtonColumn colSil;
    }
}
