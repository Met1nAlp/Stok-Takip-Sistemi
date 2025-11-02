using StokTakip.Core.IRopositories;
using StokTakip.Data.Context;
using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Repositories
{
    public class SatisDetayRepository : Repository<SatisDetay>, ISatisDetayRepository
    {
        public SatisDetayRepository(StokTakipDbContext context) : base(context)
        {
        }
    }
}