using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.DTOs
{
    public class MusteriDto
    {
        public int musteriID { get; set; }
        public string musteriAdi { get; set; }
        public int musteriNo { get; set; }
        public string iletisim { get; set; }
        public DateTime kayitTarihi { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class MusteriEkleDto
    {
        [Required]
        public string musteriAdi { get; set; }
        [Required]
        public int musteriNo { get; set; }
        [Required]
        public string iletisim { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class MusteriGuncelleDto
    {
        [Required]
        public int musteriID { get; set; }
        [Required]
        public string musteriAdi { get; set; }
        [Required]
        public int musteriNo { get; set; }
        [Required]
        public string iletisim { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class MusteriDetayDto
    {
        public int musteriID { get; set; }
        public string musteriAdi { get; set; }
        public int musteriNo { get; set; }
        public string iletisim { get; set; }
        public DateTime kayitTarihi { get; set; }
        public List<SatisDto> satisDetay { get; set; }
    }
}