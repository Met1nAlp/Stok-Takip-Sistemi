using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Fiyat
    {
        public int fiyatID { get; set; }
        public decimal alisFiyati { get; set; }
        public decimal satisFiyati { get; set; }
        public DateTime guncellemeTarihi { get; set; }

        public virtual ICollection<Urun> UrunTable { get; set; }
    }
}
