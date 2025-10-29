using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.DTOs
{
    public class KategoriDto
    {
        public int kategoriID { get; set; }
        public string kategoriAdi { get; set; }
        public string yeri { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class kategoriEkleDto
    {
        [Required(ErrorMessage = "Kategori Adı boş geçilemez!")]
        public string kategoriAdi { get; set; }
        [Required(ErrorMessage = "Kategori Yeri boş geçilemez!")]
        public string yeri { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class kategoriGuncelleDto
    {
        [Required(ErrorMessage = "Kategori ID boş geçilemez!")]
        public int kategoriID { get; set; }
        [Required(ErrorMessage = "Kategori Adı boş geçilemez!")]
        public string kategoriAdi { get; set; }
        [Required(ErrorMessage = "Kategori Yeri boş geçilemez!")]
        public string yeri { get; set; }
    }
}

namespace StokTakip.Core.DTOs
{
    public class kategoriDetayDto
    {
        public int kategoriID { get; set; }
        public string kategoriAdi { get; set; }
        public string yeri { get; set}
    }
}
