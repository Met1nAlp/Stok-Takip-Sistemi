using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.DTOs
{
    public class FiyatDto
    {
        public int fiyatID { get; set; }
        public decimal alisFiyati { get; set; }
        public decimal satisFiyati { get; set; }
        public DateTime guncellemeTarihi { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class FiyatEkleDto
    {
        [Required(ErrorMessage = "Alış fiyatı girmek zorunludur.")]
        public decimal alisFiyati { get; set; }
        [Required(ErrorMessage = "Satış fiyatı girmek zorunludur.")]
        public decimal satisFiyati { get; set; }
    }
    
}

namespace StokTakip.Core.DTOs
{
    public class FiyatGuncelleDto
    {
        [Required(ErrorMessage = "Fiyat ID girmek zorunludur.")]
        public int fiyatID { get; set; }
        [Required(ErrorMessage = "Alış fiyatı girmek zorunludur.")]
        public decimal alisFiyati { get; set; }
        [Required(ErrorMessage = "Satış fiyatı girmek zorunludur.")]
        public decimal satisFiyati { get; set; }
    }

}

namespace StokTakip.Core.DTOs
{
    public class FiyatDetayDto
    {
        public int fiyatID { get; set; }
        public decimal alisFiyati { get; set; }
        public decimal satisFiyati { get; set; }
        public DateTime guncellemeTarihi { get; set; }
    }
}
