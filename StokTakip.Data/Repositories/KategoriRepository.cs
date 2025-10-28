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
    internal class KategoriRepository : Repository<Kategori> , IKategoriRepository
    {
        public KategoriRepository(StokTakipDbContext context) : base(context)
        {
        }
        public async Task<Kategori> GetKategoriByIdAsync(int kategoriId)
        {
            return await _context.KategoriTable
                .Include(k => k.Urunler)
                .SingleOrDefaultAsync(k => k.kategoriID == kategoriId);
        }
    }
}
