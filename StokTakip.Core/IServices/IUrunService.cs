using StokTakip.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface IUrunService
    {
        Task<List<UrunDto>> GetAllAsync();
        Task<UrunDto> GetByIdAsync(int urunId);
        Task<UrunDetayDto> GetDetayByIdAsync(int urunId);
        Task<UrunDto> AddAsync(UrunEkleDto urunEkleDto);
        Task<UrunDto> UpdateAsync(int urunId, UrunGuncelleDto urunGuncelleDto);
        Task<bool> DeleteAsync(int urunId);
    }
}