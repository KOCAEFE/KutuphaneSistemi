using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public class Uye
    {
        private static int _sonrakiId = 1;

        public int UyeId { get; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Sehir { get; set; }

        public Uye(string ad, string soyad, string telefon, string sehir)
        {
            this.UyeId = _sonrakiId++;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Telefon = telefon;
            this.Sehir = sehir;
        }

        public Uye(int id, string ad, string soyad, string telefon, string sehir)
        {
            this.UyeId = id;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Telefon = telefon;
            this.Sehir = sehir;

            if (id >= _sonrakiId)
                _sonrakiId = id + 1;
        }

        public string ToFileString()
        {
            return $"{UyeId}|{Ad}|{Soyad}|{Telefon}|{Sehir}";
        }

        public static Uye Parse(string line)
        {
            string[] parts = line.Split('|');
            return new Uye(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                parts[3],
                parts[4]
            );
        }

        public override string ToString()
        {
            return $"{UyeId} - {Ad} {Soyad} - {Telefon} - {Sehir}";
        }
    }
}
