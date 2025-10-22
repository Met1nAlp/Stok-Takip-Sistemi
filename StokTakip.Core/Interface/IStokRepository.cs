using StokTakip.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IStokRepository
    {
        Task<IEnumerable<Stok>> GetStokID(int stokID);
        Task<IEnumerable<Stok>> GetToplamStokMiktari(int toplamStokMiktari);
        Task<IEnumerable<Stok>> GetKalanStokMiktari(int kalanStokMiktari);
        Task<IEnumerable<Stok>> GetIslemTarihi(DateTime islemTarihi);
    }
}
