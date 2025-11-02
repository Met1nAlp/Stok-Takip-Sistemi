using StokTakip.Core.IRopositories;
using System;
using System.Threading.Tasks;

namespace StokTakip.Core.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUrunRepository Urunler { get; }
        IKategoriRepository Kategoriler { get; }
        IFiyatRepository Fiyatlar { get; }
        IStokRepository Stoklar { get; }
        ISatisRepository Satislar { get; }
        IMusteriRepository Musteriler { get; }
        IPersonelRepository Personeller { get; }
        ITedarikciRepository Tedarikciler { get; }
        ISatisDetayRepository SatisDetaylar { get; } 

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}