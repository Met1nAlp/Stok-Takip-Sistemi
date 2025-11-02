using StokTakip.Core.DTOs;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IServices;
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
        private readonly IUnitOfWork _unitOfWork;

        public KategoriService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<KategoriDto>> GetAllCategoriesAsync()
        {
            var kategori = await _unitOfWork.Kategoriler.GetAllAsync();

            return kategori.Select(k => new KategoriDto
            {
                KategoriID = k.kategoriID,
                KategoriAdi = k.kategoriAdi,
                Yeri = k.yeri
            }).ToList();
        }

        public async Task<KategoriDto> GetCategoryByIdAsync(int kategoriID)
        {
            var kategori = await _unitOfWork.Kategoriler.GetByIdAsync(kategoriID);

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
            await _unitOfWork.Kategoriler.AddAsync(kategori);
            await _unitOfWork.SaveChangesAsync();

            return new KategoriDto
            {
                KategoriID = kategori.kategoriID,
                KategoriAdi = kategori.kategoriAdi,
                Yeri = kategori.yeri
            };
        }

        public async Task<KategoriDto> UpdateCategoryAsync(int kategoriId, KategoriGuncelleDto kategoriGuncelleDto)
        {
            var kategori = await _unitOfWork.Kategoriler.GetByIdAsync(kategoriId);
            if (kategori == null)
            {
                return null;
            }
            kategori.kategoriAdi = kategoriGuncelleDto.KategoriAdi;
            kategori.yeri = kategoriGuncelleDto.Yeri;

            await _unitOfWork.Kategoriler.UpdateAsync(kategori);
            await _unitOfWork.SaveChangesAsync();

            return new KategoriDto
            {
                KategoriID = kategori.kategoriID,
                KategoriAdi = kategori.kategoriAdi,
                Yeri = kategori.yeri
            };
        }

        public async Task<bool> DeleteCategoryAsync(int kategoriID)
        {
            var kategori = await _unitOfWork.Kategoriler.GetByIdAsync(kategoriID);
            if (kategori == null)
            {
                return false;
            }
            await _unitOfWork.Kategoriler.DeleteAsync(kategori);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}