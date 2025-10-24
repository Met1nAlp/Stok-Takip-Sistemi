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
        public async Task<IEnumerable<Musteri>> GetIletisim(string iletisim)
        {
            return await _context.MusteriTable
                .Where(m => m.iletisim.Contains(iletisim))
                .ToListAsync();
        }
        public async Task<IEnumerable<Musteri>> GetKayitTarihi(DateTime kayitTarihi)
        {
            return await _context.MusteriTable
                .Where(m => m.kayitTarihi == kayitTarihi)
                .ToListAsync();
        }
        public async Task<IEnumerable<Musteri>> GetMusteriAdi(string musteriAdi)
        {
            return await _context.MusteriTable
                .Where(m => m.musteriAdi.Contains(musteriAdi))
                .ToListAsync();
        }
        public async Task<IEnumerable<Musteri>> GetMusteriID(int musteriID)
        {
            return await _context.MusteriTable
                .Where(m => m.musteriID == musteriID)
                .ToListAsync();
        }
        public async Task<IEnumerable<Musteri>> GetMusteriNo(int musteriNo)
        {
            return await _context.MusteriTable
                .Where(m => m.musteriNo == musteriNo)
                .ToListAsync();
        }
    }
}
