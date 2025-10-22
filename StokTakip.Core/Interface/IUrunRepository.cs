using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IUrunRepository : IRepository<Urun>
    {
        Task<IEnumerable<Urun>> GetUrunID(int urunID);
        Task<IEnumerable<Urun>> GetUrunAdi(string urunAdi);
        Task<IEnumerable<Urun>> GetBarkodNo(string barkodNo);
        Task<IEnumerable<Urun>> GetResim(string resim);
        Task<IEnumerable<Urun>> GetAlisTarihi(DateTime alisTarihi);
        Task<IEnumerable<Urun>> GetSonTuketimTarihi(DateTime sonTuketimTarihi);

        Task<IEnumerable<Urun>> GetUrunlerByFiyatIdAsync(int fiyatID);
        Task<IEnumerable<Urun>> GetUrunlerByTedarikciIdAsync(int tedarikciID);
        Task<IEnumerable<Urun>> GetUrunlerByKategoriIdAsync(int kategoriID);
        Task<IEnumerable<Urun>> GetUrunlerByStokIdAsync(int stokID);
        Task<IEnumerable<Urun>> GetUrunlerBySatisIdAsync(int satisID);
    }
}
