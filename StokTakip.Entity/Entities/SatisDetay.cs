using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class SatisDetay
    {
        public int satisID { get; set; }
        public virtual Satis Satis { get; set; }

        public int urunID { get; set; }
        public virtual Urun Urun { get; set; }

        public int Miktar { get; set; }
        public decimal SatisFiyati { get; set; }
    }
}