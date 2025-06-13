using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public class Uye
    {
        public int uyeId {  get;}
        public string ad {  get;set;}
        public string soyad {  get;set;}
        public string tel { get;set;}
        public string sehir { get;set;}
        private static int uyeIdSayac = 1;

        public Uye(string ad,string soyad,string tel,string sehir) 
        {
            this.uyeId = uyeIdSayac++;
            this.ad = ad;
            this.soyad = soyad;
            this.tel = tel;
            this.sehir = sehir;
        }
    }
}
