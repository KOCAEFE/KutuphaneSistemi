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
        private static int _sonrakiId = 1;

        public int KitapId { get; }
        public string Yazar { get; set; }
        public string KitapAdi { get; set; }
        public string YayinEvi { get; set; }
        public int SayfaSayisi { get; set; }

        public Kitap(string yazar, string kitapAdi, string yayinEvi, int sayfaSayisi)
        {
            this.KitapId = _sonrakiId++;
            this.Yazar = yazar;
            this.KitapAdi = kitapAdi;
            this.YayinEvi = yayinEvi;
            this.SayfaSayisi = sayfaSayisi;
        }

        public Kitap(int kitapId, string yazar, string kitapAdi, string yayinEvi, int sayfaSayisi)
        {
            this.KitapId = kitapId;
            this.Yazar = yazar;
            this.KitapAdi = kitapAdi;
            this.YayinEvi = yayinEvi;
            this.SayfaSayisi = sayfaSayisi;

            if (kitapId >= _sonrakiId)
                _sonrakiId = kitapId + 1;
        }

        public string ToFileString()
        {
            return $"{KitapId}|{Yazar}|{KitapAdi}|{YayinEvi}|{SayfaSayisi}";
        }

        public static Kitap Parse(string line)
        {
            string[] parts = line.Split('|');
            return new Kitap(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                parts[3],
                int.Parse(parts[4])
            );
        }

        public override string ToString()
        {
            return $"{KitapAdi} ({Yazar}) - {YayinEvi} - {SayfaSayisi} syf";
        }
    }
}
