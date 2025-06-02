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
            this.AcceptButton = btnLogin; // Enter tu�u ile giri�
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
                MessageBox.Show("Kullan�c� ad� ve �ifre bo� b�rak�lamaz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                            MessageBox.Show($"Ho� geldiniz, {ad} {soyad} ({rol})!", "Giri� Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Rol kontrol�ne g�re farkl� formlar� a�
                            Form nextForm = null;
                            switch (rol)
                            {
                                case "Y�netici":
                                    nextForm = new yoneticipanel(kullaniciID, ad, soyad); // Y�netici paneli
                                    break;
                                case "��retmen":
                                    nextForm = new ogretmen(kullaniciID, ad, soyad, kullaniciID); // ��retmen paneli
                                    break;
                                case "��renci":
                                    nextForm = new ogrenci(kullaniciID, ad, soyad); // ��renci paneli
                                    break;
                                default:
                                    MessageBox.Show("Ge�ersiz rol bilgisi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }

                            if (nextForm != null)
                            {
                                nextForm.Show(); // �lgili paneli g�ster
                                this.Hide(); // Giri� formunu gizle
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullan�c� ad� veya �ifre yanl��.", "Giri� Ba�ar�s�z", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSifre.Clear();
                            txtUsername.Focus();
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Veritaban� ba�lant� veya sorgu hatas�: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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