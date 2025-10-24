using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IPersonelRepository : IRepository<Personel>
    {
        Task<IEnumerable<Personel>> GetPersonelID(int personelID);
        Task<IEnumerable<Personel>> GetPersonelAdi(string personelAdi);
        Task<IEnumerable<Personel>> GetPersonelNo(int personelNo);
        Task<IEnumerable<Personel>> GetUnvani(string unvani);
        Task<IEnumerable<Personel>> GetIletisim(string iletisim);
        Task<IEnumerable<Personel>> GetIseBaslamaTarihi(DateTime iseBaslamaTarihi);
        Task<IEnumerable<Personel>> GetCalismaGunleri(string calismaGunleri);
        Task<IEnumerable<Personel>> GetMesaisi(string mesaisi);
    }
}
