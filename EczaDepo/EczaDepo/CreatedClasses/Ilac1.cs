using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaDepo.CreatedClasses
{
    class Ilac1
    {
        public Ilac1(int id, string ad, int miktar, string muadil, float alisFiyati, float birimFiyat, float toplamFiyat)
        {
            Id = id;
            Ad = ad;
            Miktar = miktar;
            Muadil = muadil;
            AlisFiyati = alisFiyati;
            BirimFiyat = birimFiyat;
            ToplamFiyat = toplamFiyat;
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public int Miktar { get; set; }
        public string Muadil { get; set; }
        public float AlisFiyati { get; set; }
        public float BirimFiyat { get; set; }
        public float ToplamFiyat { get; set; }
    }
}
