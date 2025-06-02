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
    public partial class dersatama : UserControl
    {
        // Bağlantı dizeniz, projenize göre kontrol edin.
        private const string ConnectionString = @"Server=DESKTOP-RPNNDSK\SQLEXPRESS;Database=YoklamaTakipDB;Integrated Security=True;";

        private int _seciliKullaniciID = -1; // Seçili kullanıcının ID'si
        private string _seciliKullaniciTipi = string.Empty; // Seçili kullanıcının tipi (Öğrenci/Öğretmen)
        public dersatama()
        {
            InitializeComponent();
            SetupComboBoxes(); // ComboBox'ları doldur
            SetupDataGridViews(); // DataGridView'leri ayarla

            // Olayları atama (Tasarımcıdan da yapılabilir, koddan da)
            cmbKullaniciTipi.SelectedIndexChanged += cmbKullaniciTipi_SelectedIndexChanged;
            cmbKullanicilar.SelectedIndexChanged += cmbKullanicilar_SelectedIndexChanged;
            dgvAtananDersler.CellContentClick += dgvAtananDersler_CellContentClick;
            dgvTumDersler.CellContentClick += dgvTumDersler_CellContentClick;
            btnCıkıs.Click += btnCıkıs_Click;

            // Başlangıçta ComboBox'lar boş olacağı veya seçili kullanıcı olmadığı için DataGridView'leri temizle
            ClearDersListings();
        }
        private void SetupComboBoxes()
        {
            // cmbKullaniciTipi'nin Items koleksiyonu tasarımda dolduruldu.
            // İlk olarak hiçbir şey seçili olmasın.
            cmbKullaniciTipi.SelectedIndex = -1;
            cmbKullaniciTipi.Text = "-- Kullanıcı Tipi Seç --";

            cmbKullanicilar.SelectedIndex = -1;
            cmbKullanicilar.Text = "-- Kullanıcı Seç --";
            cmbKullanicilar.Enabled = false; // Kullanıcı tipi seçilmeden kullanıcı seçimi pasif olsun
        }
        // --- DataGridView'leri Ayarlama Metodu ---
        private void SetupDataGridViews()
        {
            // dgvAtananDersler (Üstteki DataGridView)
            dgvAtananDersler.AutoGenerateColumns = false;
            dgvAtananDersler.AllowUserToAddRows = false;
            dgvAtananDersler.AllowUserToDeleteRows = false;
            dgvAtananDersler.ReadOnly = true; // Sadece görüntüleme amaçlı

            dgvAtananDersler.Columns.Clear();
            dgvAtananDersler.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colAtananDersID", HeaderText = "ID", DataPropertyName = "DersID", Visible = false });
            dgvAtananDersler.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colAtananDersAdi", HeaderText = "Ders Adı", DataPropertyName = "DersAdi" });

            // "Kaldır" Buton Sütunu
            DataGridViewButtonColumn kaldirBtn = new DataGridViewButtonColumn();
            kaldirBtn.Name = "colKaldir";
            kaldirBtn.HeaderText = "İşlem"; // Başlık "İşlem" olarak istendi
            kaldirBtn.Text = "Kaldır";
            kaldirBtn.UseColumnTextForButtonValue = true;
            dgvAtananDersler.Columns.Add(kaldirBtn);
            dgvAtananDersler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // dgvTumDersler (Alttaki DataGridView)
            dgvTumDersler.AutoGenerateColumns = false;
            dgvTumDersler.AllowUserToAddRows = false;
            dgvTumDersler.AllowUserToDeleteRows = false;
            dgvTumDersler.ReadOnly = true; // Sadece görüntüleme amaçlı

            dgvTumDersler.Columns.Clear();
            dgvTumDersler.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colTumDersID", HeaderText = "ID", DataPropertyName = "DersID", Visible = false });
            dgvTumDersler.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colTumDersAdi", HeaderText = "Ders Adı", DataPropertyName = "DersAdi" });

            // "Ekle" Buton Sütunu
            DataGridViewButtonColumn ekleBtn = new DataGridViewButtonColumn();
            ekleBtn.Name = "colEkle";
            ekleBtn.HeaderText = "İşlem"; // Başlık "İşlem" olarak istendi
            ekleBtn.Text = "Ekle";
            ekleBtn.UseColumnTextForButtonValue = true;
            dgvTumDersler.Columns.Add(ekleBtn);
            dgvTumDersler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void pnlFiltre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbKullaniciTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            _seciliKullaniciTipi = cmbKullaniciTipi.SelectedItem?.ToString(); // Null kontrolü ekledim

            if (!string.IsNullOrWhiteSpace(_seciliKullaniciTipi))
            {
                cmbKullanicilar.Enabled = true; // Kullanıcı tipi seçildi, kullanıcıları aktif hale getir
                LoadKullanicilarByRol(_seciliKullaniciTipi); // Seçilen tipe göre kullanıcıları yükle
            }
            else
            {
                cmbKullanicilar.Enabled = false; // Tipi yoksa pasif yap
                cmbKullanicilar.DataSource = null; // Kullanıcı combobox'ını temizle
                cmbKullanicilar.Text = "-- Kullanıcı Seç --";
            }

            ClearDersListings(); // Yeni tip seçildiğinde ders listelerini temizle
            _seciliKullaniciID = -1; // Seçili kullanıcı ID'sini sıfırla
        }
        // --- Metot: Seçilen Role Göre Kullanıcıları Yükleme ---
        private void LoadKullanicilarByRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol)) return;

            // Rol adlarını veritabanındaki "Rol" sütunuyla eşleşecek şekilde düzenle.
            // Örneğin, "Öğrenciler" seçiliyse veritabanında "Öğrenci" rolünü çek.
            string dbRol = string.Empty;
            if (rol == "Öğrenciler")
            {
                dbRol = "Öğrenci";
            }
            else if (rol == "Öğretmenler")
            {
                dbRol = "Öğretmen";
            }
            else
            {
                cmbKullanicilar.DataSource = null;
                cmbKullanicilar.Text = "-- Kullanıcı Seç --";
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT KullaniciID, Ad, Soyad, KullaniciAdi FROM Kullanicilar WHERE Rol = @Rol ORDER BY Ad, Soyad"; SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Rol", dbRol);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns.Add("TamAd", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["TamAd"] = row["Ad"].ToString() + " " + row["Soyad"].ToString();
                    }

                    cmbKullanicilar.DataSource = dt;
                    // Kullanıcı Adı ve Soyadı birlikte göster
                    cmbKullanicilar.DisplayMember = "TamAd"; // Artık Ad ve Soyad birlikte görünecek
                    cmbKullanicilar.ValueMember = "KullaniciID";

                    // ComboBox'ta "Ad Soyad (KullaniciAdi)" şeklinde göstermek için
                    // DisplayMember otomatik olarak DataTable'dan çekildiği için,
                    // Eğer Ad ve Soyadı ayrı bir sütun olarak istiyorsan, sorguya ekleyip
                    // DataTable'a yeni bir sütun ekleyip birleştirmelisin.
                    // Şimdilik sadece KullaniciAdi görünsün.

                    cmbKullanicilar.SelectedIndex = -1;
                    cmbKullanicilar.Text = "-- Kullanıcı Seç --";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SelectedValue bir object döner, int'e dönüştürmeye çalışırken null veya DBNull kontrolü önemli.
            if (cmbKullanicilar.SelectedValue != null && cmbKullanicilar.SelectedValue != DBNull.Value)
            {
                if (int.TryParse(cmbKullanicilar.SelectedValue.ToString(), out _seciliKullaniciID))
                {
                    LoadDersListings(_seciliKullaniciID, _seciliKullaniciTipi); // Seçili kullanıcı ve tipe göre dersleri yükle
                }
                else
                {
                    // Dönüşüm başarısız olursa
                    _seciliKullaniciID = -1;
                    ClearDersListings();
                }
            }
            else
            {
                _seciliKullaniciID = -1;
                ClearDersListings(); // Kullanıcı seçimi kalkarsa ders listelerini temizle
            }
        }
        // --- Metot: Seçili Kullanıcı ve Tipe Göre Ders Listelerini Yükleme ---
        private void LoadDersListings(int kullaniciID, string kullaniciTipi)
        {
            if (kullaniciID == -1 || string.IsNullOrWhiteSpace(kullaniciTipi))
            {
                ClearDersListings();
                return;
            }

            string atamaTablosu = string.Empty;
            if (kullaniciTipi == "Öğrenciler")
            {
                atamaTablosu = "OgrenciDers";
            }
            else if (kullaniciTipi == "Öğretmenler")
            {
                atamaTablosu = "OgretmenDers";
            }
            else
            {
                ClearDersListings();
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Atanan Dersler Sorgusu
                    string queryAtanan = $@"
                        SELECT d.DersID, d.DersAdi, d.DersKodu
                        FROM Dersler d
                        JOIN {atamaTablosu} kd ON d.DersID = kd.DersID
                        WHERE kd.KullaniciID = @KullaniciID
                        ORDER BY d.DersAdi";

                    SqlCommand cmdAtanan = new SqlCommand(queryAtanan, connection);
                    cmdAtanan.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    SqlDataAdapter daAtanan = new SqlDataAdapter(cmdAtanan);
                    DataTable dtAtanan = new DataTable();
                    daAtanan.Fill(dtAtanan);
                    dgvAtananDersler.DataSource = dtAtanan;

                    // Tüm Dersler (Atanmamış olanlar) Sorgusu
                    string queryTum = $@"
                        SELECT d.DersID, d.DersAdi, d.DersKodu
                        FROM Dersler d
                        WHERE d.DersID NOT IN (
                            SELECT kd.DersID
                            FROM {atamaTablosu} kd
                            WHERE kd.KullaniciID = @KullaniciID
                        )
                        ORDER BY d.DersAdi";

                    SqlCommand cmdTum = new SqlCommand(queryTum, connection);
                    cmdTum.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    SqlDataAdapter daTum = new SqlDataAdapter(cmdTum);
                    DataTable dtTum = new DataTable();
                    daTum.Fill(dtTum);
                    dgvTumDersler.DataSource = dtTum;

                    // ******* BURASI ÇÖZÜM İÇİN ÇOK ÖNEMLİ! *******
                    // UI güncellemelerini ve odaklanmayı bir sonraki UI döngüsüne bırak
                    // Bu, DataGridView'in veri bağlama ve render etme işlemlerini tamamlamasını sağlar
                    // ve bu işlemler sırasında oluşabilecek istenmeyen CellContentClick tetiklenmelerini engeller.
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        dgvAtananDersler.ClearSelection(); // Üstteki DataGridView'deki seçimi temizle
                        dgvTumDersler.ClearSelection();   // Alttaki DataGridView'deki seçimi temizle

                        // Odaklanmayı başka bir kontrole alarak DataGridView'in
                        // otomatik olarak bir hücreye odaklanmasını ve potansiyel 'sanal tıklama'
                        // olayını engelle. En üstteki ComboBox'a odaklanabiliriz.
                        cmbKullaniciTipi.Focus();
                    });
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ders listeleri yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearDersListings();
                    // Hata durumunda da aynı temizleme ve odaklanma işlemini yap
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        dgvAtananDersler.ClearSelection();
                        dgvTumDersler.ClearSelection();
                        cmbKullaniciTipi.Focus();
                    });
                }
            }
        }
        // --- Metot: Ders Listelerini Temizleme ---
        private void ClearDersListings()
        {
            dgvAtananDersler.DataSource = null;
            dgvTumDersler.DataSource = null;
        }

        private void dgvAtananDersler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvAtananDersler.Rows.Count || e.RowIndex == dgvAtananDersler.NewRowIndex)
            {
                return; // Geçersiz bir satıra tıklanırsa metoddan hemen çık
            }

            // Tıklanan sütunun 'colKaldir' isimli bir buton sütunu olduğundan emin ol
            if (dgvAtananDersler.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dgvAtananDersler.Columns[e.ColumnIndex].Name == "colKaldir")
            {
                // Kullanıcının seçili olup olmadığını kontrol et
                if (_seciliKullaniciID == -1 || string.IsNullOrWhiteSpace(_seciliKullaniciTipi))
                {
                    MessageBox.Show("Lütfen önce bir kullanıcı tipi ve kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // *** BURADA DEĞİŞİKLİK YAPIYORUZ: VERİYE DataBoundItem ÜZERİNDEN ERİŞİM ***
                // Seçili satırın bağlı olduğu veri nesnesini (DataRowView) al
                if (dgvAtananDersler.Rows[e.RowIndex].DataBoundItem is DataRowView rowView)
                {
                    int dersID = -1;
                    string dersAdi = string.Empty;

                    // DataRowView içindeki DataRow'dan DersID'yi güvenli bir şekilde al
                    // Önce sütunun tabloda olup olmadığını, sonra değerin DBNull olup olmadığını kontrol ediyoruz.
                    if (rowView.Row.Table.Columns.Contains("DersID") && rowView.Row["DersID"] != DBNull.Value)
                    {
                        dersID = Convert.ToInt32(rowView.Row["DersID"]);
                    }
                    else
                    {
                        MessageBox.Show("Ders ID'si alınamadı veya geçersiz (DersID sütunu yok/boş).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // DataRowView içindeki DataRow'dan DersAdı'nı güvenli bir şekilde al
                    if (rowView.Row.Table.Columns.Contains("DersAdi") && rowView.Row["DersAdi"] != DBNull.Value)
                    {
                        dersAdi = rowView.Row["DersAdi"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Ders Adı alınamadı veya geçersiz (DersAdi sütunu yok/boş).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ders ID'si ve Ders Adı başarıyla alındı, şimdi onay mesajını göster
                    DialogResult dialogResult = MessageBox.Show(
                        $"{dersAdi} dersini seçili kullanıcıdan kaldırmak istediğinize emin misiniz?",
                        "Ders Kaldırma Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            RemoveDersFromKullanici(_seciliKullaniciID, dersID, _seciliKullaniciTipi);
                            MessageBox.Show($"{dersAdi} dersi başarıyla kaldırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDersListings(_seciliKullaniciID, _seciliKullaniciTipi);
                            return; // Önceki adımda eklediğimiz bu satır burada kalmalı
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ders kaldırılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seçili satırın veri içeriği bulunamadı veya geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            }
        

        private void dgvTumDersler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTumDersler.Rows.Count || e.RowIndex == dgvTumDersler.NewRowIndex)
            {
                return; // Geçersiz bir satıra tıklanırsa metoddan hemen çık
            }

            // Tıklanan sütunun 'colEkle' isimli bir buton sütunu olduğundan emin ol
            if (dgvTumDersler.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dgvTumDersler.Columns[e.ColumnIndex].Name == "colEkle")
            {
                // Kullanıcının seçili olup olmadığını kontrol et
                if (_seciliKullaniciID == -1 || string.IsNullOrWhiteSpace(_seciliKullaniciTipi))
                {
                    MessageBox.Show("Lütfen önce bir kullanıcı tipi ve kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // *** BURADA DEĞİŞİKLİK YAPIYORUZ: VERİYE DataBoundItem ÜZERİNDEN ERİŞİM ***
                // Seçili satırın bağlı olduğu veri nesnesini (DataRowView) al
                if (dgvTumDersler.Rows[e.RowIndex].DataBoundItem is DataRowView rowView)
                {
                    int dersID = -1;
                    string dersAdi = string.Empty;

                    // DataRowView içindeki DataRow'dan DersID'yi güvenli bir şekilde al
                    if (rowView.Row.Table.Columns.Contains("DersID") && rowView.Row["DersID"] != DBNull.Value)
                    {
                        dersID = Convert.ToInt32(rowView.Row["DersID"]);
                    }
                    else
                    {
                        MessageBox.Show("Ders ID'si alınamadı veya geçersiz (DersID sütunu yok/boş).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // DataRowView içindeki DataRow'dan DersAdı'nı güvenli bir şekilde al
                    if (rowView.Row.Table.Columns.Contains("DersAdi") && rowView.Row["DersAdi"] != DBNull.Value)
                    {
                        dersAdi = rowView.Row["DersAdi"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Ders Adı alınamadı veya geçersiz (DersAdi sütunu yok/boş).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ders ID'si ve Ders Adı başarıyla alındı, şimdi onay mesajını göster
                    DialogResult dialogResult = MessageBox.Show(
                        $"{dersAdi} dersini seçili kullanıcıya atamak istediğinize emin misiniz?",
                        "Ders Atama Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            AssignDersToKullanici(_seciliKullaniciID, dersID, _seciliKullaniciTipi);
                            MessageBox.Show($"{dersAdi} dersi başarıyla atandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDersListings(_seciliKullaniciID, _seciliKullaniciTipi);
                            return; // Bu satır burada kalmalı
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ders atanırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seçili satırın veri içeriği bulunamadı veya geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            }
       
        // --- Metot: Kullanıcıya Ders Atama (Dinamik Tablo Seçimi ile) ---
        private void AssignDersToKullanici(int kullaniciID, int dersID, string kullaniciTipi)
        {
            string atamaTablosu = string.Empty;
            if (kullaniciTipi == "Öğrenciler")
            {
                atamaTablosu = "OgrenciDers";
            }
            else if (kullaniciTipi == "Öğretmenler")
            {
                atamaTablosu = "OgretmenDers";
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı tipi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO {atamaTablosu} (KullaniciID, DersID) VALUES (@KullaniciID, @DersID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    command.Parameters.AddWithValue("@DersID", dersID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Ders başarıyla atandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDersListings(kullaniciID, kullaniciTipi); // Ders listelerini yeniden yükle
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Duplicate key hatası (aynı ders zaten atanmış)
                    {
                        MessageBox.Show("Bu ders zaten seçili kullanıcıya atanmış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Ders atanırken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // --- Metot: Kullanıcıdan Ders Kaldırma (Dinamik Tablo Seçimi ile) ---
        private void RemoveDersFromKullanici(int kullaniciID, int dersID, string kullaniciTipi)
        {
            string atamaTablosu = string.Empty;
            if (kullaniciTipi == "Öğrenciler")
            {
                atamaTablosu = "OgrenciDers";
            }
            else if (kullaniciTipi == "Öğretmenler")
            {
                atamaTablosu = "OgretmenDers";
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı tipi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM {atamaTablosu} WHERE KullaniciID = @KullaniciID AND DersID = @DersID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    command.Parameters.AddWithValue("@DersID", dersID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Ders başarıyla kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDersListings(kullaniciID, kullaniciTipi); // Ders listelerini yeniden yükle
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ders kaldırılırken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
