using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.DTOs
{
    public class UrunDto
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
    }
}

namespace StokTakip.Core.DTOs
{
    public class UrunEkleDto
    {
        [Required]
        public string urunAdi { get; set; }
        [Required]
        public string barkodNo { get; set; }
        [Required]
        public string resim { get; set; }
        [Required]
        public DateTime alisTarihi { get; set; }
        [Required]
        public DateTime sonTuketimTarihi { get; set; }

        [Required]
        public int kategoriID { get; set; }
        [Required]
        public int tedarikciID { get; set; }
        [Required]
        public int fiyatID { get; set; }
        [Required]
        public int stokID { get; set; }
        [Required]
        public int satisID { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class UrunGuncelleDto
    {
        [Required]
        public int urunID { get; set; }
        [Required]
        public string urunAdi { get; set; }
        [Required]
        public string barkodNo { get; set; }
        [Required]
        public string resim { get; set; }
        [Required]
        public DateTime alisTarihi { get; set; }
        [Required]
        public DateTime sonTuketimTarihi { get; set; }

        [Required]
        public int kategoriID { get; set; }
        [Required]
        public int tedarikciID { get; set; }
        [Required]
        public int fiyatID { get; set; }
        [Required]
        public int stokID { get; set; }
        [Required]
        public int satisID { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class UrunDetayDto
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

        public KategoriDto Kategori { get; set; } 
        public TedarikciDto Tedarikci { get; set; } 
        public FiyatDto Fiyat { get; set; }
        public StokDto Stok { get; set; }
        public SatisDto Satis { get; set; }
    }
}