using Microsoft.EntityFrameworkCore;
using StokTakip.Core.Interface;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    internal class MusteriRepository : Repository<Musteri> , IMusteriRepository
    {
        public MusteriRepository(StokTakip.Data.Context.StokTakipDbContext context) : base(context)
        {
        }

        public Task<Musteri> GetMusteriByIdAsync(int musteriId)
        {
            return _context.MusteriTable
                .Include(m => m.SatisTable)
                .SingleOrDefaultAsync(m => m.musteriID== musteriId);
        }
    }
}
