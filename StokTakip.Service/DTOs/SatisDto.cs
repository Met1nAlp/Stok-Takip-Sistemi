using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Service.DTOs
{
    public class SatisDto
    {
        public int SatisID { get; set; }
        public string UrunlerinAdiFiyati { get; set; } 
        public decimal AraToplam { get; set; } 
        public decimal VergiTutarlari { get; set; } 
        public decimal ToplamTutar { get; set; } 
        public string OdemeTipi { get; set; } 
        public DateTime IslemTarihi { get; set; } 

        public string MusteriAdi { get; set; }
        public string PersonelAdi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class SatisEkleDto
    {
        [Required]
        public int MusteriID { get; set; } 
        [Required]
        public int PersonelID { get; set; }
        [Required(ErrorMessage ="Ürün adı veya fiyatı boş olmaz")]
        public string UrunlerinAdiFiyati { get; set; }
        [Required(ErrorMessage ="Aratoplam boş olmaz")]
        public decimal AraToplam { get; set; }
        [Required(ErrorMessage ="Vergi tutarları boş olmaz")]
        public decimal VergiTutarlari { get; set; }
        [Required(ErrorMessage ="Toplam tutar boş olmaz")]
        public decimal ToplamTutar { get; set; }
        [Required(ErrorMessage ="Ödeme tipi boş olmaz")]
        public string OdemeTipi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class SatisDetayDto
    {
        public int SatisID { get; set; }
        public string UrunlerinAdiFiyati { get; set; }
        public decimal AraToplam { get; set; }
        public decimal VergiTutarlari { get; set; }
        public decimal ToplamTutar { get; set; }
        public string OdemeTipi { get; set; }
        public DateTime IslemTarihi { get; set; }
        
        public List<PersonelDto> PersonelDetay { get; set; }
        public List<MusteriDto> MusteriDetay { get; set; }
    }
}
