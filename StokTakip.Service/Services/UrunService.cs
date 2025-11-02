using StokTakip.Core.DTOs;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IServices;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class UrunService : IUrunService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UrunService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UrunDto>> GetAllAsync()
        {
            var urunler = await _unitOfWork.Urunler.GetAllAsync();

            return urunler.Select(u => new UrunDto
            {
                urunID = u.urunID,
                urunAdi = u.urunAdi,
                barkodNo = u.barkodNo,
                resim = u.resim,
                alisTarihi = u.alisTarihi,
                sonTuketimTarihi = u.sonTuketimTarihi,
                kategoriID = u.kategoriID,
                tedarikciID = u.tedarikciID,
                fiyatID = u.fiyatID
            }).ToList();
        }

        public async Task<UrunDto> GetByIdAsync(int urunId)
        {
            var urun = await _unitOfWork.Urunler.GetByIdAsync(urunId);
            if (urun == null) return null;

            return new UrunDto
            {
                urunID = urun.urunID,
                urunAdi = urun.urunAdi,
                barkodNo = u.barkodNo,
                resim = uun.resim,
                alisTarihi = urun.alisTarihi,
                sonTuketimTarihi = urun.sonTuketimTarihi,
                kategoriID = urun.kategoriID,
                tedarikciID = urun.tedarikciID,
                fiyatID = urun.fiyatID
            };
        }

        public async Task<UrunDetayDto> GetDetayByIdAsync(int urunId)
        {
            var urun = await _unitOfWork.Urunler.GetUrunDetayByIdAsync(urunId);

            if (urun == null) return null;

            var satisGecmisi = urun.SatisDetaylari.Select(sd => new SatisUrunDetayDto
            {
                UrunID = sd.urunID,
                UrunAdi = urun.urunAdi,
                Miktar = sd.Miktar,
                SatisFiyati = sd.SatisFiyati
            }).ToList();

            return new UrunDetayDto
            {
                urunID = urun.urunID,
                urunAdi = urun.urunAdi,
                barkodNo = urun.barkodNo,
                resim = urun.resim,
                alisTarihi = urun.alisTarihi,
                sonTuketimTarihi = urun.sonTuketimTarihi,

                Kategori = urun.Kategori != null ? new KategoriDto { KategoriID = urun.Kategori.kategoriID, KategoriAdi = urun.Kategori.kategoriAdi, Yeri = urun.Kategori.yeri } : null,
                Tedarikci = urun.Tedarikci != null ? new TedarikciDto { tedarikciID = urun.Tedarikci.tedarikciID, tedarikciAdi = urun.Tedarikci.tedarikciAdi, yetkili = urun.Tedarikci.yetkili, iletisim = urun.Tedarikci.iletisim, adres = urun.Tedarikci.adres } : null,
                Fiyat = urun.Fiyat != null ? new FiyatDto { FiyatID = urun.Fiyat.fiyatID, AlisFiyati = urun.Fiyat.alisFiyati, SatisFiyati = urun.Fiyat.satisFiyati, GuncellemeTarihi = urun.Fiyat.guncellemeTarihi } : null,
                Stok = urun.Stok != null ? new StokDto { stokID = urun.Stok.stokID, toplamStokMiktari = urun.Stok.toplamStokMiktari, kalanStokMiktari = urun.Stok.kalanStokMiktari, islemTarihi = urun.Stok.islemTarihi } : null,
                SatisGecmisi = satisGecmisi
            };
        }

        public async Task<UrunDto> AddAsync(UrunEkleDto urunEkleDto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var fiyat = new Fiyat
                {
                    alisFiyati = urunEkleDto.AlisFiyati,
                    satisFiyati = urunEkleDto.SatisFiyati,
                    guncellemeTarihi = DateTime.Now
                };
                await _unitOfWork.Fiyatlar.AddAsync(fiyat);
                await _unitOfWork.SaveChangesAsync();

                var urun = new Urun
                {
                    urunAdi = urunEkleDto.urunAdi,
                    barkodNo = urunEkleDto.barkodNo,
                    resim = urunEkleDto.resim,
                    alisTarihi = urunEkleDto.alisTarihi,
                    sonTuketimTarihi = urunEkleDto.sonTuketimTarihi,
                    kategoriID = urunEkleDto.kategoriID,
                    tedarikciID = urunEkleDto.tedarikciID,
                    fiyatID = fiyat.fiyatID
                };
                await _unitOfWork.Urunler.AddAsync(urun);
                await _unitOfWork.SaveChangesAsync();

                var stok = new Stok
                {
                    urunID = urun.urunID,
                    toplamStokMiktari = urunEkleDto.ToplamStokMiktari,
                    kalanStokMiktari = urunEkleDto.ToplamStokMiktari,
                    islemTarihi = DateTime.Now
                };
                await _unitOfWork.Stoklar.AddAsync(stok);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

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
                    fiyatID = urun.fiyatID
                };
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<UrunDto> UpdateAsync(int urunId, UrunGuncelleDto urunGuncelleDto)
        {
            var urun = await _unitOfWork.Urunler.GetByIdAsync(urunId);
            if (urun == null) return null;

            urun.urunAdi = urunGuncelleDto.urunAdi;
            urun.barkodNo = urunGuncelleDto.barkodNo;
            urun.resim = urunGuncelleDto.resim;
            urun.alisTarihi = urunGuncelleDto.alisTarihi;
            urun.sonTuketimTarihi = urunGuncelleDto.sonTuketimTarihi;
            urun.kategoriID = urunGuncelleDto.kategoriID;
            urun.tedarikciID = urunGuncelleDto.tedarikciID;

            await _unitOfWork.Urunler.UpdateAsync(urun);
            await _unitOfWork.SaveChangesAsync();

            return await GetByIdAsync(urun.urunID);
        }

        public async Task<bool> DeleteAsync(int urunId)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var urun = await _unitOfWork.Urunler.GetByIdAsync(urunId);
                if (urun == null)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }

                var stok = await _unitOfWork.Stoklar.SingleOrDefaultAsync(s => s.urunID == urunId);
                if (stok != null)
                {
                    await _unitOfWork.Stoklar.DeleteAsync(stok);
                }

                var fiyat = await _unitOfWork.Fiyatlar.GetByIdAsync(urun.fiyatID);
                if (fiyat != null)
                {
                    await _unitOfWork.Fiyatlar.DeleteAsync(fiyat);
                }
                
                await _unitOfWork.Urunler.DeleteAsync(urun);
                
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                
                return true;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}