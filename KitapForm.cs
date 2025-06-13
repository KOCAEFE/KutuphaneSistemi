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
            if (File.Exists(kitapDosyaYolu))
            {
                string[] satirlar = File.ReadAllLines(kitapDosyaYolu);
                foreach (string satir in satirlar)
                {
                    Kitap kitap = Kitap.Parse(satir);
                    kitapListesi.Add(kitap);
                    listBox1.Items.Add(kitap); // ListBox'un adı buysa
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
            kitapListesi.Add(yeniKitap);
            listBox1.Items.Add(yeniKitap);
            KitaplariKaydet(); // dosyaya da yaz
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
            OduncForm odunc = new OduncForm();
            odunc.Show();
            this.Hide();
        }

        private void KitapForm_Load(object sender, EventArgs e)
        {
            KitaplariYukle();
        }
    }
}
