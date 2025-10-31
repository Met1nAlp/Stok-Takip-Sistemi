using Microsoft.EntityFrameworkCore;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class StokService : IStokService
    {
        private readonly StokTakipDbContext _context;

        public StokService(StokTakipDbContext context)
        {
            _context = context;
        }

        public async Task<StokDto> GetByIdAsync(int stokId)
        {
            var stok = await _context.StokTable.FindAsync(stokId);
            if (stok == null) return null;

            return new StokDto
            {
                stokID = stok.stokID,
                toplamStokMiktari = stok.toplamStokMiktari,
                kalanStokMiktari = stok.kalanStokMiktari,
                islemTarihi = stok.islemTarihi
            };
        }

        public async Task<StokDto> GetStokByUrunIdAsync(int urunId)
        {
            var stok = await _context.StokTable.FirstOrDefaultAsync(s => s.urunID == urunId);
            if (stok == null) return null;

            return new StokDto
            {
                stokID = stok.stokID,
                toplamStokMiktari = stok.toplamStokMiktari,
                kalanStokMiktari = stok.kalanStokMiktari,
                islemTarihi = stok.islemTarihi
            };
        }

        public async Task<StokDto> AddAsync(StokEkleDto stokEkleDto)
        {
            var stok = new Stok
            {
                toplamStokMiktari = stokEkleDto.toplamStokMiktari,
                kalanStokMiktari = stokEkleDto.kalanStokMiktari,
                islemTarihi = DateTime.Now 
            };

            _context.StokTable.Add(stok);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(stok.stokID);
        }

        public async Task<StokDto> UpdateAsync(int stokId, StokGuncelleDto stokGuncelleDto)
        {
            var stok = await _context.StokTable.FindAsync(stokId);
            if (stok == null) return null;

            stok.toplamStokMiktari = stokGuncelleDto.toplamStokMiktari;
            stok.kalanStokMiktari = stokGuncelleDto.kalanStokMiktari;

            stok.islemTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(stok.stokID);
        }

        public async Task<bool> DeleteAsync(int stokId)
        {
            var stok = await _context.StokTable.FindAsync(stokId);
            if (stok == null) return false;

            _context.StokTable.Remove(stok);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}