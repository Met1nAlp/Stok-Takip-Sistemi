using StokTakip.Core.Interface;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    internal class TedarikciReposiory : Repository<Tedarikci>, ITedarikciRepository
    {
        public TedarikciReposiory(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tedarikci>> GetTedarikciID(int tedarikciID)
        {
            var tedarikci = await _context.TedarikciTable.FindAsync(tedarikciID);
            if (tedarikci == null)
            {
                return new List<Tedarikci>();
            }
            return new List<Tedarikci> { tedarikci };
        }
        public async Task<IEnumerable<Tedarikci>> GetTedarikciAdi(string tedarikciAdi)
        {
            return _context.TedarikciTable.Where(t => t.tedarikciAdi == tedarikciAdi);
        }
        
        public async Task<IEnumerable<Tedarikci>> GetYetkili(string yetkili)
        {
            return _context.TedarikciTable.Where(t => t.yetkili == yetkili);
        }

        public async Task<IEnumerable<Tedarikci>> GetIletisim(string iletisim)
        {
            return _context.TedarikciTable.Where(t => t.iletisim == iletisim);
        }

        public async Task<IEnumerable<Tedarikci>> GetAdres(string adres)
        {
            return _context.TedarikciTable.Where(t => t.adres == adres);
        }
    }
}
