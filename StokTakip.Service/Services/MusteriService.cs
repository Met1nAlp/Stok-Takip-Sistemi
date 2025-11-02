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
    public class MusteriService : IMusteriService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MusteriService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MusteriDto>> GetAllMusterilerAsync()
        {
            var musteri = await _unitOfWork.Musteriler.GetAllAsync();

            if (musteri == null)
            {
                return null;
            }

            return musteri.Select(k => new MusteriDto
            {
                musteriID = k.musteriID,
                musteriAdi = k.musteriAdi,
                musteriNo = k.musteriNo,
                iletisim = k.iletisim,
                kayitTarihi = k.kayitTarihi
            }).ToList();
        }

        public async Task<MusteriDto> GetMusteriByIdAsync(int musteriID)
        {
            var musteri = await _unitOfWork.Musteriler.GetByIdAsync(musteriID);

            if (musteri == null)
            {
                return null;
            }

            return new MusteriDto
            {
                musteriID = musteri.musteriID,
                musteriAdi = musteri.musteriAdi,
                musteriNo = musteri.musteriNo,
                iletisim = musteri.iletisim,
                kayitTarihi = musteri.kayitTarihi
            };
        }

        public async Task<MusteriDto> AddMusteriAsync(MusteriEkleDto musteriEkleDto)
        {
            var musteri = new Musteri
            {
                musteriAdi = musteriEkleDto.musteriAdi,
                musteriNo = musteriEkleDto.musteriNo,
                iletisim = musteriEkleDto.iletisim,
                kayitTarihi = DateTime.Now,
            };

            await _unitOfWork.Musteriler.AddAsync(musteri);
            await _unitOfWork.SaveChangesAsync();

            return new MusteriDto
            {
                musteriID = musteri.musteriID,
                musteriAdi = musteri.musteriAdi,
                musteriNo = musteri.musteriNo,
                iletisim = musteri.iletisim,
                kayitTarihi = musteri.kayitTarihi
            };
        }
        public async Task<MusteriDto> UpdateMusteriAsync(int musteriID, MusteriGuncelleDto musteriGuncelleDto)
        {
            var musteri = await _unitOfWork.Musteriler.GetByIdAsync(musteriID);

            if (musteri == null)
            {
                return null;
            }

            musteri.musteriAdi = musteriGuncelleDto.musteriAdi;
            musteri.musteriNo = musteriGuncelleDto.musteriNo;
            musteri.iletisim = musteriGuncelleDto.iletisim;

            await _unitOfWork.Musteriler.UpdateAsync(musteri);
            await _unitOfWork.SaveChangesAsync();

            return new MusteriDto
            {
                musteriID = musteri.musteriID,
                musteriAdi = musteri.musteriAdi,
                musteriNo = musteri.musteriNo,
                iletisim = musteri.iletisim,
                kayitTarihi = musteri.kayitTarihi
            };
        }

        public async Task<bool> DeleteMusteriAsync(int musteriID)
        {
            var musteri = await _unitOfWork.Musteriler.GetByIdAsync(musteriID);

            if (musteri == null)
            {
                return false;
            }

            await _unitOfWork.Musteriler.DeleteAsync(musteri);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}