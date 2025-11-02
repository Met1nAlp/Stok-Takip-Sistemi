using Microsoft.EntityFrameworkCore.Storage;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IRopositories;
using StokTakip.Data.Context;
using StokTakip.Data.Repositories; // Eklendi
using System;
using System.Threading.Tasks;

namespace StokTakip.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StokTakipDbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;

        private UrunRepository _urunRepository;
        private KategoriRepository _kategoriRepository;
        private FiyatRepository _fiyatRepository;
        private StokRepository _stokRepository;
        private SatisRepository _satisRepository;
        private MusteriRepository _musteriRepository;
        private PersonelRepository _personelRepository;
        private TedarikciRepository _tedarikciRepository;
        private SatisDetayRepository _satisDetayRepository; // YENİ

        public UnitOfWork(StokTakipDbContext context)
        {
            _context = context;
        }

        public IUrunRepository Urunler => (IUrunRepository)(_urunRepository ??= new UrunRepository(_context));
        public IKategoriRepository Kategoriler => (IKategoriRepository)(_kategoriRepository ??= new KategoriRepository(_context));
        public IFiyatRepository Fiyatlar => (IFiyatRepository)(_fiyatRepository ??= new FiyatRepository(_context));
        public IStokRepository Stoklar => (IStokRepository)(_stokRepository ??= new StokRepository(_context));
        public ISatisRepository Satislar => (ISatisRepository)(_satisRepository ??= new SatisRepository(_context));
        public IMusteriRepository Musteriler => (IMusteriRepository)(_musteriRepository ??= new MusteriRepository(_context));
        public IPersonelRepository Personeller => (IPersonelRepository)(_personelRepository ??= new PersonelRepository(_context));
        public ITedarikciRepository Tedarikciler => (ITedarikciRepository)(_tedarikciRepository ??= new TedarikciRepository(_context));
        public ISatisDetayRepository SatisDetaylar =>(ISatisDetayRepository)(_satisDetayRepository ??= new SatisDetayRepository(_context)); 

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return;
            }
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction başlatılmamış.");
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction başlatılmamış.");
            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}