using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.DTOs
{
    public class SatisUrunEkleDto
    {
        [Required]
        public int UrunID { get; set; }
        [Required]
        public int Miktar { get; set; }
    }

    public class SatisEkleDto
    {
        [Required]
        public int MusteriID { get; set; }
        [Required]
        public int PersonelID { get; set; }

        [Required(ErrorMessage = "Ödeme tipi boş olmaz")]
        public string OdemeTipi { get; set; }

        [Required]
        public List<SatisUrunEkleDto> SatilanUrunler { get; set; }
    }

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

    public class SatisDetayDto
    {
        public int SatisID { get; set; }
        public decimal ToplamTutar { get; set; }
        public string OdemeTipi { get; set; }
        public DateTime IslemTarihi { get; set; }

        public PersonelDto PersonelDetay { get; set; }
        public MusteriDto MusteriDetay { get; set; }
        public List<SatisUrunDetayDto> SatilanUrunler { get; set; }
    }

    public class SatisUrunDetayDto
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
        public decimal SatisFiyati { get; set; } 
    }
}