using Microsoft.EntityFrameworkCore;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly StokTakipDbContext _context;

        public KategoriService(StokTakipDbContext context)
        {
            _context = context;
        }

        public async     Task<List<KategoriDto>> GetAllCategoriesAsync()
        {
            var kategori = await _context.KategoriTable.ToListAsync();

            return kategori.Select(k => new KategoriDto
            {
                KategoriID = k.kategoriID,
                KategoriAdi = k.kategoriAdi,
                Yeri = k.yeri
            }).ToList();

        }

        public async Task<KategoriDto> GetCategoryByIdAsync(int kategoriID)
        {
            var kategori = await _context.KategoriTable.FindAsync(kategoriID);

            if (kategori == null)
            {
                return null;
            }
            return new KategoriDto
            {
                KategoriID = kategori.kategoriID,
                KategoriAdi = kategori.kategoriAdi,
                Yeri = kategori.yeri
            };
        }

        public async Task<KategoriDto> AddCategoryAsync(KategoriEkleDto kategoriEkleDto)
        {
            var kategori = new Kategori
            {
                kategoriAdi = kategoriEkleDto.KategoriAdi,
                yeri = kategoriEkleDto.Yeri
            };
            _context.KategoriTable.Add(kategori);
            await _context.SaveChangesAsync();
            return new KategoriDto
            {
                KategoriAdi = kategori.kategoriAdi,
                Yeri = kategori.yeri
            };
        }

        public async Task<KategoriDto> UpdateCategoryAsync(int kategoriId, KategoriGuncelleDto kategoriGuncelleDto)
        {
            var kategori = await _context.KategoriTable.FindAsync(kategoriId);
            if (kategori == null)
            {
                return null;
            }
            kategori.kategoriAdi = kategoriGuncelleDto.KategoriAdi;
            kategori.yeri = kategoriGuncelleDto.Yeri;
            await _context.SaveChangesAsync();
            return new KategoriDto
            {
                KategoriID = kategori.kategoriID,
                KategoriAdi = kategori.kategoriAdi,
                Yeri = kategori.yeri
            };
        }

        public async Task<bool> DeleteCategoryAsync(int kategoriID)
        {
            var kategori = await _context.KategoriTable.FindAsync(kategoriID);
            if (kategori == null)
            {
                return false;
            }
            _context.KategoriTable.Remove(kategori);
            await _context.SaveChangesAsync();
            return true;
        }

        

        

        
    }
}
