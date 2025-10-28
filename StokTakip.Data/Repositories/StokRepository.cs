using Microsoft.EntityFrameworkCore;
using StokTakip.Core.Interface;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    public class StokRepository : Repository<Stok>, IStokRepository
    {
        public StokRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<Stok> GetStokByIdAsync(int stokId)
        {
            return await _context.StokTable
                .Include(s => s.Urun)
                .SingleOrDefaultAsync(s => s.stokID == stokId);
        }
    }
}
