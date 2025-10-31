using StokTakip.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface IPersonelService
    {
        Task<List<PersonelDto>> GetAllAsync();
        Task<PersonelDto> GetByIdAsync(int personelId);
        Task<PersonelDetayDto> GetDetayByIdAsync(int personelId);
        Task<PersonelDto> AddAsync(PersonelEkleDto personelEkleDto);
        Task<PersonelDto> UpdateAsync(int personelId, PersonelGuncelleDto personelGuncelleDto);
        Task<bool> DeleteAsync(int personelId);
    }
}