using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;

namespace StokTakip.Service.Services
{
    public class FiyatService : IFiyatService
    {
        private readonly StokTakipDbContext _context;
        public FiyatService(StokTakipDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<FiyatDto>> GetAllAsync()
        {
            
            var fiyat = await _context.FiyatTable.ToListAsync();

            if (fiyat == null)
            {
                return null;
            }

            return fiyat.Select(f => new FiyatDto
            {
                FiyatID = f.fiyatID,
                AlisFiyati = f.alisFiyati,
                SatisFiyati = f.satisFiyati,
                GuncellemeTarihi = f.guncellemeTarihi
            }).ToList();
        }

        public async Task<FiyatDto> GetByIdAsync(int fiyatId)
        {
            var fiyat = await _context.FiyatTable.FindAsync(fiyatId);
            
            if (fiyat == null)
            {
                return null;
            }
            return new FiyatDto
            {
                FiyatID = fiyat.fiyatID,
                AlisFiyati = fiyat.alisFiyati,
                SatisFiyati = fiyat.satisFiyati,
                GuncellemeTarihi = fiyat.guncellemeTarihi
            };
        }

        public async Task<FiyatDto> CreateAsync(FiyatEkleDto fiyatEkleDto)
        {
            var fiyat = new Fiyat
            {
                alisFiyati = fiyatEkleDto.AlisFiyati,
                satisFiyati = fiyatEkleDto.SatisFiyati,
                guncellemeTarihi = DateTime.Now
            };

            _context.FiyatTable.Add(fiyat);
            await _context.SaveChangesAsync();
            return new FiyatDto
            {
                FiyatID = fiyat.fiyatID,
                AlisFiyati = fiyat.alisFiyati,
                SatisFiyati = fiyat.satisFiyati,
                GuncellemeTarihi = fiyat.guncellemeTarihi
            };
        }

        public async Task<FiyatDto> UpdateAsync(int fiyatId, FiyatGuncelleDto fiyatGuncelleDto)
        {
            var fiyat = _context.FiyatTable.Find(fiyatId);
            if (fiyat == null)
            {
                return null;
            }

            fiyat.alisFiyati = fiyatGuncelleDto.AlisFiyati;
            fiyat.satisFiyati = fiyatGuncelleDto.SatisFiyati;
            fiyat.guncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return new FiyatDto
            {
                FiyatID = fiyat.fiyatID,
                AlisFiyati = fiyat.alisFiyati,
                SatisFiyati = fiyat.satisFiyati,
                GuncellemeTarihi = fiyat.guncellemeTarihi
            };

        }
        public async Task<bool> DeleteAsync(int fiyatId)
        {
            var fiyat = await _context.FiyatTable.FindAsync(fiyatId);

            if (fiyat == null)
            {
                return false;
            }

            _context.FiyatTable.Remove(fiyat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
