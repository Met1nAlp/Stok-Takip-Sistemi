using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Service.DTOs
{
    public class StokDto
    {
        public int stokID { get; set; }
        public int toplamStokMiktari { get; set; }
        public int kalanStokMiktari { get; set; }
        public DateTime islemTarihi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class StokEkleDto
    {
        [Required]
        public int toplamStokMiktari { get; set; }
        [Required]
        public int kalanStokMiktari { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class StokGuncelleDto
    {
        [Required]
        public int stokID { get; set; }
        [Required]
        public int toplamStokMiktari { get; set; }
        [Required]
        public int kalanStokMiktari { get; set; }
        [Required]
        public DateTime islemTarihi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class StokDetayDto
    {
        public int stokID { get; set; }
        public int toplamStokMiktari { get; set; }
        public int kalanStokMiktari { get; set; }
        public DateTime islemTarihi { get; set; }

        public List<UrunDto> urunDetay { get; set; }
    }
}
