using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StokTakip.Entity.Entities;
namespace StokTakip.Data.Context
{
    public class StokTakipDbContext : DbContext
    {
        private readonly string _connectionString;



        public StokTakipDbContext(DbContextOptions<StokTakipDbContext> options ) : base(options)
        {
        }

        public DbSet<Tedarikci> TedarikciTable { get; set; }
        public DbSet<Stok> StokTable { get; set; }
        public DbSet<Kategori> KategoriTable { get; set; }
        public DbSet<Urun> UrunTable { get; set; }
        public DbSet<Fiyat> FiyatTable { get; set; }
        public DbSet<Satis> SatisTable { get; set; }
        public DbSet<Musteri> MusteriTable { get; set; }
        public DbSet<Personel> PersonelTable { get; set; }

        /*
         
        public async Task EnsureDatabaseCreatedAsync()
        {
            await using var connection = await CreateConnectionAsync();

            await CreateTedarikciTableAsync(connection);
            await CreateStokTableAsync(connection);
            await CreateKategoriTableAsync(connection);
            await CreateUrunTableAsync(connection);
            await CreateFiyatTableAsync(connection);
            await CreateSatisTableAsync(connection);
            await CreateMusteriTableAsync(connection);
            await CreatePersonelTableAsync(connection);
        }
        

        private async Task CreateTedarikciTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS Tedarikci (
                    tedarikciID SERIAL PRIMARY KEY,
                    tedarikciAdi VARCHAR(100) NOT NULL,
                    telefon VARCHAR(15),
                    iletisim VARCHAR(100),
                    adres TEXT
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreateStokTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS StokTable (
                    stokID SERIAL PRIMARY KEY,
                    toplamStokMiktari INT NOT NULL,
                    kalanStokMikatari INT NOT NULL,
                    islemTarihi TIMESTAMP NOT NULL,
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreateKategoriTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS KategoriTable (
                    kategoriID SERIAL PRIMARY KEY,
                    kategoriAdi VARCHAR(100) NOT NULL,
                    yeri TEXT
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreateFiyatTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS FiyatTable (
                    fiyatID SERIAL PRIMARY KEY,
                    alisFiyati DECIMAL(10, 2) NOT NULL,
                    satisFiyati DECIMAL(10, 2) NOT NULL,
                    guncellemeTarihi TIMESTAMP NOT NULL,
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreateMusteriTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS MusteriTable (
                    musteriID SERIAL PRIMARY KEY,
                    musteriAdi VARCHAR(100) NOT NULL,
                    musteriNo INTEGER NOT NULL,
                    iletisim VARCHAR(100),
                    kayitTarihi TIMESTAMP NOT NULL
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreatePersonelTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS PersonelTable (
                    personelID SERIAL PRIMARY KEY,
                    personelAdi VARCHAR(100) NOT NULL,
                    personelNo INTEGER NOT NULL,
                    unvani VARCHAR(100),
                    calismaDurumu VARCHAR(50) NOT NULL,
                    iletisim VARCHAR(100),
                    iseBaslamaTarihi TIMESTAMP NOT NULL,
                    calismaGunleri VARCHAR(100),
                    calismaSaatleri VARCHAR(100),
                    maasi DECIMAL(10, 2)
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreateSatisTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS SatisTable (
                    satisID SERIAL PRIMARY KEY,
                    urunlerinAdiFiyati TEXT NOT NULL,
                    miktar INT NOT NULL,
                    araToplam DECIMAL(10, 2) NOT NULL,
                    vergiTutari DECIMAL(10, 2) NOT NULL,
                    odemeTipi VARCHAR(50) NOT NULL,
                    islemTarihi TIMESTAMP NOT NULL,
                    musteriID INT NOT NULL,
                    personelID INT NOT NULL,
                    toplamFiyat DECIMAL(10, 2) NOT NULL,
                    FOREIGN KEY (musteriID) REFERENCES MusteriTable(musteriID),
                    FOREIGN KEY (personelID) REFERENCES PersonelTable(personelID)
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task CreateUrunTableAsync(NpgsqlConnection connection)
        {
            var commandText = @"
                CREATE TABLE IF NOT EXISTS UrunTable (
                    urunID SERIAL PRIMARY KEY,
                    urunAdi VARCHAR(100) NOT NULL,
                    barkodNo VARCHAR(50) NOT NULL,
                    resim VARCHAR(255),
                    alisTarihi TIMESTAMP NOT NULL,
                    sonTuketimTarihi TIMESTAMP NOT NULL,
                    kategoriID INT NOT NULL,
                    tedarikciID INT NOT NULL,
                    fiyatID INT NOT NULL,
                    stokID INT NOT NULL,
                    satisID INT,
                    FOREIGN KEY (stokID) REFERENCES StokTable(stokID),
                    FOREIGN KEY (kategoriID) REFERENCES KategoriTable(kategoriID),
                    FOREIGN KEY (tedarikciID) REFERENCES Tedarikci(tedarikciID),
                    FOREIGN KEY (fiyatID) REFERENCES FiyatTable(fiyatID),
                    FOREIGN KEY (satisID) REFERENCES SatisTable(satisID)
                );";
            await using var command = new NpgsqlCommand(commandText, connection);
            await command.ExecuteNonQueryAsync();
        }

        */
    }
}
