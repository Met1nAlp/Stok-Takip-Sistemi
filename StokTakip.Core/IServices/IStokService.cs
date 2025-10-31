using StokTakip.Core.DTOs;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface IStokService
    {
        Task<StokDto> GetByIdAsync(int stokId);
        Task<StokDto> GetStokByUrunIdAsync(int urunId);
        Task<StokDto> AddAsync(StokEkleDto stokEkleDto);
        Task<StokDto> UpdateAsync(int stokId, StokGuncelleDto stokGuncelleDto);
        Task<bool> DeleteAsync(int stokId);
    }
}