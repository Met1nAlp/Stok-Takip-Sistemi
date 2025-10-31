using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.IRepositories
{
    public interface IPersonelRepository : IRepository<Personel>
    {
        Task<Personel> GetPersonelByIdAsync(int personelId);
    }
}
