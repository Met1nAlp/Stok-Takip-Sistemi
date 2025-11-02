using StokTakip.Core.DTOs;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IServices;
using StokTakip.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Service.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PersonelDto>> GetAllAsync()
        {
            var personeller = await _unitOfWork.Personeller.GetAllAsync();

            return personeller.Select(p => new PersonelDto
            {
                personelID = p.personelID,
                personelAdi = p.personelAdi,
                personelNo = p.personelNo,
                unvani = p.unvani,
                iletisim = p.iletisim,
                iseBaslmaTarihi = p.iseBaslmaTarihi,
                calismaGunleri = p.calismaGunleri,
                mesaisi = p.mesaisi
            }).ToList();
        }

        public async Task<PersonelDto> GetByIdAsync(int personelId)
        {
            var personel = await _unitOfWork.Personeller.GetByIdAsync(personelId);
            if (personel == null) return null;

            return new PersonelDto
            {
                personelID = personel.personelID,
                personelAdi = personel.personelAdi,
                personelNo = personel.personelNo,
                unvani = personel.unvani,
                iletisim = personel.iletisim,
                iseBaslmaTarihi = personel.iseBaslmaTarihi,
                calismaGunleri = personel.calismaGunleri,
                mesaisi = personel.mesaisi
            };
        }

        public async Task<PersonelDetayDto> GetDetayByIdAsync(int personelId)
        {
            var personel = await _unitOfWork.Personeller.GetPersonelByIdAsync(personelId);

            if (personel == null) return null;

            return new PersonelDetayDto
            {
                personelID = personel.personelID,
                personelAdi = personel.personelAdi,
                personelNo = personel.personelNo,
                unvani = personel.unvani,
                iletisim = personel.iletisim,
                iseBaslmaTarihi = personel.iseBaslmaTarihi,
                calismaGunleri = personel.calismaGunleri,
                mesaisi = personel.mesaisi,
                satisGecmisi = personel.SatisTable.Select(s => new SatisDto
                {
                    SatisID = s.satisID,
                    ToplamTutar = s.toplamTutar,
                    IslemTarihi = s.islemTarihi,
                    OdemeTipi = s.odemeTipi,
                }).ToList()
            };
        }

        public async Task<PersonelDto> AddAsync(PersonelEkleDto personelEkleDto)
        {
            var personel = new Personel
            {
                personelAdi = personelEkleDto.personelAdi,
                personelNo = personelEkleDto.personelNo,
                unvani = personelEkleDto.unvani,
                iletisim = personelEkleDto.iletisim,
                iseBaslmaTarihi = personelEkleDto.iseBaslmaTarihi,
                calismaGunleri = personelEkleDto.calismaGunleri,
                mesaisi = personelEkleDto.mesaisi
            };

            await _unitOfWork.Personeller.AddAsync(personel);
            await _unitOfWork.SaveChangesAsync();

            return await GetByIdAsync(personel.personelID);
        }

        public async Task<PersonelDto> UpdateAsync(int personelId, PersonelGuncelleDto personelGuncelleDto)
        {
            var personel = await _unitOfWork.Personeller.GetByIdAsync(personelId);
            if (personel == null) return null;

            personel.personelAdi = personelGuncelleDto.personelAdi;
            personel.personelNo = personelGuncelleDto.personelNo;
            personel.unvani = personelGuncelleDto.unvani;
            personel.iletisim = personelGuncelleDto.iletisim;
            personel.iseBaslmaTarihi = personelGuncelleDto.iseBaslmaTarihi;
            personel.calismaGunleri = personelGuncelleDto.calismaGunleri;
            personel.mesaisi = personelGuncelleDto.mesaisi;

            await _unitOfWork.Personeller.UpdateAsync(personel);
            await _unitOfWork.SaveChangesAsync();
            return await GetByIdAsync(personel.personelID);
        }

        public async Task<bool> DeleteAsync(int personelId)
        {
            var personel = await _unitOfWork.Personeller.GetByIdAsync(personelId);
            if (personel == null) return false;

            await _unitOfWork.Personeller.DeleteAsync(personel);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}