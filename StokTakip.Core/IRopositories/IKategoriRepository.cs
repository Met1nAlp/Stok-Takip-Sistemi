using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.IRepositories
{
    public interface IKategoriRepository : IRepository<Kategori>
    {
        Task<Kategori> GetKategoriByIdAsync(int kategoriId);
    }
}
