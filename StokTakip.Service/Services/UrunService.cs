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
    public class UrunService : IUrunService
    {
        private readonly StokTakipDbContext _context;

        public UrunService(StokTakipDbContext context)
        {
            _context = context;
        }

        public async Task<List<UrunDto>> GetAllAsync()
        {
            // UrunDto ve Urun camelCase
            return await _context.UrunTable
                .Select(u => new UrunDto
                {
                    urunID = u.urunID,
                    urunAdi = u.urunAdi,
                    barkodNo = u.barkodNo,
                    resim = u.resim,
                    alisTarihi = u.alisTarihi,
                    sonTuketimTarihi = u.sonTuketimTarihi,
                    kategoriID = u.kategoriID,
                    tedarikciID = u.tedarikciID,
                    fiyatID = u.fiyatID,
                    stokID = u.stokID,
                    satisID = u.satisID
                }).ToListAsync();
        }

        public async Task<UrunDto> GetByIdAsync(int urunId)
        {
            var urun = await _context.UrunTable.FindAsync(urunId);
            if (urun == null) return null;

            return new UrunDto
            {
                urunID = urun.urunID,
                urunAdi = urun.urunAdi,
                barkodNo = urun.barkodNo,
                resim = urun.resim,
                alisTarihi = urun.alisTarihi,
                sonTuketimTarihi = urun.sonTuketimTarihi,
                kategoriID = urun.kategoriID,
                tedarikciID = urun.tedarikciID,
                fiyatID = urun.fiyatID,
                stokID = urun.stokID,
                satisID = urun.satisID
            };
        }

        public async Task<UrunDetayDto> GetDetayByIdAsync(int urunId)
        {
            var urun = await _context.UrunTable
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .Include(u => u.Fiyat)
                .Include(u => u.Satis)
                .FirstOrDefaultAsync(u => u.urunID == urunId);

            if (urun == null) return null;

            return new UrunDetayDto
            {
                urunID = urun.urunID,
                urunAdi = urun.urunAdi,

                Kategori = urun.Kategori != null ? new KategoriDto { KategoriID = urun.Kategori.Id, KategoriAdi = urun.Kategori.kategoriAdi, Yeri = urun.Kategori.yeri } : null,
                Tedarikci = urun.Tedarikci != null ? new TedarikciDto { tedarikciID = urun.Tedarikci.tedarikciID, tedarikciAdi = urun.Tedarikci.tedarikciAdi, ... } : null,
                Fiyat = urun.Fiyat != null ? new FiyatDto { FiyatID = urun.Fiyat.Id, AlisFiyati = urun.Fiyat.alisFiyati, ... } : null,
                Satis = urun.Satis != null ? new SatisDto { SatisID = urun.Satis.satisID, ToplamTutar = urun.Satis.toplamTutar, ... } : null
            };
        }

        public async Task<UrunDto> AddAsync(UrunEkleDto urunEkleDto)
        {
            var urun = new Urun
            {
                urunAdi = urunEkleDto.urunAdi,
                barkodNo = urunEkleDto.barkodNo,
                resim = urunEkleDto.resim,
                alisTarihi = urunEkleDto.alisTarihi,
                sonTuketimTarihi = urunEkleDto.sonTuketimTarihi,
                kategoriID = urunEkleDto.kategoriID,
                tedarikciID = urunEkleDto.tedarikciID,
                fiyatID = urunEkleDto.fiyatID,
                stokID = urunEkleDto.stokID,
                satisID = urunEkleDto.satisID 
            };

            _context.UrunTable.Add(urun);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(urun.urunID);
        }

        public async Task<UrunDto> UpdateAsync(int urunId, UrunGuncelleDto urunGuncelleDto)
        {
            var urun = await _context.UrunTable.FindAsync(urunId);
            if (urun == null) return null;

            urun.urunAdi = urunGuncelleDto.urunAdi;
            urun.barkodNo = urunGuncelleDto.barkodNo;
            urun.resim = urunGuncelleDto.resim;
            urun.alisTarihi = urunGuncelleDto.alisTarihi;
            urun.sonTuketimTarihi = urunGuncelleDto.sonTuketimTarihi;
            urun.kategoriID = urunGuncelleDto.kategoriID;
            urun.tedarikciID = urunGuncelleDto.tedarikciID;
            urun.fiyatID = urunGuncelleDto.fiyatID;
            urun.stokID = urunGuncelleDto.stokID;
            urun.satisID = urunGuncelleDto.satisID;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(urun.urunID);
        }

        public async Task<bool> DeleteAsync(int urunId)
        {
            var urun = await _context.UrunTable.FindAsync(urunId);
            if (urun == null) return false;

            _context.UrunTable.Remove(urun);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}