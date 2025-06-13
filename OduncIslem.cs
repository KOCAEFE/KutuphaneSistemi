using System;

namespace Kutuphane
{
    public class OduncIslem
    {
        public Kitap Kitap { get; set; }
        public Uye Uye { get; set; }
        public DateTime OduncAlmaTarihi { get; set; }
        public DateTime IadeTarihi { get; set; }
        public string Durum { get; set; }
    }
} 