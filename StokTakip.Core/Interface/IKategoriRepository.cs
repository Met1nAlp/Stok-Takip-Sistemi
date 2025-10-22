using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IKategoriRepository
    {
        Task<IEnumerable<Kategori>> GetKategoriID(int kategoriID);
        Task<IEnumerable<Kategori>> GetKategoriAdi(string kategoriAdi);
        Task<IEnumerable<Kategori>> GetYeri(string yeri);
    }
}
