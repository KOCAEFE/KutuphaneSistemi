using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class OduncForm : Form
    {
        private List<Kitap> kitaplar;
        private List<Uye> uyeler;
        private List<Odunc> oduncler = new List<Odunc>();
        private const string oduncDosyaYolu = "oduncler.txt";
        private const decimal GUNLUK_UCRET = 1.0m; // Günlük ücret 1 TL

        public OduncForm(List<Kitap> kitaplar, List<Uye> uyeler)
        {
            InitializeComponent();
            this.kitaplar = kitaplar;
            this.uyeler = uyeler;
            listBox3.DrawMode = DrawMode.OwnerDrawFixed;
            listBox3.DrawItem += ListBox3_DrawItem;
        }

        private void ListBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            if (listBox3.Items[e.Index] is Odunc odunc)
            {
                string text = odunc.ToString();
                if (odunc.IadeTarihi < DateTime.Now)
                {
                    // Gecikmiş kitaplar için ücret hesapla
                    int gecikmeGunu = (DateTime.Now - odunc.IadeTarihi).Days;
                    decimal ucret = gecikmeGunu * GUNLUK_UCRET;
                    text += $" [Gecikme: {gecikmeGunu} gün, Ücret: {ucret:C}]";
                    e.Graphics.DrawString(text, e.Font, Brushes.Red, e.Bounds);
                }
                else
                {
                    e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);
                }
            }
            e.DrawFocusRectangle();
        }

        private void OduncForm_Load(object sender, EventArgs e)
        {
            KitaplariGuncelle();
            UyeleriGuncelle();
            OduncleriYukle();
        }

        private void KitaplariGuncelle()
        {
            listBox1.Items.Clear();
            if (Form1.kitaplar != null)
            {
                // Sadece ödünç verilmemiş kitapları göster
                var oduncVerilmisKitapIdleri = oduncler.Select(o => o.Kitap.KitapId).ToList();
                var müsaitKitaplar = Form1.kitaplar.Where(k => !oduncVerilmisKitapIdleri.Contains(k.KitapId));
                listBox1.Items.AddRange(müsaitKitaplar.ToArray());
            }
        }

        private void UyeleriGuncelle()
        {
            listBox2.Items.Clear();
            Form1.uyeler.Clear();
            if (File.Exists("uyeler.txt"))
            {
                var satirlar = File.ReadAllLines("uyeler.txt");
                foreach (var satir in satirlar)
                {
                    var uye = Uye.Parse(satir);
                    listBox2.Items.Add(uye);
                    Form1.uyeler.Add(uye);
                }
            }
        }

        private void OduncleriYukle()
        {
            listBox3.Items.Clear();
            oduncler.Clear();
            if (File.Exists("oduncler.txt"))
            {
                var satirlar = File.ReadAllLines("oduncler.txt");
                foreach (var satir in satirlar)
                {
                    var odunc = Odunc.Parse(satir, Form1.uyeler, Form1.kitaplar);
                    oduncler.Add(odunc);
                    listBox3.Items.Add(odunc);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Kitap seciliKitap &&
                listBox2.SelectedItem is Uye seciliUye)
            {
                DateTime alis = dateTimePicker1.Value.Date;
                DateTime iade = dateTimePicker2.Value.Date;

                if (iade <= alis)
                {
                    MessageBox.Show("İade tarihi alış tarihinden sonra olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Odunc yeni = new Odunc(seciliKitap, seciliUye, alis, iade);
                oduncler.Add(yeni);
                listBox3.Items.Add(yeni);
                
                // Dosyaya ekle
                using (StreamWriter sw = File.AppendText(oduncDosyaYolu))
                {
                    sw.WriteLine(yeni.ToFileString());
                }

                // Kitapları güncelle
                KitaplariGuncelle();

                MessageBox.Show("Kitap ödünç verme işlemi başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir kitap ve bir üye seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIadeEt_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem is Odunc seciliOdunc)
            {
                if (seciliOdunc.IadeTarihi < DateTime.Now)
                {
                    int gecikmeGunu = (DateTime.Now - seciliOdunc.IadeTarihi).Days;
                    decimal ucret = gecikmeGunu * GUNLUK_UCRET;
                    var result = MessageBox.Show($"Bu kitap {gecikmeGunu} gün gecikmiş. Ödenmesi gereken ücret: {ucret:C}\nİade işlemine devam etmek istiyor musunuz?", 
                        "Gecikme Ücreti", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    
                    if (result != DialogResult.Yes)
                        return;
                }

                // Ödünç listesinden kaldır
                oduncler.Remove(seciliOdunc);
                listBox3.Items.Remove(seciliOdunc);

                // Dosyayı güncelle
                File.WriteAllLines(oduncDosyaYolu, oduncler.Select(o => o.ToFileString()));

                // Kitapları güncelle
                KitaplariGuncelle();

                MessageBox.Show("Kitap iade işlemi başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen iade edilecek kitabı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeForm uye = new UyeForm();
            uye.Show();
            this.Hide();
        }

        private void btnMenuSales_Click(object sender, EventArgs e)
        {
            KitapForm kitap = new KitapForm();
            kitap.Show();
            this.Hide();
        }
    }
}
