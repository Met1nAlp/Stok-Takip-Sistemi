using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Kategori
    {
        public int kategoriID { get; set; }
        public string kategoriAdi { get; set; }
        public string yeri { get; set; }

        public virtual ICollection<Urun> Urunler { get; set; }
    }
}
