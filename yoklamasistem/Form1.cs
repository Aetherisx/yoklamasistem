using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace yoklamasistem
{
    public partial class giris : Form
    {
        private const string ConnectionString = @"Server=DESKTOP-RPNNDSK\SQLEXPRESS;Database=YoklamaTakipDB;Integrated Security=True;";
        public giris()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; // Enter tuþu ile giriþ
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(21, 101, 192);
        }

        private void giris_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtUsername.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Kullanýcý adý ve þifre boþ býrakýlamaz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT KullaniciID, Ad, Soyad, Rol FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre AND Aktif = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            int kullaniciID = reader.GetInt32(reader.GetOrdinal("KullaniciID"));
                            string ad = reader.GetString(reader.GetOrdinal("Ad"));
                            string soyad = reader.GetString(reader.GetOrdinal("Soyad"));
                            string rol = reader.GetString(reader.GetOrdinal("Rol"));

                            MessageBox.Show($"Hoþ geldiniz, {ad} {soyad} ({rol})!", "Giriþ Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Rol kontrolüne göre farklý formlarý aç
                            Form nextForm = null;
                            switch (rol)
                            {
                                case "Yönetici":
                                    nextForm = new yoneticipanel(kullaniciID, ad, soyad); // Yönetici paneli
                                    break;
                                case "Öðretmen":
                                    nextForm = new ogretmen(kullaniciID, ad, soyad, kullaniciID); // Öðretmen paneli
                                    break;
                                case "Öðrenci":
                                    nextForm = new ogrenci(kullaniciID, ad, soyad); // Öðrenci paneli
                                    break;
                                default:
                                    MessageBox.Show("Geçersiz rol bilgisi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }

                            if (nextForm != null)
                            {
                                nextForm.Show(); // Ýlgili paneli göster
                                this.Hide(); // Giriþ formunu gizle
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanýcý adý veya þifre yanlýþ.", "Giriþ Baþarýsýz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSifre.Clear();
                            txtUsername.Focus();
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Veritabaný baðlantý veya sorgu hatasý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}