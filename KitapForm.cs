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
    public partial class KitapForm : Form
    {
        public KitapForm()
        {
            InitializeComponent();
        }
        private List<Kitap> kitapListesi = new List<Kitap>();
        private const string kitapDosyaYolu = "kitaplar.txt";
        private void KitaplariKaydet()
        {
            File.WriteAllLines(kitapDosyaYolu, kitapListesi.Select(k => k.ToFileString()));
        }
        private void KitaplariYukle()
        {
            listBox1.Items.Clear();
            Form1.kitaplar.Clear();
            if (File.Exists("kitaplar.txt"))
            {
                var satirlar = File.ReadAllLines("kitaplar.txt");
                foreach (var satir in satirlar)
                {
                    var kitap = Kitap.Parse(satir);
                    listBox1.Items.Add(kitap);
                    Form1.kitaplar.Add(kitap);
                }
            }
        }

        private void btnKitapKaydet_Click(object sender, EventArgs e)
        {
            string yazar = txtYazar.Text;
            string kitapAdi = txtKitapAd.Text;
            string yayinEvi = txtYayinevi.Text;
            int sayfa = int.Parse(txtSayfaSayisi.Text);

            Kitap yeniKitap = new Kitap(yazar, kitapAdi, yayinEvi, sayfa);
            listBox1.Items.Add(yeniKitap);
            Form1.kitaplar.Add(yeniKitap);
            File.AppendAllLines("kitaplar.txt", new[] { yeniKitap.ToFileString() });
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Kitap seciliKitap)
            {
                kitapListesi.Remove(seciliKitap);
                listBox1.Items.Remove(seciliKitap);
                KitaplariKaydet(); // güncel halini dosyaya yaz
            }
        }

        private void btnMenuSales_Click(object sender, EventArgs e)
        {
            KitapForm kitap = new KitapForm();
            kitap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeForm uye = new UyeForm();
            uye.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OduncForm odunc = new OduncForm(Form1.kitaplar, Form1.uyeler);
            odunc.Show();
            this.Hide();
        }

        private void KitapForm_Load(object sender, EventArgs e)
        {
            KitaplariYukle();
        }
    }
}
