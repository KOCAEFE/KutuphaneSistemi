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
        public OduncForm()
        {
            InitializeComponent();
        }
        private List<Kitap> kitaplar;
        private List<Uye> uyeler;
        private List<Odunc> oduncler = new List<Odunc>();
        private const string oduncDosyaYolu = "oduncler.txt";

        public partial class OduncForm : Form
        {
            private List<Kitap> kitaplar;
            private List<Uye> uyeler;
            private List<Odunc> oduncler = new List<Odunc>();
            private const string oduncDosyaYolu = "oduncler.txt";

            public OduncForm(List<Kitap> kitaplar, List<Uye> uyeler)
            {
                InitializeComponent(); // bu satır ilk satır olmalı!
                this.kitaplar = kitaplar;
                this.uyeler = uyeler;
            }
        }








        private void OduncForm_Load(object sender, EventArgs e)
        {
           listBox1.Items.AddRange(kitaplar.ToArray());
            listBox2.Items.AddRange(uyeler.ToArray());
            OduncleriYukle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Kitap seciliKitap &&
       listBox2.SelectedItem is Uye seciliUye)
            {
                DateTime alis = dateTimePicker1.Value.Date;
                DateTime iade = dateTimePicker2.Value.Date;

                Odunc yeni = new Odunc(seciliKitap, seciliUye, alis, iade);
                oduncListesi.Add(yeni);
                listBox3.Items.Add(yeni);
                OduncleriKaydet();
            }
        }
    }
}
