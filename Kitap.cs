using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    internal class Kitap
    {
        public int kitapId { get; }
        public string yazar { get;set; }
        public string kitapAdi { get; set; }
        public string yayinevi { get; set; }
        public int sayfaSayisi  { get; set; }
        private static int sonrakiKitapId = 1;

        public Kitap(string yazar,string kitapAdı,string yayınevi,int sayfaSayisi)
        {
            this.kitapId = sonrakiKitapId++;
            this.yazar = yazar;
            this.kitapAdi = kitapAdı;
            this.yayinevi = yayınevi;
            this.sayfaSayisi= sayfaSayisi;
        }
    }
}
