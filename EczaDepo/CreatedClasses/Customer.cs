using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaDepo.CreatedClasses
{
    class Customer
    {
        public Customer(int id, string alici, string tarih, int teklifSuresi, string durum, float tutar, List<Ilac> ilaclar)
        {
            Id = id;
            Alici = alici;
            Tarih = tarih;
            TeklifSuresi = teklifSuresi;
            Durum = durum;
            Tutar = tutar;
            Ilaclar = ilaclar;
        }

        public int Id { get; set; }
        public string Alici { get; set; }
        public string Tarih { get; set; }
        public int TeklifSuresi { get; set; }
        public string Durum { get; set; }
        public float Tutar { get; set; }
        public List<Ilac> Ilaclar { get; set; }
    }
}
