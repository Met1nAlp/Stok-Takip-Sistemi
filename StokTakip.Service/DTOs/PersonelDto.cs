using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Service.DTOs
{
    public class PersonelDto
    {
        public int personelID { get; set; }
        public string personelAdi { get; set; }
        public int personelNo { get; set; }
        public string unvani { get; set}
        public string iletisim { get; set; }
        public DateTime iseBaslmaTarihi { get; set; }
        public string calismaGunleri { get; set; }
        public string mesaisi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class PersonelEkleDto
    {
        [Required(ErrorMessage="Personel adı girmek zorunludur")]
        public string personelAdi { get; set; }
        [Required(ErrorMessage="Personel no girmek zorunludur")]
        public int personelNo { get; set; }
        [Required(ErrorMessage="Unvan girmek zorunludur")]
        public string unvani { get; set; }
        [Required(ErrorMessage="İletişim bilgisi girmek zorunludur")]
        public string iletisim { get; set; }
        [Required(ErrorMessage="İşe başlama tarihi girmek zorunludur")]
        public DateTime iseBaslmaTarihi { get; set; }
        [Required(ErrorMessage="Çalışma günleri girmek zorunludur")]
        public string calismaGunleri { get; set; }
        [Required(ErrorMessage="Mesaisi girmek zorunludur")]
        public string mesaisi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class PersonelGuncelleDto
    {
        [Required(ErrorMessage="Personel ID girmek zorunludur")]
        public int personelID { get; set; }
        [Required(ErrorMessage="Personel adı girmek zorunludur")]
        public string personelAdi { get; set; }
        [Required(ErrorMessage="Personel no girmek zorunludur")]
        public int personelNo { get; set; }
        [Required(ErrorMessage="Unvan girmek zorunludur")]
        public string unvani { get; set; }
        [Required(ErrorMessage="İletişim bilgisi girmek zorunludur")]
        public string iletisim { get; set; }
        [Required(ErrorMessage="İşe başlama tarihi girmek zorunludur")]
        public DateTime iseBaslmaTarihi { get; set; }
        [Required(ErrorMessage="Çalışma günleri girmek zorunludur")]
        public string calismaGunleri { get; set; }
        [Required(ErrorMessage="Mesaisi girmek zorunludur")]
        public string mesaisi { get; set; }
    }
}

namespace StokTakip.Service.DTOs
{
    public class PersonelDetayDto
    {
        public int personelID { get; set; }
        public string personelAdi { get; set; }
        public int personelNo { get; set; }
        public string unvani { get; set; }
        public string iletisim { get; set; }
        public DateTime iseBaslmaTarihi { get; set; }
        public string calismaGunleri { get; set; }
        public string mesaisi { get; set; }

        public List<SatisDto> satisGecmisi { get; set; }

    }
}
