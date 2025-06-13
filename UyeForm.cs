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
    public partial class UyeForm : Form
    {
        public UyeForm()
        {
            InitializeComponent();
        }
        public List<Uye> uyeListesi = new List<Uye>();
        public const string uyeDosyaYolu = "uyeler.txt";
        public void UyeleriKaydet()
        {
            File.WriteAllLines(uyeDosyaYolu, uyeListesi.Select(u => u.ToFileString()));
        }

        public void UyeleriYukle()
        {
            if (File.Exists(uyeDosyaYolu))
            {
                string[] satirlar = File.ReadAllLines(uyeDosyaYolu);
                foreach (string satir in satirlar)
                {
                    Uye uye = Uye.Parse(satir);
                    uyeListesi.Add(uye);
                    listBox1.Items.Add(uye); // listBox’un ismi buysa
                }
            }
        }


        private void btnUyeKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string tel = txtTel.Text;
            string sehir = txtSehir.Text;

            Uye yeni = new Uye(ad, soyad, tel, sehir);
            uyeListesi.Add(yeni);
            listBox1.Items.Add(yeni);
            UyeleriKaydet();
        }

        private void btnUyeSil_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Seçili öğeyi sil
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Silmek için bir kitap seçin.");
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

        private void UyeForm_Load(object sender, EventArgs e)
        {
            UyeleriYukle();
        }
    }
}
