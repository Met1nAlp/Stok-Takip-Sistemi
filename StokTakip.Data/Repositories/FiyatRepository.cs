using StokTakip.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    public class FiyatRepository<Fiyat> : IFiyatRepository where Fiyat : class
    {
        public Task<IEnumerable<Entity.Entities.Fiyat>> GetAlisFiyati(decimal alisFiyati)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Entities.Fiyat>> GetFiyatID(int fiyatID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Entities.Fiyat>> GetGuncellemeTarihi(DateTime guncellemeTarihi)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Entities.Fiyat>> GetSatisFiyati(decimal satisFiyati)
        {
            throw new NotImplementedException();
        }
    }
}
