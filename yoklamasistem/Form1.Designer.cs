namespace yoklamasistem
{
    partial class giris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblError = new Label();
            btnLogin = new Button();
            txtSifre = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblError);
            pnlMain.Controls.Add(btnLogin);
            pnlMain.Controls.Add(txtSifre);
            pnlMain.Controls.Add(txtUsername);
            pnlMain.Location = new Point(200, 125);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(500, 400);
            pnlMain.TabIndex = 0;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(40, 264);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 30);
            lblError.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(25, 118, 210);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(75, 325);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(350, 45);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "GİRİŞ YAP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseHover += btnLogin_MouseHover;
            // 
            // txtSifre
            // 
            txtSifre.BorderStyle = BorderStyle.FixedSingle;
            txtSifre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifre.Location = new Point(147, 118);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '•';
            txtSifre.PlaceholderText = "Şifrenizi Giriniz";
            txtSifre.Size = new Size(200, 29);
            txtSifre.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtUsername.Location = new Point(147, 78);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Kullanıcı Adınızı Giriniz";
            txtUsername.Size = new Size(200, 29);
            txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(0, 74, 173);
            label1.Location = new Point(250, 30);
            label1.Name = "label1";
            label1.Size = new Size(390, 45);
            label1.TabIndex = 1;
            label1.Text = "YOKLAMA TAKİP SİSTEMİ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // giris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(884, 611);
            Controls.Add(label1);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "giris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yoklama Takip Sistemi";
            Shown += giris_Shown;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMain;
        private Label label1;
        private TextBox txtUsername;
        private Button btnLogin;
        private TextBox txtSifre;
        private Label lblError;
    }
}
