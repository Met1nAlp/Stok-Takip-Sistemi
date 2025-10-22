using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Satis
    {
        public int satisID { get; set; }
        public string urunlerinAdiFiyati { get; set; }
        public decimal araToplam { get; set; }
        public decimal vergiTutarlari { get; set; }
        public decimal toplamTutar { get; set; }
        public string odemeTipi { get; set; }
        public DateTime islemTarihi { get; set; }
        public int musteriID { get; set; }
        public int personelID { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
