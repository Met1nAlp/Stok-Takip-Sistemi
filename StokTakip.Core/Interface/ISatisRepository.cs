using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface ISatisRepository
    {
        Task<IEnumerable<Satis>> GetSatisID(int satisID);
        Task<IEnumerable<Satis>> GetUrunlerinAdiFiyati(string urunlerinAdiFiyati);
        Task<IEnumerable<Satis>> GetAraToplam(decimal araToplam);
        Task<IEnumerable<Satis>> GetVergiTutarlari(decimal vergiTutarlari);
        Task<IEnumerable<Satis>> GetToplamTutar(decimal toplamTutar);
        Task<IEnumerable<Satis>> GetOdemeTipi(string odemeTipi);
        Task<IEnumerable<Satis>> GetIslemTarihi(DateTime islemTarihi);
        Task<IEnumerable<Satis>> GetMusteriID(int musteriID);
        Task<IEnumerable<Satis>> GetPersonelID(int personelID);
    }
}
