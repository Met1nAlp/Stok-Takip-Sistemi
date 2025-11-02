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
    public class SatisService : ISatisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStokService _stokService; 

        public SatisService(IUnitOfWork unitOfWork, IStokService stokService)
        {
            _unitOfWork = unitOfWork;
            _stokService = stokService;
        }

        public async Task<SatisDto> AddAsync(SatisEkleDto satisEkleDto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                decimal hesaplananToplamTutar = 0;
                var urunFiyatListesi = new Dictionary<int, decimal>();

                foreach (var satilanUrun in satisEkleDto.SatilanUrunler)
                {
                    var stok = await _unitOfWork.Stoklar.SingleOrDefaultAsync(s => s.urunID == satilanUrun.UrunID);
                    if (stok == null || stok.kalanStokMiktari < satilanUrun.Miktar)
                    {
                        throw new Exception($"Yetersiz stok: UrunID {satilanUrun.UrunID}");
                    }

                    var urun = await _unitOfWork.Urunler.GetByIdAsync(satilanUrun.UrunID);
                    var fiyat = await _unitOfWork.Fiyatlar.GetByIdAsync(urun.fiyatID);

                    decimal satisFiyati = fiyat.satisFiyati;
                    urunFiyatListesi.Add(urun.urunID, satisFiyati); 
                    hesaplananToplamTutar += satisFiyati * satilanUrun.Miktar;
                }

                var satis = new Satis
                {
                    musteriID = satisEkleDto.MusteriID,
                    personelID = satisEkleDto.PersonelID,
                    odemeTipi = satisEkleDto.OdemeTipi,
                    islemTarihi = DateTime.Now,
                    toplamTutar = hesaplananToplamTutar,
                    araToplam = hesaplananToplamTutar, 
                    vergiTutarlari = 0 
                };

                await _unitOfWork.Satislar.AddAsync(satis);
                await _unitOfWork.SaveChangesAsync(); 

                foreach (var satilanUrun in satisEkleDto.SatilanUrunler)
                {
                    var satisDetay = new SatisDetay
                    {
                        satisID = satis.satisID,
                        urunID = satilanUrun.UrunID,
                        Miktar = satilanUrun.Miktar,
                        SatisFiyati = urunFiyatListesi[satilanUrun.UrunID] 
                    };
                    await _unitOfWork.SatisDetaylar.AddAsync(satisDetay);

                    await _stokService.StokAzalt(satilanUrun.UrunID, satilanUrun.Miktar);
                }

                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitAsync();

                return await GetByIdAsync(satis.satisID); 
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw; 
            }
        }

      

        public async Task<SatisDetayDto> GetDetayByIdAsync(int satisId)
        {
            var satis = await _unitOfWork.Satislar.GetSatisDetayByIdAsync(satisId);
            if (satis == null) return null;

            var personel = await _unitOfWork.Personeller.GetByIdAsync(satis.personelID);
            var musteri = await _unitOfWork.Musteriler.GetByIdAsync(satis.musteriID);
            var satisDetaylari = await _unitOfWork.SatisDetaylar.FindAsync(sd => sd.satisID == satisId);
            var urunDetaylari = new List<SatisUrunDetayDto>();

            foreach (var detay in satisDetaylari)
            {
                var urun = await _unitOfWork.Urunler.GetByIdAsync(detay.urunID);
                urunDetaylari.Add(new SatisUrunDetayDto
                {
                    UrunID = urun.urunID,
                    UrunAdi = urun.urunAdi,
                    Miktar = detay.Miktar,
                    SatisFiyati = detay.SatisFiyati
                });
            }

            return new SatisDetayDto
            {
                SatisID = satis.satisID,
                ToplamTutar = satis.toplamTutar,
                OdemeTipi = satis.odemeTipi,
                IslemTarihi = satis.islemTarihi,
                PersonelDetay = new PersonelDto {  },
                MusteriDetay = new MusteriDto {  },
                SatilanUrunler = urunDetaylari
            };
        }

        public async Task<List<SatisDto>> GetAllAsync()
        {
            return new List<SatisDto>(); 
        }

        public async Task<SatisDto> GetByIdAsync(int satisId)
        {
            return new SatisDto(); 
        }
    }
}