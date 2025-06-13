using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class OduncVermeForm : Form
    {
        private List<Kitap> kitaplar;
        private List<Uye> uyeler;
        private List<OduncIslem> oduncIslemler;

        public OduncVermeForm(List<Kitap> kitaplar, List<Uye> uyeler, List<OduncIslem> oduncIslemler)
        {
            InitializeComponent();
            this.kitaplar = kitaplar;
            this.uyeler = uyeler;
            this.oduncIslemler = oduncIslemler;
        }

        private void OduncVermeForm_Load(object sender, EventArgs e)
        {
            // Kitapları ListBox'a yükle
            foreach (var kitap in kitaplar)
            {
                if (kitap.Durum == "Rafta")
                {
                    lstKitaplar.Items.Add($"{kitap.Ad} - {kitap.Yazar}");
                }
            }

            // Üyeleri ListBox'a yükle
            foreach (var uye in uyeler)
            {
                lstUyeler.Items.Add($"{uye.Ad} {uye.Soyad}");
            }

            // DateTimePicker'ları ayarla
            dtpOduncAlmaTarihi.Value = DateTime.Now;
            dtpIadeTarihi.Value = DateTime.Now.AddDays(15);
        }

        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            if (lstKitaplar.SelectedIndex == -1 || lstUyeler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kitap ve üye seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string seciliKitap = lstKitaplar.SelectedItem.ToString();
            string seciliUye = lstUyeler.SelectedItem.ToString();

            // Seçili kitabı bul
            Kitap kitap = kitaplar.FirstOrDefault(k => $"{k.Ad} - {k.Yazar}" == seciliKitap);
            if (kitap == null)
            {
                MessageBox.Show("Kitap bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçili üyeyi bul
            Uye uye = uyeler.FirstOrDefault(u => $"{u.Ad} {u.Soyad}" == seciliUye);
            if (uye == null)
            {
                MessageBox.Show("Üye bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ödünç işlemi oluştur
            OduncIslem oduncIslem = new OduncIslem
            {
                Kitap = kitap,
                Uye = uye,
                OduncAlmaTarihi = dtpOduncAlmaTarihi.Value,
                IadeTarihi = dtpIadeTarihi.Value,
                Durum = "Ödünç Verildi"
            };

            // Kitabın durumunu güncelle
            kitap.Durum = "Ödünç Verildi";

            // Ödünç işlemini listeye ekle
            oduncIslemler.Add(oduncIslem);

            // ListBox'ları güncelle
            lstKitaplar.Items.RemoveAt(lstKitaplar.SelectedIndex);

            MessageBox.Show("Ödünç verme işlemi başarıyla tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 