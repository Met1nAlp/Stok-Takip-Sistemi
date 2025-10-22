using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Personel
    {
        public int personelID { get; set; }
        public string personelAdi { get; set; }
        public int personelNo { get; set; }
        public string unvani { get; set; }
        public string iletisim { get; set; }
        public DateTime iseBaslmaTarihi { get; set; }
        public string calismaGunleri { get; set; }
        public string mesaisi { get; set; }

        public virtual ICollection<Satis> SatisTable { get; set; }
    }
}
