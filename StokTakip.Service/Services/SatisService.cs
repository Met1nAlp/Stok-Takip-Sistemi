using Microsoft.EntityFrameworkCore;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class SatisService : ISatisService
    {
        private readonly StokTakipDbContext _context;

        public SatisService(StokTakipDbContext context)
        {
            _context = context;
        }

        public async Task<List<SatisDto>> GetAllAsync()
        {
            // SatisDto PascalCase kullandığı için PascalCase map'liyoruz
            // Satis Entity ise camelCase
            return await _context.SatisTable
                .Include(s => s.Musteri)
                .Include(s => s.Personel)
                .Select(s => new SatisDto
                {
                    SatisID = s.satisID,
                    UrunlerinAdiFiyati = s.urunlerinAdiFiyati,
                    AraToplam = s.araToplam,
                    VergiTutarlari = s.vergiTutarlari,
                    ToplamTutar = s.toplamTutar,
                    OdemeTipi = s.odemeTipi,
                    IslemTarihi = s.islemTarihi,
                    MusteriAdi = s.Musteri.musteriAdi, // Musteri entity'sinden
                    PersonelAdi = s.Personel.personelAdi // Personel entity'sinden
                }).ToListAsync();
        }

        public async Task<SatisDto> GetByIdAsync(int satisId)
        {
            var satis = await _context.SatisTable
                .Include(s => s.Musteri)
                .Include(s => s.Personel)
                .FirstOrDefaultAsync(s => s.satisID == satisId);

            if (satis == null) return null;

            return new SatisDto
            {
                SatisID = satis.satisID,
                UrunlerinAdiFiyati = satis.urunlerinAdiFiyati,
                AraToplam = satis.araToplam,
                VergiTutarlari = satis.vergiTutarlari,
                ToplamTutar = satis.toplamTutar,
                OdemeTipi = satis.odemeTipi,
                IslemTarihi = satis.islemTarihi,
                MusteriAdi = satis.Musteri.musteriAdi,
                PersonelAdi = satis.Personel.personelAdi
            };
        }

        public async Task<SatisDetayDto> GetDetayByIdAsync(int satisId)
        {
            var satis = await _context.SatisTable
               .Include(s => s.Musteri)
               .Include(s => s.Personel)
               .FirstOrDefaultAsync(s => s.satisID == satisId);

            if (satis == null) return null;

            return new SatisDetayDto
            {
                SatisID = satis.satisID,
                UrunlerinAdiFiyati = satis.urunlerinAdiFiyati,
                AraToplam = satis.araToplam,
                VergiTutarlari = satis.vergiTutarlari,
                ToplamTutar = satis.toplamTutar,
                OdemeTipi = satis.odemeTipi,
                IslemTarihi = satis.islemTarihi,
                MusteriDetay = new List<MusteriDto> { /* ... Manuel Map ... */ },
                PersonelDetay = new List<PersonelDto> { /* ... Manuel Map ... */ }
            };
        }

        public async Task<SatisDto> AddAsync(SatisEkleDto satisEkleDto)
        {
            var satis = new Satis
            {
                // SatisEkleDto PascalCase
                musteriID = satisEkleDto.MusteriID,
                personelID = satisEkleDto.PersonelID,
                urunlerinAdiFiyati = satisEkleDto.UrunlerinAdiFiyati,
                araToplam = satisEkleDto.AraToplam,
                vergiTutarlari = satisEkleDto.VergiTutarlari,
                toplamTutar = satisEkleDto.ToplamTutar,
                odemeTipi = satisEkleDto.OdemeTipi,
                islemTarihi = DateTime.Now // DTO'da yok, sunucu atar
            };

            _context.SatisTable.Add(satis);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(satis.satisID);
        }
    }
}