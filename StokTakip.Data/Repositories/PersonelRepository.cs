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

        public async Task<Personel> GetPersonelByIdAsync(int personelId)
        {
            return await _context.PersonelTable
                .Include(p => p.SatisTable)
                .SingleOrDefaultAsync(p => p.personelID == personelId);
        }

    }
}
