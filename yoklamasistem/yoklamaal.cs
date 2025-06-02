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
    public partial class yoklamaal : Form
    {
        private const string ConnectionString = @"Server=DESKTOP-RPNNDSK\SQLEXPRESS;Database=YoklamaTakipDB;Integrated Security=True;";
        private int _ogretmenID; // Bu form açıldığında giriş yapan öğretmenin ID'si
        public yoklamaal(int ogretmenID)
        {
            InitializeComponent();
            _ogretmenID = ogretmenID; // Öğretmen ID'sini kaydet

            SetupDataGridView();     // DataGridView sütunlarını ayarla
            LoadDersler();           // Ders ComboBox'ını doldur

            // Olayları ata
            cmbDersler.SelectedIndexChanged += cmbDersler_SelectedIndexChanged;
            dtpYoklamaTarihi.ValueChanged += dtpYoklamaTarihi_ValueChanged;
            // Form yüklendiğinde varsayılan olarak bir ders seçimi olmadığından DataGridView'i temizle
            dgvStudents.DataSource = null; // Burası değişti: dgvStudent -> dgvStudents 
        }
        // --- DataGridView Sütunlarını Ayarlama Metodu ---
        private void SetupDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false; // Burası değişti
            dgvStudents.AllowUserToAddRows = false;  // Burası değişti
            dgvStudents.AllowUserToDeleteRows = false; // Burası değişti
            dgvStudents.ReadOnly = false;            // Burası değişti

            dgvStudents.Columns.Clear();             // Burası değişti

            // ÖğrenciID sütunu (gizli, YoklamaDetay tablosundaki OgrenciID'ye karşılık gelir)
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colOgrenciID", HeaderText = "Öğrenci ID", DataPropertyName = "KullaniciID", Visible = false });

            // YoklamaDetayID (gizli, güncelleme için gerekli)
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colYoklamaDetayID", HeaderText = "Yoklama Detay ID", DataPropertyName = "YoklamaDetayID", Visible = false });

            // Öğrenci No sütunu (Veritabanındaki KullaniciNo sütunu varsayıldı)
            // Öğrenci No sütunu - Artık KullaniciID'yi gösterecek
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colOgrenciNo", HeaderText = "Öğrenci Numarası/ID", DataPropertyName = "KullaniciID", ReadOnly = true });

            // Ad Soyad sütunu
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colAdSoyad", HeaderText = "Ad Soyad", DataPropertyName = "AdSoyad", ReadOnly = true });

            // Durum (Geldi/Gelmedi ComboBox) sütunu
            DataGridViewComboBoxColumn colDurum = new DataGridViewComboBoxColumn();
            colDurum.Name = "colDurum";
            colDurum.HeaderText = "Durum";
            colDurum.Items.AddRange("Geldi", "Gelmedi"); // Seçenekler
            colDurum.DataPropertyName = "Durum"; // Eğer mevcut bir yoklama kaydı varsa buradan yüklenecek
            dgvStudents.Columns.Add(colDurum);

            // Not (Opsiyonel açıklama) sütunu
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colNot", HeaderText = "Not", DataPropertyName = "Notlar" }); // Eğer mevcut bir yoklama kaydı varsa buradan yüklenecek

            // Uyarı Durumu sütunu (Hesaplamalı olacak, ReadOnly)
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colUyariDurumu", HeaderText = "Uyarı Durumu", ReadOnly = true });

            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.Columns["colNot"].FillWeight = 150; // Not sütunu biraz daha geniş olsun
        }
        // --- Metot: Öğretmenin Atandığı Dersleri Yükleme (`cmbDersler` için) ---
        private void LoadDersler()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Öğretmenin atandığı dersleri OgretmenDers tablosundan çekiyoruz
                    string query = @"
                        SELECT d.DersID, d.DersAdi, d.DersKodu
                        FROM Dersler d
                        JOIN OgretmenDers od ON d.DersID = od.DersID
                        WHERE od.KullaniciID = @OgretmenID
                        ORDER BY d.DersAdi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OgretmenID", _ogretmenID);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDersler.DataSource = dt;
                    cmbDersler.DisplayMember = "DersAdi";
                    cmbDersler.ValueMember = "DersID";
                    cmbDersler.SelectedIndex = -1; // Hiçbirini seçili başlatma
                    cmbDersler.Text = "-- Ders Seç --";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(56, 142, 60);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDersler.SelectedValue == null || cmbDersler.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Lütfen yoklama alınacak dersi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dersID = (int)cmbDersler.SelectedValue;
            DateTime yoklamaTarihi = dtpYoklamaTarihi.Value.Date;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(); // Tüm işlemi tek bir transaction altında yönet

                try
                {
                    // 1. Yoklamalar tablosuna kayıt ekle veya mevcut YoklamaID'yi al
                    int yoklamaID;
                    string checkYoklamaQuery = @"
                        SELECT YoklamaID
                        FROM Yoklamalar
                        WHERE DersID = @DersID AND OgretmenID = @OgretmenID AND Tarih = @Tarih";

                    SqlCommand checkCmd = new SqlCommand(checkYoklamaQuery, connection, transaction);
                    checkCmd.Parameters.AddWithValue("@DersID", dersID);
                    checkCmd.Parameters.AddWithValue("@OgretmenID", _ogretmenID);
                    checkCmd.Parameters.AddWithValue("@Tarih", yoklamaTarihi);

                    object result = checkCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        yoklamaID = Convert.ToInt32(result); // Mevcut YoklamaID'yi al
                    }
                    else
                    {
                        // Yeni Yoklama kaydı ekle
                        string insertYoklamaQuery = @"
                            INSERT INTO Yoklamalar (DersID, OgretmenID, Tarih)
                            VALUES (@DersID, @OgretmenID, @Tarih);
                            SELECT SCOPE_IDENTITY();"; // Eklenen kaydın ID'sini geri al

                        SqlCommand insertYoklamaCmd = new SqlCommand(insertYoklamaQuery, connection, transaction);
                        insertYoklamaCmd.Parameters.AddWithValue("@DersID", dersID);
                        insertYoklamaCmd.Parameters.AddWithValue("@OgretmenID", _ogretmenID);
                        insertYoklamaCmd.Parameters.AddWithValue("@Tarih", yoklamaTarihi);

                        yoklamaID = Convert.ToInt32(insertYoklamaCmd.ExecuteScalar()); // Yeni YoklamaID'yi al
                    }

                    // 2. Her öğrenci için YoklamaDetay kaydını ekle veya güncelle
                    foreach (DataGridViewRow row in dgvStudents.Rows) // dgvStudents olarak güncellendi
                    {
                        if (row.IsNewRow) continue;

                        int ogrenciID = Convert.ToInt32(row.Cells["colOgrenciID"].Value);
                        string durum = row.Cells["colDurum"].Value?.ToString();
                        string notlar = row.Cells["colNot"].Value?.ToString();

                        if (string.IsNullOrWhiteSpace(durum))
                        {
                            MessageBox.Show($"'{row.Cells["colAdSoyad"].Value}' adlı öğrencinin durumu boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            transaction.Rollback();
                            return;
                        }

                        // YoklamaDetayID'si var mı? (yani bu öğrencinin bu yoklama için zaten kaydı var mı?)
                        object yoklamaDetayIDObj = row.Cells["colYoklamaDetayID"].Value;
                        int? yoklamaDetayID = null;
                        if (yoklamaDetayIDObj != null && yoklamaDetayIDObj != DBNull.Value)
                        {
                            yoklamaDetayID = Convert.ToInt32(yoklamaDetayIDObj);
                        }

                        SqlCommand detailCommand;
                        if (yoklamaDetayID.HasValue) // Mevcut bir YoklamaDetay kaydı varsa güncelle
                        {
                            string updateDetailQuery = @"
                                UPDATE YoklamaDetay
                                SET Durum = @Durum, Notlar = @Notlar
                                WHERE YoklamaDetayID = @YoklamaDetayID";
                            detailCommand = new SqlCommand(updateDetailQuery, connection, transaction);
                            detailCommand.Parameters.AddWithValue("@Durum", durum);
                            detailCommand.Parameters.AddWithValue("@Notlar", (object)notlar ?? DBNull.Value);
                            detailCommand.Parameters.AddWithValue("@YoklamaDetayID", yoklamaDetayID.Value);
                        }
                        else // Yeni bir YoklamaDetay kaydı ekle
                        {
                            string insertDetailQuery = @"
                                INSERT INTO YoklamaDetay (YoklamaID, OgrenciID, Durum, Notlar)
                                VALUES (@YoklamaID, @OgrenciID, @Durum, @Notlar)";
                            detailCommand = new SqlCommand(insertDetailQuery, connection, transaction);
                            detailCommand.Parameters.AddWithValue("@YoklamaID", yoklamaID);
                            detailCommand.Parameters.AddWithValue("@OgrenciID", ogrenciID);
                            detailCommand.Parameters.AddWithValue("@Durum", durum);
                            detailCommand.Parameters.AddWithValue("@Notlar", (object)notlar ?? DBNull.Value);
                        }
                        detailCommand.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Tüm işlemler başarılıysa kaydet
                    MessageBox.Show("Yoklama başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Kaydedildikten sonra DataGridView'i yeniden yükleyerek güncel durumu gör
                    LoadOgrencilerForYoklama(dersID, yoklamaTarihi);
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Hata oluşursa işlemi geri al
                    MessageBox.Show("Yoklama kaydedilirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Genel bir hata oluşursa geri al
                    MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void cmbDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDersler.SelectedValue != null && cmbDersler.SelectedValue != DBNull.Value)
            {
                int dersID;
                // cmbDersler.SelectedValue bir DataRowView mi diye kontrol et
                if (cmbDersler.SelectedValue is DataRowView drv)
                {
                    // Eğer öyleyse, DataRowView içindeki "DersID" sütununu al
                    dersID = Convert.ToInt32(drv["DersID"]);
                }
                else
                {
                    // Değilse (yani doğrudan int veya int'e dönüştürülebilir bir object ise), direkt dönüştür
                    dersID = Convert.ToInt32(cmbDersler.SelectedValue);
                }

                LoadOgrencilerForYoklama(dersID, dtpYoklamaTarihi.Value.Date);
            }
            else
            {
                dgvStudents.DataSource = null;
            }
        }

        private void dtpYoklamaTarihi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbDersler.SelectedValue != null && cmbDersler.SelectedValue != DBNull.Value)
            {
                int dersID;
                // cmbDersler.SelectedValue bir DataRowView mi diye kontrol et
                if (cmbDersler.SelectedValue is DataRowView drv)
                {
                    // Eğer öyleyse, DataRowView içindeki "DersID" sütununu al
                    dersID = Convert.ToInt32(drv["DersID"]);
                }
                else
                {
                    // Değilse (yani doğrudan int veya int'e dönüştürülebilir bir object ise), direkt dönüştür
                    dersID = Convert.ToInt32(cmbDersler.SelectedValue);
                }

                LoadOgrencilerForYoklama(dersID, dtpYoklamaTarihi.Value.Date);
            }
            else
            {
                dgvStudents.DataSource = null;
            }
        }
        // --- Metot: Yoklama İçin Öğrencileri Yükleme (OgrenciDers tablosundan) ---
        // Bu metot, seçilen derse kayıtlı öğrencileri ve varsa o tarihe ait yoklama durumlarını getirir.
        private void LoadOgrencilerForYoklama(int dersID, DateTime yoklamaTarihi)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Öncelikle o derse, öğretmene ve tarihe ait bir yoklama kaydı (Yoklamalar tablosunda) var mı kontrol et
                    int? mevcutYoklamaID = null;
                    string checkYoklamaQuery = @"
                        SELECT YoklamaID
                        FROM Yoklamalar
                        WHERE DersID = @DersID AND OgretmenID = @OgretmenID AND Tarih = @Tarih";

                    SqlCommand checkCmd = new SqlCommand(checkYoklamaQuery, connection);
                    checkCmd.Parameters.AddWithValue("@DersID", dersID);
                    checkCmd.Parameters.AddWithValue("@OgretmenID", _ogretmenID);
                    checkCmd.Parameters.AddWithValue("@Tarih", yoklamaTarihi.Date);

                    object result = checkCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        mevcutYoklamaID = Convert.ToInt32(result);
                    }

                    // Öğrencileri ve varsa mevcut yoklama durumlarını getir
                    string queryOgrenciler = string.Empty;
                    if (mevcutYoklamaID.HasValue) // Mevcut yoklama kaydı varsa detayları ile getir
                    {
                        queryOgrenciler = @"
                            SELECT
        k.KullaniciID,
        -- k.KullaniciNo, // Bu satır silindi
        k.Ad + ' ' + k.Soyad AS AdSoyad,
        ydet.YoklamaDetayID,
        ISNULL(ydet.Durum, 'Geldi') AS Durum,
        ISNULL(ydet.Notlar, '') AS Notlar
    FROM Kullanicilar k
    JOIN OgrenciDers od ON k.KullaniciID = od.KullaniciID
    LEFT JOIN YoklamaDetay ydet ON k.KullaniciID = ydet.OgrenciID
                                AND ydet.YoklamaID = @YoklamaID
    WHERE od.DersID = @DersID AND k.Rol = 'Öğrenci'
    ORDER BY k.Ad, k.Soyad";
                    }
                    else // Yoklama kaydı yoksa sadece öğrencileri varsayılan durumla getir
                    {
                        queryOgrenciler = @"
        SELECT
            k.KullaniciID,
            -- k.KullaniciNo, // Bu satır silindi
            k.Ad + ' ' + k.Soyad AS AdSoyad,
            NULL AS YoklamaDetayID,
            'Geldi' AS Durum,
            '' AS Notlar
        FROM Kullanicilar k
        JOIN OgrenciDers od ON k.KullaniciID = od.KullaniciID
        WHERE od.DersID = @DersID AND k.Rol = 'Öğrenci'
        ORDER BY k.Ad, k.Soyad";
                    }

                    SqlCommand command = new SqlCommand(queryOgrenciler, connection);
                    command.Parameters.AddWithValue("@DersID", dersID);
                    if (mevcutYoklamaID.HasValue)
                    {
                        command.Parameters.AddWithValue("@YoklamaID", mevcutYoklamaID.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudents.DataSource = dt; // Burası değişti

                    CalculateAndDisplayUyariDurumu(); // Uyarı durumlarını hesapla ve göster
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Öğrenciler yüklenirken veya yoklama durumu getirilirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvStudents.DataSource = null; // Burası değişti
                }
            }
        }
        // --- Metot: Uyarı Durumunu Hesaplama ve Gösterme ---
        // Bu metot, her öğrencinin o dersteki toplam devamsızlığını hesaplar ve DataGridView'de gösterir.
        private void CalculateAndDisplayUyariDurumu()
        {
            if (dgvStudents.Rows.Count == 0 || cmbDersler.SelectedValue == null) return; // Burası değişti

            int dersID;
            // cmbDersler.SelectedValue bir DataRowView mi diye kontrol et
            if (cmbDersler.SelectedValue is DataRowView drv)
            {
                // Eğer öyleyse, DataRowView içindeki "DersID" sütununu al
                dersID = Convert.ToInt32(drv["DersID"]);
            }
            else
            {
                // Değilse (yani doğrudan int veya int'e dönüştürülebilir bir object ise), direkt dönüştür
                dersID = Convert.ToInt32(cmbDersler.SelectedValue);
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Her öğrencinin toplam devamsızlık sayısını çek
                    // YoklamaDetay tablosundan sadece 'Gelmedi' durumundaki kayıtları say
                    string query = @"
                        SELECT ydet.OgrenciID, COUNT(*) AS DevamsizlikSayisi
                        FROM YoklamaDetay ydet
                        JOIN Yoklamalar y ON ydet.YoklamaID = y.YoklamaID
                        WHERE y.DersID = @DersID AND ydet.Durum = 'Gelmedi'
                        GROUP BY ydet.OgrenciID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DersID", dersID);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dtDevamsizlik = new DataTable();
                    da.Fill(dtDevamsizlik);

                    foreach (DataGridViewRow row in dgvStudents.Rows) // Burası değişti
                    {
                        if (row.IsNewRow) continue; // Yeni eklenen boş satırı atla
                        int ogrenciID = Convert.ToInt32(row.Cells["colOgrenciID"].Value);

                        DataRow[] foundRows = dtDevamsizlik.Select($"OgrenciID = {ogrenciID}");

                        int devamsizlikSayisi = 0;
                        if (foundRows.Length > 0)
                        {
                            devamsizlikSayisi = Convert.ToInt32(foundRows[0]["DevamsizlikSayisi"]);
                        }

                        // Uyarı durumu için basit bir kural ve renklendirme
                        string uyariDurumu = "";
                        Color rowBackColor = dgvStudents.DefaultCellStyle.BackColor; // Varsayılan renk (Burayı kendi istediğin renk yapsanda olur veya varsayılan bırak)

                        if (devamsizlikSayisi >= 3 && devamsizlikSayisi < 5)
                        {
                            uyariDurumu = "Riskli (" + devamsizlikSayisi + ")";
                            rowBackColor = Color.LightYellow;
                        }
                        else if (devamsizlikSayisi >= 5)
                        {
                            uyariDurumu = "TEHLİKELİ! (" + devamsizlikSayisi + ")";
                            rowBackColor = Color.LightCoral;
                        }
                        else
                        {
                            uyariDurumu = "Normal (" + devamsizlikSayisi + ")";
                        }

                        row.Cells["colUyariDurumu"].Value = uyariDurumu;
                        row.DefaultCellStyle.BackColor = rowBackColor;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Devamsızlık durumu hesaplanırken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
