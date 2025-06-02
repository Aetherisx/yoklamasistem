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
    public partial class kullaniciyonetim : UserControl
    {
        private const string ConnectionString = @"Server=DESKTOP-RPNNDSK\SQLEXPRESS;Database=YoklamaTakipDB;Integrated Security=True;";
        private int _seciliKullaniciID = -1; // Düzenleme için seçilen kullanıcının ID'sini tutar
        public kullaniciyonetim()
        {
            InitializeComponent();
            SetupDataGridView(); // Sadece DataGridView ayarlarını burada yapıyoruz
            LoadKullanicilar(); // Kullanıcıları yüklüyoruz
        }
        // --- Metot: Kullanıcıları DataGridView'e Yükleme (Arama dahil) ---
        private void LoadKullanicilar(string aramaKelimesi = "")
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT KullaniciID, Ad, Soyad, KullaniciAdi, Sifre, Rol FROM Kullanicilar WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(aramaKelimesi))
                    {
                        query += " AND (Ad LIKE @arama OR Soyad LIKE @arama OR KullaniciAdi LIKE @arama OR Rol LIKE @arama)";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    if (!string.IsNullOrWhiteSpace(aramaKelimesi))
                    {
                        command.Parameters.AddWithValue("@arama", "%" + aramaKelimesi + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dataGridView1 != null)
                    {
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Kontrollerin İlk Ayarlarını Yapma Metodu ---
        private void SetupDataGridView()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = false;

                dataGridView1.Columns.Clear();

                // Veri Sütunları
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colKullaniciID", HeaderText = "ID", DataPropertyName = "KullaniciID", Visible = false });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colAd", HeaderText = "Ad", DataPropertyName = "Ad" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colSoyad", HeaderText = "Soyad", DataPropertyName = "Soyad" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colKullaniciAdi", HeaderText = "Kullanıcı Adı", DataPropertyName = "KullaniciAdi" });

                // Şifre sütunu: Burada DataGridViewPasswordCell'i doğru şekilde atıyoruz
                DataGridViewTextBoxColumn sifreColumn = new DataGridViewTextBoxColumn();
                sifreColumn.Name = "colSifre";
                sifreColumn.HeaderText = "Şifre";
                sifreColumn.DataPropertyName = "Sifre";
                sifreColumn.CellTemplate = new DataGridViewPasswordCell(); // **Bu satır önemli!**
                dataGridView1.Columns.Add(sifreColumn);

                // Rol sütunu (ComboBox olarak)
                DataGridViewComboBoxColumn rolColumn = new DataGridViewComboBoxColumn();
                rolColumn.Name = "colRol";
                rolColumn.HeaderText = "Rol";
                rolColumn.DataPropertyName = "Rol";
                rolColumn.Items.AddRange("Yönetici", "Öğretmen", "Öğrenci"); // Rolleri doldur
                dataGridView1.Columns.Add(rolColumn);

                // İşlem Buton Sütunları (SİL)
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "colSil";
                deleteButtonColumn.HeaderText = "Sil";
                deleteButtonColumn.Text = "Sil";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteButtonColumn);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan sütunun "Sil" butonu olup olmadığını kontrol et
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colSil")
            {
                // Yeni eklenen ancak henüz kaydedilmemiş bir satır değilse işlem yap
                if (e.RowIndex == dataGridView1.NewRowIndex) return;

                DataGridViewRow rowToDelete = dataGridView1.Rows[e.RowIndex];
                int kullaniciID = Convert.ToInt32(rowToDelete.Cells["colKullaniciID"].Value);
                string adSoyad = $"{rowToDelete.Cells["colAd"].Value} {rowToDelete.Cells["colSoyad"].Value}";

                DialogResult dialogResult = MessageBox.Show(
                    $"'{adSoyad}' adlı kullanıcıyı silmek istediğinize emin misiniz?",
                    "Kullanıcı Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteKullanici(kullaniciID);
                }
            }
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {

        }
        // --- Metot: Kullanıcı Ekleme ---
        private void AddKullanici(string ad, string soyad, string kullaniciAdi, string sifre, string rol)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Kullanicilar (Ad, Soyad, KullaniciAdi, Sifre, Rol) VALUES (@Ad, @Soyad, @KullaniciAdi, @Sifre, @Rol)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ad", ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre); // Şifre hash'lenmeli!
                    command.Parameters.AddWithValue("@Rol", rol);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // UNIQUE KEY hatası (KullaniciAdi zaten var)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten mevcut. Lütfen farklı bir kullanıcı adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı eklenirken bir hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // --- Metot: Kullanıcı Güncelleme ---
        private void UpdateKullanici(int id, string ad, string soyad, string kullaniciAdi, string yeniSifre, string rol)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Kullanicilar SET Ad = @Ad, Soyad = @Soyad, KullaniciAdi = @KullaniciAdi, Sifre = @Sifre, Rol = @Rol WHERE KullaniciID = @KullaniciID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ad", ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", yeniSifre); // Şifre değiştirildiyse yeni şifreyi, değişmediyse önceki şifreyi kullanır.
                    command.Parameters.AddWithValue("@Rol", rol);
                    command.Parameters.AddWithValue("@KullaniciID", id);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // UNIQUE KEY hatası (KullaniciAdi zaten var)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten mevcut. Lütfen farklı bir kullanıcı adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı güncellenirken bir hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // --- Metot: Kullanıcı Silme ---
        private void DeleteKullanici(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciID", id);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKullanicilar(); // Listeyi güncelle
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Kullanıcı silinirken bir hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Olay: Kullanıcı Ara TextBox'ı değiştiğinde (TextChanged) ---
        // txtKullaniciAra adında bir TextBox olduğunu varsayıyorum.
        private void txtKullaniciAra_TextChanged(object sender, EventArgs e)
        {
            
        }

        // --- Özel Cell Şablonu: DataGridViewPasswordCell ---
        // Şifre sütunundaki karakterleri * olarak göstermek için.
        public class DataGridViewPasswordCell : DataGridViewTextBoxCell
        {
            public DataGridViewPasswordCell() : base()
            {
                this.Style.WrapMode = DataGridViewTriState.False;
            }

            public override Type EditType
            {
                get { return typeof(DataGridViewPasswordEditingControl); }
            }

            public override Type ValueType
            {
                get { return typeof(string); }
            }

            public override object DefaultNewRowValue
            {
                get { return string.Empty; }
            }
        }

        // --- Özel Editing Control: DataGridViewPasswordEditingControl ---
        // Şifre sütunu düzenlenirken TextBox'ın PasswordChar özelliğini ayarlar.
        class DataGridViewPasswordEditingControl : DataGridViewTextBoxEditingControl
        {
            private bool _passwordCharSet = false;

            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                if (!_passwordCharSet)
                {
                    this.PasswordChar = '*';
                    _passwordCharSet = true;
                }
            }


            protected override void OnParentBackColorChanged(EventArgs e)
            {
                base.OnParentBackColorChanged(e);
                if (this.PasswordChar != '*')
                {
                    this.PasswordChar = '*';
                }
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Yeni bir satır ekleniyorsa
            if (e.RowIndex == dataGridView1.NewRowIndex - 1 && e.RowIndex >= 0)
            {
                DataGridViewRow newRow = dataGridView1.Rows[e.RowIndex];

                string ad = newRow.Cells["colAd"].Value?.ToString()?.Trim();
                string soyad = newRow.Cells["colSoyad"].Value?.ToString()?.Trim();
                string kullaniciAdi = newRow.Cells["colKullaniciAdi"].Value?.ToString()?.Trim();
                string sifre = newRow.Cells["colSifre"].Value?.ToString();
                string rol = newRow.Cells["colRol"].Value?.ToString();

                // SADECE tüm alanlar boşsa uyarı ver ve satırı sil
                // VEYA sadece kritik olan KullaniciAdi ve Sifre gibi alanlar boşsa.
                // Kullanıcının bir alanı boş bırakıp diğerini doldurmaya devam etmesine izin vermeliyiz.

                // Örnek: Eğer KullaniciAdi veya Sifre boşsa, bu bir problemdir.
                // Ad ve Soyad'ı başlangıçta boş bırakabilir.
                if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
                {
                    // Eğer kullanıcı ID sütunu boş değilse ve satır tamamsa, uyarı vermeye gerek yok
                    // Çünkü bu zaten veritabanında olmayan yeni bir satır.
                    // Bu uyarıyı daha çok AddKullanici metodunun içinde yapmak daha mantıklı olabilir.

                    // Şimdilik bu kontrolü burada tutalım ama mesajı biraz daha kullanıcı dostu yapalım.
                    // Ve satırı hemen silmeyelim, kullanıcının doldurmaya devam etmesine izin verelim.
                    // Ancak, kullanıcı eğer yeni satırı tamamen boş bırakıp çıkarsa,
                    // CellEndEdit tekrar tetiklenir ve bu boş satırı eklemeye çalışır, bu da hataya neden olur.
                    // Bu durumda, sadece AddKullanici metodunda kontrol yapmak daha iyi olur.

                    // Bu bloğu şimdilik kaldırmanı öneririm:
                    // MessageBox.Show("Yeni kullanıcı eklerken Kullanıcı Adı ve Şifre alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // return; // AddKullanici'ye gitmesini engelle
                }

                // Eğer gerçekten yeni bir satır eklenmek isteniyorsa ve temel alanlar doluysa
                if (!string.IsNullOrWhiteSpace(ad) && !string.IsNullOrWhiteSpace(soyad) &&
                    !string.IsNullOrWhiteSpace(kullaniciAdi) && !string.IsNullOrWhiteSpace(sifre) &&
                    !string.IsNullOrWhiteSpace(rol))
                {
                    AddKullanici(ad, soyad, kullaniciAdi, sifre, rol);
                    LoadKullanicilar(); // Yalnızca ekleme başarılı olursa veya tüm alanlar doluysa yükle
                }
                else
                {
                    // Eğer yeni satır ekleniyor ama tüm zorunlu alanlar hala boşsa,
                    // DataGridView'in sonuna boş bir satırın eklenmesini engellemek için bir şey yapmayalım.
                    // Kullanıcı tamamladığında CellEndEdit tekrar çalışır ve ekleme yapar.
                    // Kullanıcı boş bir satır bırakıp giderse, o satır gözden kaybolur (çünkü DataGridView refresh olur).
                    // Bu durum yönetilmesi gereken bir kenar durumdur.
                }
            }
            // Mevcut bir satır düzenleniyorsa - burası sorun çıkarmıyor gibi
            else if (e.RowIndex >= 0 && e.RowIndex != dataGridView1.NewRowIndex)
            {
                DataGridViewRow editedRow = dataGridView1.Rows[e.RowIndex];

                int kullaniciID = Convert.ToInt32(editedRow.Cells["colKullaniciID"].Value);
                string ad = editedRow.Cells["colAd"].Value?.ToString()?.Trim();
                string soyad = editedRow.Cells["colSoyad"].Value?.ToString()?.Trim();
                string kullaniciAdi = editedRow.Cells["colKullaniciAdi"].Value?.ToString()?.Trim();
                string sifre = editedRow.Cells["colSifre"].Value?.ToString();
                string rol = editedRow.Cells["colRol"].Value?.ToString();

                // Güncelleme için de boş kontrolü:
                if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                    string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(rol))
                {
                    MessageBox.Show("Ad, Soyad, Kullanıcı Adı ve Rol alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadKullanicilar(); // Değişikliği geri almak için listeyi yeniden yükle
                    return;
                }

                UpdateKullanici(kullaniciID, ad, soyad, kullaniciAdi, sifre, rol);
                LoadKullanicilar();
            }
        }
    }
}
