using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Tedarikci
    {
        public int tedarikciID { get; set; }
        public string tedarikciAdi { get; set; }
        public string yetkili { get; set; }
        public string iletisim { get; set; }
        public string adres { get; set; }

        public ICollection<Urun> Urunler { get; set; }
    }
}
