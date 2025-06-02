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
    public partial class ogretmen : Form
    {
        private int _girisYapanOgretmenID; // Bu değişkeni sınıfınızda tanımlayın
        private int _loggedInKullaniciID;
        private string _loggedInKullaniciAd;
        private string _loggedInKullaniciSoyad;

        public ogretmen(int kullaniciID, string ad, string soyad, int ogretmenID)
        {
            InitializeComponent();
            _loggedInKullaniciID = kullaniciID;
            _loggedInKullaniciAd = ad;
            _loggedInKullaniciSoyad = soyad;
            _girisYapanOgretmenID = ogretmenID; // ID'yi sınıf değişkenine atayın

            // Tarih ve Ad Soyad etiketlerini doldurma (eğer henüz yapmadıysanız)
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy, dddd"); // lblTarih etiketinizin adı
            lblUserName.Text = _loggedInKullaniciAd + " " + _loggedInKullaniciSoyad;

        }

        private void btnAttendance_MouseHover(object sender, EventArgs e)
        {
            btnAttendance.BackColor = Color.FromArgb(55, 71, 79);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            // Yeni YoklamaAlma formunu oluştur
            // _girisYapanOgretmenID değişkenini parametre olarak gönderiyoruz
            yoklamaal yoklamaForm = new yoklamaal(_girisYapanOgretmenID);

            // YoklamaAlma formunu modallı olarak göster.
            // Modallı olması, bu form açıkken arkadaki Öğretmen Panelinin kullanılamayacağı anlamına gelir.
            yoklamaForm.ShowDialog();

            // YoklamaAlma formu kapandıktan sonra Öğretmen Paneli'nde herhangi bir güncelleme gerekirse
            // (örneğin, devamsızlık raporları önizlemesini yenilemek gibi)
            // buraya o kodları ekleyebilirsiniz.
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            gecmisyoklama gecmisForm = new gecmisyoklama(_girisYapanOgretmenID);
            gecmisForm.ShowDialog();
        }
    }
}
