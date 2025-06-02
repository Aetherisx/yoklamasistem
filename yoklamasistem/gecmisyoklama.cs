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
    public partial class gecmisyoklama : Form
    {
        private const string ConnectionString = @"Server=DESKTOP-RPNNDSK\SQLEXPRESS;Database=YoklamaTakipDB;Integrated Security=True;";
        private int _ogretmenID; // Giriş yapan öğretmenin ID'si
        public gecmisyoklama(int ogretmenID)
        {
            InitializeComponent();
            _ogretmenID = ogretmenID; // Öğretmen ID'sini sakla

            // GEÇİCİ KOD: Öğretmen ID'sini kontrol etmek için
            MessageBox.Show("Giriş yapan Öğretmen ID: " + _ogretmenID.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // GEÇİCİ KOD SONU

            this.Load += gecmisyoklama_Load;
            btnSearch.Click += btnSearch_Click;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? startDate = dtpStartDate.Value.Date;
            DateTime? endDate = dtpEndDate.Value.Date;

            int selectedDersID = -1; // Varsayılan olarak tüm dersler

            if (cmbFilterClass.SelectedValue != null && cmbFilterClass.SelectedValue != DBNull.Value)
            {
                // cmbFilterClass.SelectedValue bir DataRowView mi diye kontrol et
                if (cmbFilterClass.SelectedValue is DataRowView drv)
                {
                    selectedDersID = Convert.ToInt32(drv["DersID"]);
                }
                else
                {
                    // Değilse (yani doğrudan int veya int'e dönüştürülebilir bir object ise), direkt dönüştür
                    selectedDersID = Convert.ToInt32(cmbFilterClass.SelectedValue);
                }
            }

            LoadAttendanceHistory(startDate, endDate, selectedDersID);
        }

        private void gecmisyoklama_Load(object sender, EventArgs e)
        {
            LoadDerslerToFilterComboBox(); // cmbFilterClass'a dersleri yükle
            SetupDataGridView();          // dgvAttendanceHistory sütunlarını ayarla

            // ComboBox'ı "-- Tüm Dersler --" varsayılan seçeneğiyle başlat
            cmbFilterClass.SelectedIndex = -1; // Hiçbir öğeyi seçmeyin
            cmbFilterClass.Text = "-- Tüm Dersler --"; // Varsayılan metni göster

            // Başlangıçta tüm yoklamaları listele
            LoadAttendanceHistory(null, null, -1); // Başlangıçta tüm dersler ve tüm tarih aralığı
        }
        private void LoadDerslerToFilterComboBox()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT d.DersID, d.DersAdi
                        FROM Dersler d
                        JOIN OgretmenDers od ON d.DersID = od.DersID
                        WHERE od.KullaniciID = @OgretmenID
                        ORDER BY d.DersAdi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OgretmenID", _ogretmenID);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // "Tüm Dersler" seçeneğini DataTable'a ekle
                    DataRow allDerslerRow = dt.NewRow();
                    allDerslerRow["DersID"] = -1; // Özel bir değer (örneğin -1) tüm dersleri temsil etsin
                    allDerslerRow["DersAdi"] = "-- Tüm Dersler --";
                    dt.Rows.InsertAt(allDerslerRow, 0); // En başa ekle

                    cmbFilterClass.DataSource = dt;
                    cmbFilterClass.DisplayMember = "DersAdi";
                    cmbFilterClass.ValueMember = "DersID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SetupDataGridView()
        {
            // DataGridView'i temizle
            dgvAttendanceHistory.Columns.Clear();
            dgvAttendanceHistory.AutoGenerateColumns = false; // Otomatik sütun oluşturmayı kapat

            // Sütunları tanımla
            dgvAttendanceHistory.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colYoklamaID", HeaderText = "Yoklama ID", DataPropertyName = "YoklamaID", Visible = false });
            dgvAttendanceHistory.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colTarih", HeaderText = "Tarih", DataPropertyName = "Tarih", ReadOnly = true }); dgvAttendanceHistory.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colDersAdi", HeaderText = "Ders Adı", DataPropertyName = "DersAdi", ReadOnly = true });
            dgvAttendanceHistory.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colToplamOgrenci", HeaderText = "Toplam Öğrenci", DataPropertyName = "ToplamOgrenci", ReadOnly = true });
            dgvAttendanceHistory.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colGelenOgrenci", HeaderText = "Katılım", DataPropertyName = "GelenOgrenci", ReadOnly = true });
            dgvAttendanceHistory.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colDevamsizOgrenci", HeaderText = "Devamsız", DataPropertyName = "DevamsizOgrenci", ReadOnly = true });

            // "İşlemler" sütununu ekle (Görüntüle butonu için)
            DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
            viewButtonColumn.Name = "colIslemler";
            viewButtonColumn.HeaderText = "İşlemler";
            viewButtonColumn.Text = "Görüntüle";
            viewButtonColumn.UseColumnTextForButtonValue = true; // Buton üzerinde "Görüntüle" yazsın
            dgvAttendanceHistory.Columns.Add(viewButtonColumn);

            // Buton tıklama olayını bağla
            dgvAttendanceHistory.CellContentClick += dgvAttendanceHistory_CellContentClick;
        }
        private void LoadAttendanceHistory(DateTime? startDate, DateTime? endDate, int dersID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    y.YoklamaID,
                    y.Tarih, -- DEĞİŞTİ: YoklamaTarihi yerine Tarih
                    d.DersAdi,
                    COUNT(ydet.OgrenciID) AS ToplamOgrenci,
                    SUM(CASE WHEN ydet.Durum = 'Geldi' THEN 1 ELSE 0 END) AS GelenOgrenci,
                    SUM(CASE WHEN ydet.Durum = 'Gelmedi' THEN 1 ELSE 0 END) AS DevamsizOgrenci
                FROM Yoklamalar y
                JOIN Dersler d ON y.DersID = d.DersID
                LEFT JOIN YoklamaDetay ydet ON y.YoklamaID = ydet.YoklamaID
                WHERE y.OgretmenID = @OgretmenID";

                    if (startDate.HasValue)
                    {
                        query += " AND y.Tarih >= @StartDate"; // DEĞİŞTİ
                    }
                    if (endDate.HasValue)
                    {
                        query += " AND y.Tarih <= @EndDate"; // DEĞİŞTİ
                    }
                    if (dersID != -1)
                    {
                        query += " AND y.DersID = @DersID";
                    }

                    query += " GROUP BY y.YoklamaID, y.Tarih, d.DersAdi ORDER BY y.Tarih DESC"; // DEĞİŞTİ

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OgretmenID", _ogretmenID);

                    if (startDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.Value.Date);
                    }
                    if (endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@EndDate", endDate.Value.Date);
                    }
                    if (dersID != -1)
                    {
                        command.Parameters.AddWithValue("@DersID", dersID);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAttendanceHistory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yoklama geçmişi yüklenirken hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAttendanceHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan sütunun "İşlemler" butonu sütunu olup olmadığını kontrol et
            if (e.ColumnIndex == dgvAttendanceHistory.Columns["colIslemler"].Index && e.RowIndex >= 0)
            {
                // Tıklanan satırın YoklamaID'sini al
                int yoklamaID = Convert.ToInt32(dgvAttendanceHistory.Rows[e.RowIndex].Cells["colYoklamaID"].Value);
                string dersAdi = dgvAttendanceHistory.Rows[e.RowIndex].Cells["colDersAdi"].Value.ToString();
                DateTime yoklamaTarihi = Convert.ToDateTime(dgvAttendanceHistory.Rows[e.RowIndex].Cells["colTarih"].Value);

                // Yoklama detaylarını gösterecek yeni bir form aç
                // Örneğin: YoklamaDetayGoster formuna YoklamaID, DersAdı ve Tarihi gönderilebilir.
                // Eğer böyle bir formunuz yoksa, önce oluşturmanız gerekir.
                // MessageBox.Show($"Yoklama ID: {yoklamaID} için detayları görüntüle", "Detay Görüntüle");

                // Örnek: YoklamaDetayGoster adında yeni bir form oluşturduğunuzu varsayalım
                // YoklamaDetayGoster detayForm = new YoklamaDetayGoster(yoklamaID, dersAdi, yoklamaTarihi);
                // detayForm.ShowDialog();
            }
        }
    }
}
