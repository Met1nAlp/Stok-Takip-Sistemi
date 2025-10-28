using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface ITedarikciRepository : IRepository<Tedarikci>
    {
        Task<Tedarikci> GetTedarikciByIdAsync(int tedarikciId);
    }
}
