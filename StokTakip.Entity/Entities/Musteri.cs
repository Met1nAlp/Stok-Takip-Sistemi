using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Musteri
    {
        public int musteriID { get; set; }
        public string musteriAdi { get; set; }
        public int musteriNo { get; set; }
        public string iletisim { get; set; }
        public DateTime kayitTarihi { get; set; }

        public virtual ICollection<Satis> SatisTable { get; set; }
    }
}
