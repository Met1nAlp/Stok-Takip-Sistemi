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
    internal class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Urun>> GetTumUrunDetaylariAsync()
        {
            return await _context.UrunTable
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .Include(u => u.Fiyat)
                .Include(u => u.Stok)
                .Include(u => u.Satis)
                .ToListAsync();
        }
        public async Task<Urun> GetUrunDetayByIdAsync(int urunId)
        {
            return await _context.UrunTable
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .Include(u => u.Fiyat)
                .Include(u => u.Stok)
                .Include(u => u.Satis)
                .SingleOrDefaultAsync(u => u.urunID == urunId);
        }
    }
}
