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

        public async Task<IEnumerable<Fiyat>> GetFiyatID(int fiyatID)
        {
            var fiyat = await _context.FiyatTable.FindAsync(fiyatID);
            if (fiyat == null)
            {
                return new List<Fiyat>();
            }
            return new List<Fiyat> { fiyat };
        }

        public async Task<IEnumerable<Fiyat>> GetAlisFiyati(decimal alisFiyati)
        {
            return await _context.FiyatTable
                                 .Where(f => f.alisFiyati == alisFiyati)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Fiyat>> GetSatisFiyati(decimal satisFiyati)
        {
            return await _context.FiyatTable
                                 .Where(f => f.satisFiyati == satisFiyati)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Fiyat>> GetGuncellemeTarihi(DateTime guncellemeTarihi)
        {
            return await _context.FiyatTable
                                 .Where(f => f.guncellemeTarihi.Date == guncellemeTarihi.Date)
                                 .ToListAsync();
        }
    }
}