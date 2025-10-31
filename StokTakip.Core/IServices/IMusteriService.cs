using StokTakip.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.IServices
{
    public interface IMusteriService
    {
        Task<List<MusteriDto>> GetAllMusterilerAsync();
        Task<MusteriDto> GetMusteriByIdAsync(int musteriID);
        Task<MusteriDto> AddMusteriAsync(MusteriEkleDto musteriEkleDto);
        Task<MusteriDto> UpdateMusteriAsync(int musteriID, MusteriGuncelleDto musteriGuncelleDto);
        Task<bool> DeleteMusteriAsync(int musteriID);
    }
}
