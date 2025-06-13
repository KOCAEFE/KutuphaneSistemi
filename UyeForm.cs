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
    public partial class UyeForm : Form
    {
        public UyeForm()
        {
            InitializeComponent();
        }

        private void btnUyeKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad=txtSoyad.Text;
            string tel=txtTel.Text;
            string sehir=txtSehir.Text;
            Uye yeniUye=new Uye(ad,soyad, tel,sehir);
            listBox1.Items.Add($"{yeniUye.ad}-{yeniUye.soyad}-{yeniUye.tel}-{yeniUye.sehir}");
        }
    }
}
