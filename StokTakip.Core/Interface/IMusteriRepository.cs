using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IMusteriRepository : IRepository<Musteri>
    {
        Task<IEnumerable<Entity.Entities.Musteri>> GetMusteriID(int musteriID);
        Task<IEnumerable<Entity.Entities.Musteri>> GetMusteriAdi(string musteriAdi);
        Task<IEnumerable<Entity.Entities.Musteri>> GetMusteriNo(int musteriNo);
        Task<IEnumerable<Entity.Entities.Musteri>> GetIletisim(string iletisim);
        Task<IEnumerable<Entity.Entities.Musteri>> GetKayitTarihi(DateTime kayitTarihi);
    }
}
