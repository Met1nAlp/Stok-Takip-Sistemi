using StokTakip.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface IFiyatService
    {
        Task<FiyatDto> GetByIdAsync(int fiyatId);
        Task<List<FiyatDto>> GetAllAsync();
        Task<FiyatDto> CreateAsync(FiyatEkleDto fiyatEkleDto);
        Task<FiyatDto> UpdateAsync(int fiyatId, FiyatGuncelleDto fiyatGuncelleDto);
        Task<bool> DeleteAsync(int fiyatId);
    }
}