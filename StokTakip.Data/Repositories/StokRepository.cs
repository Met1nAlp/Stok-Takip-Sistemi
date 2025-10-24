using StokTakip.Entity.Entities;
using StokTakip.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.Data.Context;

namespace StokTakip.Data.Repositories
{
    public class StokRepository : Repository<Stok>, IStokRepository
    {
        public StokRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Stok>> GetStokID(int stokID)
        {
            var stok = await _context.StokTable.FindAsync(stokID);
            if (stok == null)
            {
                return new List<Stok>();
            }
            return new List<Stok> { stok };
        }

        public async Task<IEnumerable<Stok>> GetIslemTarihi(DateTime islemTarihi)
        {
            return _context.StokTable.Where(s => s.islemTarihi == islemTarihi);
        }

        public async Task<IEnumerable<Stok>> GetKalanStokMiktari(int kalanStokMiktari)
        {
            return _context.StokTable.Where(s => s.kalanStokMiktari == kalanStokMiktari);
        }    

        public async Task<IEnumerable<Stok>> GetToplamStokMiktari(int toplamStokMiktari)
        {
            return _context.StokTable.Where(s => s.toplamStokMiktari == toplamStokMiktari);
        }
    }
}
