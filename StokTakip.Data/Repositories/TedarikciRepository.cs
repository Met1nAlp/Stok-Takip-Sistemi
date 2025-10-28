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
    internal class TedarikciRepository : Repository<Tedarikci>, ITedarikciRepository
    {
        public TedarikciRepository(StokTakipDbContext context) : base(context)
        {
        }
        
        public async Task<Tedarikci> GetTedarikciByIdAsync(int tedarikciId)
        {
            return await _context.TedarikciTable
                .Include(t => t.Urunler) 
                .SingleOrDefaultAsync(t => t.tedarikciID== tedarikciId);
        }
    }
}
