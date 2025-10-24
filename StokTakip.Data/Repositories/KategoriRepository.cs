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
        public async Task<IEnumerable<Kategori>> GetKategoriID(int kategoriID)
        {
            var kategori = await _context.KategoriTable.FindAsync(kategoriID);
            if (kategori == null)
            {
                return new List<Kategori>();
            }
            return new List<Kategori> { kategori };
        }
        public async Task<IEnumerable<Kategori>> GetKategoriAdi(string kategoriAdi)
        {
            return await _context.KategoriTable   
                .Where(k => k.kategoriAdi == kategoriAdi)
                .ToListAsync();
        }
        public async Task<IEnumerable<Kategori>> GetYeri(string yeri)
        {
            return await _context.KategoriTable
                .Where(k => k.yeri == yeri)
                .ToListAsync();
        }
    }
}
