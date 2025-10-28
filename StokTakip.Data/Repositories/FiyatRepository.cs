using Microsoft.EntityFrameworkCore;
using StokTakip.Core.Interface;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    public class FiyatRepository : Repository<Fiyat>, IFiyatRepository
    {
        public FiyatRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<Fiyat> GetFiyatDetayByIdAsync(int fiyatId)
        {
            return await _context.FiyatTable
                .Include(f => f.UrunTable)
                .SingleOrDefaultAsync(f => f.fiyatID == fiyatId);
        }

       
    }
}