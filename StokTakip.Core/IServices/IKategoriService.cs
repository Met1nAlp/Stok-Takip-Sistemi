using StokTakip.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetAllCategoriesAsync();
        Task<KategoriDto> GetCategoryByIdAsync(int kategoriID);
        Task<KategoriDto> AddCategoryAsync(KategoriEkleDto kategoriEkleDto);
        Task<KategoriDto> UpdateCategoryAsync(int kategoriId, KategoriGuncelleDto kategoriGuncelleDto);
        Task<bool> DeleteCategoryAsync(int kategoriID);
    }
}