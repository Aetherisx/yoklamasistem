using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoklamasistem
{

    public partial class yoneticipanel : Form
    {
        private int _loggedInKullaniciID;
        private string _loggedInKullaniciAd;
        private string _loggedInKullaniciSoyad;
        public yoneticipanel(int kullaniciID, string ad, string soyad)
        {
            InitializeComponent();
            _loggedInKullaniciID = kullaniciID;
            _loggedInKullaniciAd = ad;
            _loggedInKullaniciSoyad = soyad;
        }
        private void LoadUserControl(UserControl userControl)
        {
            // pnlContent'i temizle (önceki UserControl'leri kaldır)
            pnlContent.Controls.Clear();

            // UserControl'ü panele ekle
            userControl.Dock = DockStyle.Fill; // Paneli dolduracak şekilde ayarla
            pnlContent.Controls.Add(userControl);

            // Eğer UserControl'ün kendi Load olayı varsa tetiklenir
            userControl.BringToFront(); // En üste getir
        }
        private void btnKullaniciYonetim_Click(object sender, EventArgs e)
        {
            LoadUserControl(new kullaniciyonetim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new dersatama());
        }
    }
}
