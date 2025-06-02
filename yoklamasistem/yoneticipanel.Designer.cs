namespace yoklamasistem
{
    partial class yoneticipanel
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
            pnlSideMenu = new Panel();
            button1 = new Button();
            btnKullaniciYonetim = new Button();
            pnlContent = new Panel();
            pnlSideMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSideMenu
            // 
            pnlSideMenu.BackColor = Color.FromArgb(38, 50, 56);
            pnlSideMenu.Controls.Add(button1);
            pnlSideMenu.Controls.Add(btnKullaniciYonetim);
            pnlSideMenu.Dock = DockStyle.Left;
            pnlSideMenu.Location = new Point(0, 0);
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Padding = new Padding(10);
            pnlSideMenu.Size = new Size(250, 749);
            pnlSideMenu.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.White;
            button1.Location = new Point(10, 110);
            button1.Name = "button1";
            button1.Size = new Size(230, 50);
            button1.TabIndex = 1;
            button1.Text = "Ders Atama";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnKullaniciYonetim
            // 
            btnKullaniciYonetim.BackColor = Color.FromArgb(64, 64, 64);
            btnKullaniciYonetim.FlatStyle = FlatStyle.Flat;
            btnKullaniciYonetim.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKullaniciYonetim.ForeColor = Color.White;
            btnKullaniciYonetim.Location = new Point(10, 50);
            btnKullaniciYonetim.Name = "btnKullaniciYonetim";
            btnKullaniciYonetim.Size = new Size(230, 50);
            btnKullaniciYonetim.TabIndex = 0;
            btnKullaniciYonetim.Text = "Kullanıcı Yönetimi";
            btnKullaniciYonetim.TextAlign = ContentAlignment.MiddleLeft;
            btnKullaniciYonetim.UseVisualStyleBackColor = false;
            btnKullaniciYonetim.Click += btnKullaniciYonetim_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(250, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(934, 749);
            pnlContent.TabIndex = 1;
            // 
            // yoneticipanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1184, 749);
            Controls.Add(pnlContent);
            Controls.Add(pnlSideMenu);
            Name = "yoneticipanel";
            Text = "Yönetici Paneli";
            WindowState = FormWindowState.Maximized;
            pnlSideMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSideMenu;
        private Button btnKullaniciYonetim;
        private Button button1;
        private Panel pnlContent;
    }
}