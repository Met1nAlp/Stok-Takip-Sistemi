using StokTakip.Entity.Entities;
using StokTakip.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    public class StokRepository<Stok> : IStokRepository where Stok : class
    {
        public Task<IEnumerable<Entity.Entities.Stok>> GetIslemTarihi(DateTime islemTarihi)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Entities.Stok>> GetKalanStokMiktari(int kalanStokMiktari)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Entities.Stok>> GetStokID(int stokID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.Entities.Stok>> GetToplamStokMiktari(int toplamStokMiktari)
        {
            throw new NotImplementedException();
        }
    }
}
