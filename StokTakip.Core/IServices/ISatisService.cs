using StokTakip.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface ISatisService
    {
        Task<List<SatisDto>> GetAllAsync();
        Task<SatisDto> GetByIdAsync(int satisId);
        Task<SatisDetayDto> GetDetayByIdAsync(int satisId);
        Task<SatisDto> AddAsync(SatisEkleDto satisEkleDto);
    }
}