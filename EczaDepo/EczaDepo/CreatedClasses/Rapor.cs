using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaDepo.CreatedClasses
{
    class Rapor
    {
        public Rapor(int id, string alici, string durum, string tarih)
        {
            Id = id;
            Alici = alici;
            Durum = durum;
            Tarih = tarih;
        }

        public int Id { get; set; }
        public string Alici { get; set; }
        public string Durum { get; set; }
        public string Tarih { get; set; }
    }
}
