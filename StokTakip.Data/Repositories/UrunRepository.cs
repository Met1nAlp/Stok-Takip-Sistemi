using Microsoft.EntityFrameworkCore;
using StokTakip.Core.IRepositories;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<Urun> GetUrunDetayByIdAsync(int urunId)
        {
            return await _context.UrunTable
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .Include(u => u.Fiyat)
                .Include(u => u.Stok)
                .Include(u => u.SatisDetaylari)
                .SingleOrDefaultAsync(u => u.urunID == urunId);
        }

        public async Task<IEnumerable<Urun>> GetTumUrunDetaylariAsync()
        {
            return await _context.UrunTable
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .Include(u => u.Fiyat)
                .Include(u => u.Stok)
                .Include(u => u.SatisDetaylari)
                .ToListAsync();
        }
    }
}