using Microsoft.EntityFrameworkCore;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class TedarikciService : ITedarikciService
    {
        private readonly StokTakipDbContext _context;

        public TedarikciService(StokTakipDbContext context)
        {
            _context = context;
        }

        public async Task<List<TedarikciDto>> GetAllAsync()
        {
            return await _context.TedarikciTable
                .Select(t => new TedarikciDto
                {
                    tedarikciID = t.tedarikciID,
                    tedarikciAdi = t.tedarikciAdi,
                    yetkili = t.yetkili,
                    iletisim = t.iletisim,
                    adres = t.adres
                }).ToListAsync();
        }

        public async Task<TedarikciDto> GetByIdAsync(int tedarikciId)
        {
            var tedarikci = await _context.TedarikciTable.FindAsync(tedarikciId);
            if (tedarikci == null) return null;

            return new TedarikciDto
            {
                tedarikciID = tedarikci.tedarikciID,
                tedarikciAdi = tedarikci.tedarikciAdi,
                yetkili = tedarikci.yetkili,
                iletisim = tedarikci.iletisim,
                adres = tedarikci.adres
            };
        }

        public async Task<TedarikciDetayDto> GetDetayByIdAsync(int tedarikciId)
        {
            var tedarikci = await _context.TedarikciTable
                                .Include(t => t.Urunler)
                                .FirstOrDefaultAsync(t => t.tedarikciID == tedarikciId);

            if (tedarikci == null) return null;

            return new TedarikciDetayDto
            {
                tedarikciID = tedarikci.tedarikciID,
                tedarikciAdi = tedarikci.tedarikciAdi,
                yetkili = tedarikci.yetkili,
                iletisim = tedarikci.iletisim,
                adres = tedarikci.adres,
                urunDetay = tedarikci.Urunler.Select(u => new UrunDto
                {
                    urunID = u.urunID,
                    urunAdi = u.urunAdi,
                    barkodNo = u.barkodNo
                }).ToList()
            };
        }

        public async Task<TedarikciDto> AddAsync(TedarikciEkleDto tedarikciEkleDto)
        {
            var tedarikci = new Tedarikci
            {
                tedarikciAdi = tedarikciEkleDto.tedarikciAdi,
                yetkili = tedarikciEkleDto.yetkili,
                iletisim = tedarikciEkleDto.iletisim,
                adres = tedarikciEkleDto.adres
            };

            _context.TedarikciTable.Add(tedarikci);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(tedarikci.tedarikciID);
        }

        public async Task<TedarikciDto> UpdateAsync(int tedarikciId, TedarikciGuncelleDto tedarikciGuncelleDto)
        {
            var tedarikci = await _context.TedarikciTable.FindAsync(tedarikciId);
            if (tedarikci == null) return null;

            tedarikci.tedarikciAdi = tedarikciGuncelleDto.tedarikciAdi;
            tedarikci.yetkili = tedarikciGuncelleDto.yetkili;
            tedarikci.iletisim = tedarikciGuncelleDto.iletisim;
            tedarikci.adres = tedarikciGuncelleDto.adres;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(tedarikci.tedarikciID);
        }

        public async Task<bool> DeleteAsync(int tedarikciId)
        {
            var tedarikci = await _context.TedarikciTable.FindAsync(tedarikciId);
            if (tedarikci == null) return false;

            _context.TedarikciTable.Remove(tedarikci);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}