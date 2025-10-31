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
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public string Yeri { get; set; }
    }

    public class KategoriEkleDto
    {
        [Required(ErrorMessage = "Kategori Adı boş geçilemez!")]
        public string KategoriAdi { get; set; }

        [Required(ErrorMessage = "Kategori Yeri boş geçilemez!")]
        public string Yeri { get; set; }
    }

    public class KategoriGuncelleDto
    {
        [Required(ErrorMessage = "Kategori Adı boş geçilemez!")]
        public string KategoriAdi { get; set; }

        [Required(ErrorMessage = "Kategori Yeri boş geçilemez!")]
        public string Yeri { get; set; }
    }

    public class KategoriDetayDto
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public string Yeri { get; set; }
    }
}