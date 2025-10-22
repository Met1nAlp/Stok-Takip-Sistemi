using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IFiyatRepository
    {
        Task<IEnumerable<Fiyat>> GetFiyatID(int fiyatID);
        Task<IEnumerable<Fiyat>> GetAlisFiyati(decimal alisFiyati);
        Task<IEnumerable<Fiyat>> GetSatisFiyati(decimal satisFiyati);
        Task<IEnumerable<Fiyat>> GetGuncellemeTarihi(DateTime guncellemeTarihi);

    }
}
