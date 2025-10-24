using Microsoft.EntityFrameworkCore;
using StokTakip.Core.Interface;
using StokTakip.Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    internal class PersonelRepository : Repository<Personel>, IPersonelRepository
    {
        public PersonelRepository(StokTakip.Data.Context.StokTakipDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Personel>> GetPersonelID(int personelID)
        {
            var personel = await _context.PersonelTable.FindAsync(personelID);
            if (personel == null)
            {
                return new List<Personel>();
            }
            return new List<Personel> { personel };
        }
        public async Task<IEnumerable<Personel>> GetPersonelAdi(string personelAdi)
        {
            return await _context.PersonelTable
                .Where(p => p.personelAdi.Contains(personelAdi))
                .ToListAsync();
        }
        public async Task<IEnumerable<Personel>> GetPersonelNo(int personelNo)
        {
            return await _context.PersonelTable.Where(p => p.personelNo == personelNo).ToListAsync();
        }
        public async Task<IEnumerable<Personel>> GetUnvani(string unvani)
        {
            return await _context.PersonelTable
                .Where(p => p.unvani.Contains(unvani))
                .ToListAsync();
        }
        public async Task<IEnumerable<Personel>> GetIletisim(string iletisim)
        {
            return await _context.PersonelTable
                .Where(p => p.iletisim.Contains(iletisim))
                .ToListAsync();
        }
        public async Task<IEnumerable<Personel>> GetIseBaslamaTarihi(DateTime iseBaslamaTarihi)
        {
            return await _context.PersonelTable
                .Where(p => p.iseBaslmaTarihi.Date == iseBaslamaTarihi.Date)
                .ToListAsync();
        }
        public async Task<IEnumerable<Personel>> GetCalismaGunleri(string calismaGunleri)
        {
            return await _context.PersonelTable
                .Where(p => p.calismaGunleri.Contains(calismaGunleri))
                .ToListAsync();
        }
        public async Task<IEnumerable<Personel>> GetMesaisi(string mesaisi)
        {
            return await _context.PersonelTable
                .Where(p => p.mesaisi.Contains(mesaisi))
                .ToListAsync();
        }

    }
}
