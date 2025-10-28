using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface ISatisRepository : IRepository<Satis>
    {
        Task<Satis> GetSatisDetayByIdAsync(int satisId);
        Task<IEnumerable<Satis>> GetTumSatisAsync();
    }
}
