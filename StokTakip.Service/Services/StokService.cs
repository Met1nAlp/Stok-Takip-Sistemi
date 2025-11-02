using StokTakip.Core.DTOs;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IServices;
using StokTakip.Entity.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class StokService : IStokService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StokService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task StokAzalt(int urunId, int satilanMiktar)
        {
            var stok = await _unitOfWork.Stoklar.SingleOrDefaultAsync(s => s.urunID == urunId);
            if (stok == null)
            {
                throw new Exception($"Satılmaya çalışılan ürünün (ID: {urunId}) stoğu bulunamadı.");
            }

            if (stok.kalanStokMiktari < satilanMiktar)
            {
                throw new Exception($"Yetersiz stok. Ürün ID: {urunId}, Kalan: {stok.kalanStokMiktari}, İstenen: {satilanMiktar}");
            }

            stok.kalanStokMiktari -= satilanMiktar;
            stok.islemTarihi = DateTime.Now;

            await _unitOfWork.Stoklar.UpdateAsync(stok);
        }


        public async Task<StokDto> GetByIdAsync(int stokId)
        {
            var stok = await _unitOfWork.Stoklar.GetByIdAsync(stokId);
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
            var stok = await _unitOfWork.Stoklar.SingleOrDefaultAsync(s => s.urunID == urunId);
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

            await _unitOfWork.Stoklar.AddAsync(stok);
            await _unitOfWork.SaveChangesAsync();

            return await GetByIdAsync(stok.stokID);
        }

        public async Task<StokDto> UpdateAsync(int stokId, StokGuncelleDto stokGuncelleDto)
        {
            var stok = await _unitOfWork.Stoklar.GetByIdAsync(stokId);
            if (stok == null) return null;

            stok.toplamStokMiktari = stokGuncelleDto.toplamStokMiktari;
            stok.kalanStokMiktari = stokGuncelleDto.kalanStokMiktari;
            stok.islemTarihi = DateTime.Now;

            await _unitOfWork.Stoklar.UpdateAsync(stok);
            await _unitOfWork.SaveChangesAsync();
            return await GetByIdAsync(stok.stokID);
        }

        public async Task<bool> DeleteAsync(int stokId)
        {
            var stok = await _unitOfWork.Stoklar.GetByIdAsync(stokId);
            if (stok == null) return false;

            await _unitOfWork.Stoklar.DeleteAsync(stok);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}