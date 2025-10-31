using StokTakip.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface ITedarikciService
    {
        Task<List<TedarikciDto>> GetAllAsync();
        Task<TedarikciDto> GetByIdAsync(int tedarikciId);
        Task<TedarikciDetayDto> GetDetayByIdAsync(int tedarikciId);
        Task<TedarikciDto> AddAsync(TedarikciEkleDto tedarikciEkleDto);
        Task<TedarikciDto> UpdateAsync(int tedarikciId, TedarikciGuncelleDto tedarikciGuncelleDto);
        Task<bool> DeleteAsync(int tedarikciId);
    }
}