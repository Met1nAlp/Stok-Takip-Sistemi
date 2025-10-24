using Microsoft.EntityFrameworkCore;
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
    internal class SatisRepository : Repository<Satis>, ISatisRepository
    {
        public SatisRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Satis>> GetAraToplam(decimal araToplam)
        {
            return _context.SatisTable
                .Where(s => s.araToplam == araToplam);
        }

        public async Task<IEnumerable<Satis>> GetIslemTarihi(DateTime islemTarihi)
        {
            return _context.SatisTable
                .Where(s => s.islemTarihi == islemTarihi);
        }

        public async Task<IEnumerable<Satis>> GetMusteriID(int musteriID)
        {
            return _context.SatisTable
                .Where(s => s.musteriID == musteriID);
        }

        public async Task<IEnumerable<Satis>> GetOdemeTipi(string odemeTipi)
        {
            return _context.SatisTable
                .Where(s => s.odemeTipi == odemeTipi);
        }

        public async Task<IEnumerable<Satis>> GetPersonelID(int personelID)
        {
            return _context.SatisTable
                .Where(s => s.personelID == personelID);
        }

        public async Task<IEnumerable<Satis>> GetSatisID(int satisID)
        {
            var satis = await _context.SatisTable.FindAsync(satisID);
            if (satis == null)
            {
                return new List<Satis>();
            }
            return new List<Satis> { satis };
        }

        public async Task<IEnumerable<Satis>> GetToplamTutar(decimal toplamTutar)
        {
            return _context.SatisTable
                .Where(s => s.toplamTutar == toplamTutar);
        }

        public async Task<IEnumerable<Satis>> GetUrunlerinAdiFiyati(string urunlerinAdiFiyati)
        {
            return _context.SatisTable
                .Where(s => s.urunlerinAdiFiyati == urunlerinAdiFiyati);
        }

        public async Task<IEnumerable<Satis>> GetVergiTutarlari(decimal vergiTutarlari)
        {
            return _context.SatisTable
                .Where(s => s.vergiTutarlari == vergiTutarlari);
        }
    }
}
