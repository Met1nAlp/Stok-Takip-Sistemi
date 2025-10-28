using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Service.DTOs
{
    public class TedarikciDto
    {
        public int tedarikciID { get; set; }
        public string tedarikciAdi { get; set; }
        public string yetkili { get; set; }
        public string iletisim { get; set; }
        public string adres { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class TedarikciEkleDto
    {
        [Required]
        public string tedarikciAdi { get; set; }
        [Required]
        public string yetkili { get; set; }
        [Required]
        public string iletisim { get; set; }
        [Required]
        public string adres { get; set; }
    }
}


namespace StokTakip.Service.DTOs
{
    public class TedarikciGuncelleDto
    {
        [Required]
        public string tedarikciAdi { get; set; }
        [Required]
        public string yetkili { get; set; }
        [Required]
        public string iletisim { get; set; }
        [Required]
        public string adres { get; set; }
    }
}


namespace StokTakip.Service.DTOs
{
    public class TedarikciDetayDto
    {
        public int tedarikciID { get; set; }
        public string tedarikciAdi { get; set; }
        public string yetkili { get; set; }
        public string iletisim { get; set; }
        public string adres { get; set; }

        public List<UrunDto> urunDetay { get; set; }
    }
}


