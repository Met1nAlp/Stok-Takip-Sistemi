using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StokTakip.Core.DTOs;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IServices;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;

namespace StokTakip.Service.Services
{
    public class FiyatService : IFiyatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FiyatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<FiyatDto>> GetAllAsync()
        {
            var fiyatlar = await _unitOfWork.Fiyatlar.GetAllAsync();

            if (fiyatlar == null)
            {
                return null;
            }

            return fiyatlar.Select(f => new FiyatDto
            {
                FiyatID = f.fiyatID,
                AlisFiyati = f.alisFiyati,
                SatisFiyati = f.satisFiyati,
                GuncellemeTarihi = f.guncellemeTarihi
            }).ToList();
        }

        public async Task<FiyatDto> GetByIdAsync(int fiyatId)
        {
            var fiyat = await _unitOfWork.Fiyatlar.GetByIdAsync(fiyatId);

            if (fiyat == null)
            {
                return null;
            }

            return new FiyatDto
            {
                FiyatID = fiyat.fiyatID,
                AlisFiyati = fiyat.alisFiyati,
                SatisFiyati = f.satisFiyati,
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

            await _unitOfWork.Fiyatlar.AddAsync(fiyat);
            await _unitOfWork.SaveChangesAsync();

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
            var fiyat = await _unitOfWork.Fiyatlar.GetByIdAsync(fiyatId);

            if (fiyat == null)
            {
                return null;
            }

            fiyat.alisFiyati = fiyatGuncelleDto.AlisFiyati;
            fiyat.satisFiyati = fiyatGuncelleDto.SatisFiyati;
            fiyat.guncellemeTarihi = DateTime.Now;

            await _unitOfWork.Fiyatlar.UpdateAsync(fiyat);
            await _unitOfWork.SaveChangesAsync();

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
            var fiyat = await _unitOfWork.Fiyatlar.GetByIdAsync(fiyatId);

            if (fiyat == null)
            {
                return false;
            }

            await _unitOfWork.Fiyatlar.DeleteAsync(fiyat);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}