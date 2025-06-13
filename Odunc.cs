using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    internal class Odunc
    {
        public Kitap Kitap { get; set; }
        public Uye Uye { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime IadeTarihi { get; set; }

        public Odunc(Kitap kitap, Uye uye, DateTime alis, DateTime iade)
        {
            Kitap = kitap;
            Uye = uye;
            AlisTarihi = alis;
            IadeTarihi = iade;
        }

        public override string ToString()
        {
            return $"{Uye.Ad} {Uye.Soyad} → {Kitap.KitapAdi} | {AlisTarihi:dd.MM.yyyy} - {IadeTarihi:dd.MM.yyyy}";
        }

        public string ToFileString()
        {
            return $"{Uye.UyeId}|{Kitap.KitapId}|{AlisTarihi:yyyy-MM-dd}|{IadeTarihi:yyyy-MM-dd}";
        }

        public static Odunc Parse(string line, List<Uye> uyeler, List<Kitap> kitaplar)
        {
            var parts = line.Split('|');
            int uyeId = int.Parse(parts[0]);
            int kitapId = int.Parse(parts[1]);
            DateTime alis = DateTime.Parse(parts[2]);
            DateTime iade = DateTime.Parse(parts[3]);

            var uye = uyeler.FirstOrDefault(u => u.UyeId == uyeId);
            var kitap = kitaplar.FirstOrDefault(k => k.KitapId == kitapId);

            return new Odunc(kitap, uye, alis, iade);
        }
    }
}
