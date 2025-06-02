using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoklamasistem
{
    public partial class ogrenci : Form
    {
        private const string ConnectionString = @"Server=DESKTOP-RPNNDSK\SQLEXPRESS;Database=YoklamaTakipDB;Integrated Security=True;";

        // Giriş yapan öğrencinin bilgilerini tutacak değişkenler
        private int _loggedInOgrenciID;
        private string _loggedInOgrenciAd;
        private string _loggedInOgrenciSoyad;
        public ogrenci(int ogrenciID, string ad, string soyad)
        {
            InitializeComponent();
            // Bilgileri sınıf değişkenlerine atama
            _loggedInOgrenciID = ogrenciID;
            _loggedInOgrenciAd = ad;
            _loggedInOgrenciSoyad = soyad;

            // Form yüklendiğinde metodları çağırmak için olay ataması
            this.Load += ogrenci_Load;

            // Çıkış butonunun Click olayını bağlama
            btnCikis.Click += btnCikis_Click;
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
        }

        private void ogrenci_Load(object sender, EventArgs e)
        {
            // Hoşgeldiniz mesajını ve öğrenci adını/soyadını göster
            lblWelcome.Text = "Hoşgeldiniz, " + _loggedInOgrenciAd + " " + _loggedInOgrenciSoyad;

            // Sağdaki Label'da bugünün tarihini göster
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy, dddd"); // Örnek: "02 Haziran 2025, Pazartesi"

            // DataGridView sütunlarını ayarla
            SetupDataGridView();

            // Devamsızlık bilgilerini yükle
            LoadDevamsizlikBilgileri();
        }
        private void SetupDataGridView()
        {
            dgvDevamsizlik.Columns.Clear(); // Önceki sütunları temizle
            dgvDevamsizlik.AutoGenerateColumns = false; // Otomatik sütun oluşturmayı kapat

            // Ders Adı sütunu
            dgvDevamsizlik.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDersAdi",
                HeaderText = "Ders Adı",
                DataPropertyName = "DersAdi", // SQL sorgusundaki alias ile aynı olmalı
                ReadOnly = true
            });

            // Devamsızlık sütunu
            dgvDevamsizlik.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDevamsizlik",
                HeaderText = "Devamsızlık",
                DataPropertyName = "DevamsizlikSayisi", // SQL sorgusundaki alias ile aynı olmalı
                ReadOnly = true
            });

            // Opsiyonel: Sütun genişliklerini ayarlayabilirsiniz
            dgvDevamsizlik.Columns["colDersAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevamsizlik.Columns["colDevamsizlik"].Width = 100;
        }
        private void LoadDevamsizlikBilgileri()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            d.DersAdi,
                            SUM(CASE WHEN yd.Durum = 'Gelmedi' THEN 1 ELSE 0 END) AS DevamsizlikSayisi
                        FROM OgrenciDers od
                        JOIN Dersler d ON od.DersID = d.DersID
                        LEFT JOIN Yoklamalar y ON y.DersID = d.DersID -- Ders ile Yoklama'yı bağlar
                        LEFT JOIN YoklamaDetay yd ON yd.YoklamaID = y.YoklamaID AND yd.OgrenciID = od.KullaniciID -- YoklamaDetay'ı öğrenci ve yoklama ile bağlar
                        WHERE od.KullaniciID = @OgrenciID
                        GROUP BY d.DersAdi
                        ORDER BY d.DersAdi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OgrenciID", _loggedInOgrenciID);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDevamsizlik.DataSource = dt;

                    // Eğer hiç devamsızlık bilgisi yoksa veya dersi yoksa, bir mesaj gösterebilirsiniz
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Henüz devamsızlık bilginiz bulunmamaktadır veya atanmış dersiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Devamsızlık bilgileri yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
