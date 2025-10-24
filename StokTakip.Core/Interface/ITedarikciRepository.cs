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
        Task<IEnumerable<Tedarikci>> GetTedarikciID(int tedarikciID);
        Task<IEnumerable<Tedarikci>> GetTedarikciAdi(string tedarikciAdi);
        Task<IEnumerable<Tedarikci>> GetYetkili(string yetkili);
        Task<IEnumerable<Tedarikci>> GetIletisim(string iletisim);
        Task<IEnumerable<Tedarikci>> GetAdres(string adres);
    }
}
