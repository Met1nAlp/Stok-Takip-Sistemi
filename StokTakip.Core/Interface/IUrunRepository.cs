using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Core.Interface
{
    public interface IUrunRepository : IRepository<Urun>
    {
        Task<Urun> GetUrunDetayByIdAsync(int urunId);
        Task<IEnumerable<Urun>> GetTumUrunDetaylariAsync();
    }
}
