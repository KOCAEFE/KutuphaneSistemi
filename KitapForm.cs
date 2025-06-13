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
    public partial class KitapForm : Form
    {
        public KitapForm()
        {
            InitializeComponent();
        }

        private void btnKitapKaydet_Click(object sender, EventArgs e)
        {
            string yazar=txtYazar.Text;
            string kitapAdi = txtKitapAd.Text;
            string yayinEvi=txtYayinevi.Text;
            if (!int.TryParse(txtSayfaSayisi.Text, out int sayfaSayisi))
            {
                MessageBox.Show("sayfa sayisi sayi olmalıdır");
                return;

            }
            Kitap yeniKitap = new Kitap(yazar, kitapAdi, yayinEvi, sayfaSayisi);
            listBox1.Items.Add($"{yeniKitap.kitapId} - {yeniKitap.kitapAdi} ({yeniKitap.yazar}) - {yeniKitap.sayfaSayisi} syf - {yeniKitap.yayinevi}");
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
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
    }
}
