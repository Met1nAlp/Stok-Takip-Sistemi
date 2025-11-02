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
        public int FiyatID { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
    }

    public class FiyatEkleDto
    {
        [Required(ErrorMessage = "Alış fiyatı girmek zorunludur.")]
        public decimal AlisFiyati { get; set; }

        [Required(ErrorMessage = "Satış fiyatı girmek zorunludur.")]
        public decimal SatisFiyati { get; set; }
    }
    public class FiyatGuncelleDto
    {
        [Required(ErrorMessage = "FiyatId girmek zorunludur.")]
        public int fiyatID { get; set; }
        [Required(ErrorMessage = "Alış fiyatı girmek zorunludur.")]
        public decimal AlisFiyati { get; set; }

        [Required(ErrorMessage = "Satış fiyatı girmek zorunludur.")]
        public decimal SatisFiyati { get; set; }
    }
    public class FiyatDetayDto
    {
        public int FiyatID { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
    }
}