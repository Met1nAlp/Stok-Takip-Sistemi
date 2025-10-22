using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Stok
    {
        public int stokID { get; set; }
        public int toplamStokMiktari { get; set; }
        public int kalanStokMiktari { get; set; }
        public DateTime islemTarihi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
