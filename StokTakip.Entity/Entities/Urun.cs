using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Entities
{
    public class Urun
    {
        public int urunID { get; set; }
        public string urunAdi { get; set; }
        public string barkodNo { get; set; }
        public string resim { get; set; }
        public DateTime alisTarihi { get; set; }
        public DateTime sonTuketimTarihi { get; set; }

        public int kategoriID { get; set; }
        public int tedarikciID { get; set; }
        public int fiyatID { get; set; }
        public int stokID { get; set; }
        public int satisID { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual Tedarikci Tedarikci { get; set; }
        public virtual Fiyat Fiyat { get; set; }
        public virtual Satis Satis { get; set; }
    }
}
