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
    internal class SatisRepository : Repository<Satis>, ISatisRepository
    {
        public SatisRepository(StokTakipDbContext context) : base(context)
        {
        }

        public Task<Satis> GetSatisDetayByIdAsync(int satisId)
        {
            return _context.SatisTable
                .Include(s => s.Musteri)
                .Include(s => s.Personel)
                .FirstOrDefaultAsync(s => s.satisID== satisId);
        }

        public async Task<IEnumerable<Satis>> GetTumSatisAsync()
        {
            return await _context.SatisTable
                .Include(s => s.Musteri)
                .Include(s => s.Personel)
                .ToListAsync();
        }
    }
}
