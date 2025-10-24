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
    internal class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(StokTakipDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Urun>> GetUrunID(int urunID)
        {
            var urun = await _context.UrunTable.FindAsync(urunID);
            
            if (urun != null)
            {
                return new List<Urun>();
            }
                return new List<Urun> { urun };
        }

        public async Task<IEnumerable<Urun>> GetAlisTarihi(DateTime alisTarihi)
        {
            return _context.UrunTable
                           .Where(u => u.alisTarihi.Date == alisTarihi.Date);
        }

        public async Task<IEnumerable<Urun>> GetBarkodNo(string barkodNo)
        {
            return _context.UrunTable
                           .Where(u => u.barkodNo == barkodNo);
        }

        public async Task<IEnumerable<Urun>> GetResim(string resim)
        {
            return _context.UrunTable
                           .Where(u => u.resim == resim);
        }

        public async Task<IEnumerable<Urun>> GetSonTuketimTarihi(DateTime sonTuketimTarihi)
        {
            return _context.UrunTable
                           .Where(u => u.sonTuketimTarihi.Date == sonTuketimTarihi.Date);
        }

        public async Task<IEnumerable<Urun>> GetUrunAdi(string urunAdi)
        {
            return _context.UrunTable
                           .Where(u => u.urunAdi == urunAdi);
        }

        public async Task<IEnumerable<Urun>> GetUrunlerByFiyatIdAsync(int fiyatID)
        {
            return _context.UrunTable
                           .Where(u => u.fiyatID == fiyatID);
        }

        public async Task<IEnumerable<Urun>> GetUrunlerByKategoriIdAsync(int kategoriID)
        {
            return _context.UrunTable
                           .Where(u => u.kategoriID == kategoriID);
        }

        public async Task<IEnumerable<Urun>> GetUrunlerBySatisIdAsync(int satisID)
        {
            return _context.UrunTable
                           .Where(u => u.satisID == satisID);
        }

        public async Task<IEnumerable<Urun>> GetUrunlerByStokIdAsync(int stokID)
        {
            return _context.UrunTable
                           .Where(u => u.stokID == stokID);
        }

        public async Task<IEnumerable<Urun>> GetUrunlerByTedarikciIdAsync(int tedarikciID)
        {
            return _context.UrunTable
                           .Where(u => u.tedarikciID == tedarikciID);
        }
    }
}
