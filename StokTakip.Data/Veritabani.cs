namespace StokTakip.Data
{
    using System;
    using Npgsql;
    using System.Threading.Tasks;
    using System.Data;
    using Microsoft.EntityFrameworkCore;

    public class Veritabani
    {
        static async Task Main(string[] args)
        {
            /*
            Console.WriteLine("Lütfen PostgreSQL veritabanı yönetici bilgilerinizi girin.");
            
            Console.Write("Veritabanı Kullanıcı Adı: ");
            string girilenKullaniciAdi = Console.ReadLine() ?? "";

            Console.Write("Veritabanı Parola: ");
            string girilenParola = Console.ReadLine() ?? "";
            */

            VeritabaniBaglantisi($"Host=localhost;Port=5432;Username=MetinAlp;Password=Alp.1046;Database=ilk_veritabani").Wait();


            Console.WriteLine("Veritabanı ve tablolar başarıyla oluşturuldu.");
        }

        static async Task VeritabaniBaglantisi(String connectionString)
        {
            await using var client = new NpgsqlConnection(connectionString);
            await client.OpenAsync();
            await VeritabaniKurulumu(client);
        }


        static async Task UrunleriGoruntule(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Ürün Listesi --");

            var urunGetir = new NpgsqlCommand("SELECT urunID, urunAdi, barkodNo, resim, alisTarihi, sonTuketimTarihi FROM UrunTable ORDER BY urunID", client);
            await using var reader = await urunGetir.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {

                int urunID = reader.GetInt32(0);
                string urunAdi = reader.GetString(1);
                string barkodNo = reader.GetString(2);
                string resim = reader.GetString(3);
                string alisTarihi = reader.GetString(4);
                string sonTuketimTarihi = reader.GetString(5);

                // nesne mynesne = new nesne(reader)
                Console.WriteLine($"ID: {reader.GetInt32(0)} | Ürün Adı: {reader.GetString(1)} | Barkod No: {reader.GetString(2)}");
                // console.writeline(mynesne.UrunId , mynesne.UrunAdi , mynesne.BarkodNo)
            }
        }
        static async Task UrunEkle(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Yeni Ürün Ekleme --");

            Console.Write("Ürün Adı: ");
            string urunAdi = Console.ReadLine() ?? "";
            Console.Write("Barkod No: ");
            string barkodNo = Console.ReadLine() ?? "";
            Console.Write("Resim URL'si: ");
            string resim = Console.ReadLine() ?? "";
            Console.Write("Alış Tarihi (YYYY-MM-DD): ");
            string alisTarihi = Console.ReadLine() ?? "";
            Console.Write("Son Tüketim Tarihi (YYYY-MM-DD): ");
            string sonTuketimTarihi = Console.ReadLine() ?? "";

            Console.WriteLine("\n-- Tedarikçi Bilgileri--");
            Console.Write("Firma Adı: ");
            string firmaAdi = Console.ReadLine() ?? "";
            Console.Write("Yetkili: ");
            string yetkili = Console.ReadLine() ?? "";
            Console.Write("İletişim: ");
            string iletisim = Console.ReadLine() ?? "";
            Console.Write("Adres: ");
            string adres = Console.ReadLine() ?? "";

            Console.WriteLine("\n-- Kategori Bilgileri--");
            Console.Write("Kategori Adı: ");
            string kategoriAdi = Console.ReadLine() ?? "";
            Console.Write("Yeri: ");
            string yeri = Console.ReadLine() ?? "";

            Console.WriteLine("\n-- Fiyat Bilgileri--");
            Console.Write("Fiyat: ");
            int fiyat = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Alış Fiyatı: ");
            int alisFiyati = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Güncelleme Tarihi (YYYY-MM-DD): ");
            string guncellemeTarihi = Console.ReadLine() ?? "";

            Console.WriteLine("\n-- Stok Bilgileri--");
            Console.Write("Toplam Stok Miktarı: ");
            int toplamStokMiktari = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Kalan Stok Miktarı: ");
            int kalanStokMiktari = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("İşlem Tarihi (YYYY-MM-DD): ");
            string islemTarihi = Console.ReadLine() ?? "";


            var tedarikciEkle = new NpgsqlCommand(
                "INSERT INTO TedarikciTable " +
                "(firmaAdi, yetkili, iletisim, adres) " +
                "VALUES " +
                "(@firmaAdi, @yetkili, @iletisim, @adres) RETURNING tedarikciID",
                client);
            tedarikciEkle.Parameters.AddWithValue("firmaAdi", firmaAdi);
            tedarikciEkle.Parameters.AddWithValue("yetkili", yetkili);
            tedarikciEkle.Parameters.AddWithValue("iletisim", iletisim);
            tedarikciEkle.Parameters.AddWithValue("adres", adres);
            int tedarikciID = (int)await tedarikciEkle.ExecuteScalarAsync();


            var kategoriEkle = new NpgsqlCommand(
                "INSERT INTO KategoriTable " +
                "(kategoriAdi, yeri) " +
                "VALUES " +
                "(@kategoriAdi, @yeri) RETURNING kategoriID",
                client);
            kategoriEkle.Parameters.AddWithValue("kategoriAdi", kategoriAdi);
            kategoriEkle.Parameters.AddWithValue("yeri", yeri);
            int kategoriID = (int)await kategoriEkle.ExecuteScalarAsync();


            var fiyatEkle = new NpgsqlCommand(
                "INSERT INTO FiyatTable " +
                "(fiyat, alisFiyati, guncellemeTarihi) " +
                "VALUES " +
                "(@fiyat, @alisFiyati, @guncellemeTarihi) RETURNING fiyatID",
                client);
            fiyatEkle.Parameters.AddWithValue("fiyat", fiyat);
            fiyatEkle.Parameters.AddWithValue("alisFiyati", alisFiyati);
            fiyatEkle.Parameters.AddWithValue("guncellemeTarihi", guncellemeTarihi);
            int fiyatID = (int)await fiyatEkle.ExecuteScalarAsync();


            var stokEkle = new NpgsqlCommand(
                "INSERT INTO StokTable " +
                "(toplamStokMiktari, kalanStokMiktari, islemTarihi) " +
                "VALUES " +
                "(@toplamStokMiktari, @kalanStokMiktari, @islemTarihi) RETURNING stokID",
                client);
            stokEkle.Parameters.AddWithValue("toplamStokMiktari", toplamStokMiktari);
            stokEkle.Parameters.AddWithValue("kalanStokMiktari", kalanStokMiktari);
            stokEkle.Parameters.AddWithValue("islemTarihi", islemTarihi);
            int stokID = (int)await stokEkle.ExecuteScalarAsync();

            var urunEkle = new NpgsqlCommand(
                "INSERT INTO UrunTable " +
                "(urunAdi, barkodNo, resim, alisTarihi, sonTuketimTarihi , kategoriID , tedarikciID , fiyatID , stokID) " +
                "VALUES " +
                "(@urunAdi, @barkodNo, @resim, @alisTarihi, @sonTuketimTarihi, @kategoriID, @tedarikciID, @fiyatID, @stokID )",
                client);
            urunEkle.Parameters.AddWithValue("urunAdi", urunAdi);
            urunEkle.Parameters.AddWithValue("barkodNo", barkodNo);
            urunEkle.Parameters.AddWithValue("resim", resim);
            urunEkle.Parameters.AddWithValue("alisTarihi", alisTarihi);
            urunEkle.Parameters.AddWithValue("sonTuketimTarihi", sonTuketimTarihi);
            urunEkle.Parameters.AddWithValue("kategoriID", kategoriID);
            urunEkle.Parameters.AddWithValue("tedarikciID", tedarikciID);
            urunEkle.Parameters.AddWithValue("fiyatID", fiyatID);
            urunEkle.Parameters.AddWithValue("stokID", stokID);


            int eklenenSatirSayisi = await urunEkle.ExecuteNonQueryAsync();
            if (eklenenSatirSayisi > 0)
            {
                Console.WriteLine("Ürün başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Ürün eklenirken bir hata oluştu.");
            }
        }
        static async Task UrunSil(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Ürün Silme --");
            Console.Write("Silinecek ürünün ID'sini giriniz: ");
            int urunId = int.Parse(Console.ReadLine());

            var urunSil = new NpgsqlCommand("DELETE FROM UrunTable WHERE urunID = @urunID", client);
            urunSil.Parameters.AddWithValue("urunID", urunId);
            int silinenSatirSayisi = await urunSil.ExecuteNonQueryAsync();
            if (silinenSatirSayisi > 0)
            {
                Console.WriteLine("Ürün başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Bu ID'ye sahip bir ürün bulunamadı.");
            }
        }
        static async Task PersonelGoruntule(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Personel Listesi --");
            var personelGetir = new NpgsqlCommand("SELECT personelID, personelAdi, personelNo, unvani, calismaDurumu, iletisim, iseBaslamaTarihi, calismaGunleri, mesaisi FROM PersonelTable ORDER BY personelID", client);
            await using var reader = await personelGetir.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int personelID = reader.GetInt32(0);
                string personelAdi = reader.GetString(1);
                int personelNo = reader.GetInt32(2);
                string unvani = reader.GetString(3);
                string calismaDurumu = reader.GetString(4);
                string iletisim = reader.GetString(5);
                string iseBaslamaTarihi = reader.GetString(6);
                string calismaGunleri = reader.GetString(7);
                string mesaisi = reader.GetString(8);

                Console.WriteLine($"ID: {reader.GetInt32(0)} | Personel Adı: {reader.GetString(1)} | Personel No: {reader.GetInt32(2)}");
            }
        }
        static async Task PersonelEkle(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Yeni Personel Ekleme --");

            var personelEkle = new NpgsqlCommand(
                "INSERT INTO PersonelTable " +
                "(personelAdi, personelNo, unvani, calismaDurumu, iletisim, iseBaslamaTarihi, calismaGunleri, mesaisi, maasi) " +
                "VALUES " +
                "(@personelAdi, @personelNo, @unvani, @calismaDurumu, @iletisim, @iseBaslamaTarihi, @calismaGunleri, @mesaisi, @maasi)",
                client);
            Console.Write("Personel Adı: ");
            string personelAdi = Console.ReadLine() ?? "";
            Console.Write("Personel No: ");
            int personelNo = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Unvanı: ");
            string unvani = Console.ReadLine() ?? "";
            Console.Write("Çalışma Durumu: ");
            string calismaDurumu = Console.ReadLine() ?? "";
            Console.Write("İletişim: ");
            string iletisim = Console.ReadLine() ?? "";
            Console.Write("İşe Başlama Tarihi (YYYY-MM-DD): ");
            string iseBaslamaTarihi = Console.ReadLine() ?? "";
            Console.Write("Çalışma Günleri: ");
            string calismaGunleri = Console.ReadLine() ?? "";
            Console.Write("Mesaisi: ");
            string mesaisi = Console.ReadLine() ?? "";
            Console.Write("Maaşı: ");
            int maasi = int.Parse(Console.ReadLine() ?? "0");
            personelEkle.Parameters.AddWithValue("personelAdi", personelAdi);
            personelEkle.Parameters.AddWithValue("personelNo", personelNo);
            personelEkle.Parameters.AddWithValue("unvani", unvani);
            personelEkle.Parameters.AddWithValue("calismaDurumu", calismaDurumu);
            personelEkle.Parameters.AddWithValue("iletisim", iletisim);
            personelEkle.Parameters.AddWithValue("iseBaslamaTarihi", iseBaslamaTarihi);
            personelEkle.Parameters.AddWithValue("calismaGunleri", calismaGunleri);
            personelEkle.Parameters.AddWithValue("mesaisi", mesaisi);
            personelEkle.Parameters.AddWithValue("maasi", maasi);
            int eklenenSatirSayisi = await personelEkle.ExecuteNonQueryAsync();
            if (eklenenSatirSayisi > 0)
            {
                Console.WriteLine("Personel başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Personel eklenirken bir hata oluştu.");
            }
        }
        static async Task PersonelSil(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Personel Silme --");

            Console.Write("Silinecek personelin ID'sini giriniz: ");
            int personelId = int.Parse(Console.ReadLine());

            var personelSil = new NpgsqlCommand("DELETE FROM PersonelTable WHERE personelID = @personelID", client);
            personelSil.Parameters.AddWithValue("personelID", personelId);

            int silinenSatirSayisi = await personelSil.ExecuteNonQueryAsync();

            if (silinenSatirSayisi > 0)
            {
                Console.WriteLine("Personel başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Bu ID'ye sahip bir personel bulunamadı.");
            }
        }
        static async Task SatislariGoruntule(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Satış Listesi --");
            var satisGetir = new NpgsqlCommand("SELECT satisID, urunlerinAdiFiyati, araToplam , vergiTutarlari , toplamTutar , odemeTipi , islemTarihi FROM SatisTable ORDER BY satisID", client);
            await using var reader = await satisGetir.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int salesID = reader.GetInt32(0);
                string productNamePrice = reader.GetString(1);
                int subTotal = reader.GetInt32(2);
                int taxAmount = reader.GetInt32(3);

                Console.WriteLine($"ID: {reader.GetInt32(0)} | Ürünler ve Fiyatları: {reader.GetString(1)} | Ara Toplam: {reader.GetInt32(2)}");
            }
        }
        static async Task SatisEkle(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Yeni Satış Ekleme --");
            var satisEkle = new NpgsqlCommand(
                "INSERT INTO SatisTable " +
                "(urunlerinAdiFiyati, araToplam, vergiTutari, odemeTipi, islemTarihi, müsteriID, personelID) " +
                "VALUES " +
                "(@urunlerinAdiFiyati, @araToplam, @vergiTutari, @odemeTipi, @islemTarihi, @müsteriID, @personelID)",
                client);
            Console.Write("Ürünlerin Adı ve Fiyatları (örn: Ürün1:100, Ürün2:200): ");
            string urunlerinAdiFiyati = Console.ReadLine() ?? "";
            Console.Write("Ara Toplam: ");
            int araToplam = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Vergi Tutarı: ");
            int vergiTutari = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ödeme Tipi: ");
            string odemeTipi = Console.ReadLine() ?? "";
            Console.Write("İşlem Tarihi (YYYY-MM-DD): ");
            string islemTarihi = Console.ReadLine() ?? "";
            Console.Write("Müşteri ID: ");
            int müsteriID = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Personel ID: ");
            int personelID = int.Parse(Console.ReadLine() ?? "0");
            satisEkle.Parameters.AddWithValue("urunlerinAdiFiyati", urunlerinAdiFiyati);
            satisEkle.Parameters.AddWithValue("araToplam", araToplam);
            satisEkle.Parameters.AddWithValue("vergiTutari", vergiTutari);
            satisEkle.Parameters.AddWithValue("odemeTipi", odemeTipi);
            satisEkle.Parameters.AddWithValue("islemTarihi", islemTarihi);
            satisEkle.Parameters.AddWithValue("müsteriID", müsteriID);
            satisEkle.Parameters.AddWithValue("personelID", personelID);
            int eklenenSatirSayisi = await satisEkle.ExecuteNonQueryAsync();
            if (eklenenSatirSayisi > 0)
            {
                Console.WriteLine("Satış başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Satış eklenirken bir hata oluştu.");
            }

        }
        static async Task TedarikciGoruntule(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Tedarikçi Listesi --");
            var tedarikciGetir = new NpgsqlCommand("SELECT tedarikciID, firmaAdi, yetkili , iletisim , adres FROM TedarikciTable ORDER BY tedarikciID", client);
            await using var reader = await tedarikciGetir.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int firmID = reader.GetInt32(0);
                string firmName = reader.GetString(1);
                string offical = reader.GetString(2);
                string contact = reader.GetString(3);
                string address = reader.GetString(4);

                Console.WriteLine($"ID: {reader.GetInt32(0)} | Firma Adı: {reader.GetString(1)} | Yetkili: {reader.GetString(2)}");
            }
        }
        static async Task StokGoruntule(NpgsqlConnection client)
        {
            Console.WriteLine("\n-- Stok Durum Raporu --");

            string sqlQuery = @"
            SELECT 
                u.urunAdi, 
                s.kalanStokMiktari, 
                s.toplamStokMiktari,
                s.islemTarihi
            FROM 
                UrunTable AS u
            INNER JOIN 
                StokTable AS s ON u.stokID = s.stokID
            ORDER BY
                u.urunAdi";

            var stokGetir = new NpgsqlCommand(sqlQuery, client);

            await using var reader = await stokGetir.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                Console.WriteLine("Stokta görüntülenecek ürün bulunamadı.");
                return;
            }
            while (await reader.ReadAsync())
            {
                string productName = reader.GetString(0);
                int remainingStock = reader.GetInt32(1);
                int totalStock = reader.GetInt32(2);
                int transactionDate = reader.GetInt32(3);

                Console.WriteLine(
                    $"Ürün Adı: {reader.GetString(0)} | Kalan Stok: {reader.GetInt32(1)} (Toplam: {reader.GetInt32(2)})"
                );
            }
        }


        static async Task VeritabaniKurulumu(NpgsqlConnection client)
        {
            var createTedarikciTable = @"
            CREATE TABLE IF NOT EXISTS TedarikciTable(
                tedarikciID SERIAL PRIMARY KEY, 
                firmaAdi VARCHAR(50) NOT NULL,
                yetkili VARCHAR(255) NOT NULL,
                iletisim VARCHAR(50) NOT NULL,
                adres VARCHAR(255) NOT NULL
            )";
            await new NpgsqlCommand(createTedarikciTable, client).ExecuteNonQueryAsync();
            var createStokTable = @"
            CREATE TABLE IF NOT EXISTS StokTable(
                stokID SERIAL PRIMARY KEY, 
                toplamStokMiktari INTEGER NOT NULL, 
                kalanStokMiktari INTEGER NOT NULL, 
                islemTarihi VARCHAR(50) NOT NULL
            )";
            await new NpgsqlCommand(createStokTable, client).ExecuteNonQueryAsync();
            var createKategoriTable = @"
            CREATE TABLE IF NOT EXISTS KategoriTable(
                kategoriID SERIAL PRIMARY KEY, 
                kategoriAdi VARCHAR(50) NOT NULL,
                yeri VARCHAR(50) NOT NULL
            )";
            await new NpgsqlCommand(createKategoriTable, client).ExecuteNonQueryAsync();
            var createFiyatTable = @"
            CREATE TABLE IF NOT EXISTS FiyatTable(
                fiyatID SERIAL PRIMARY KEY, 
                fiyat INTEGER NOT NULL, 
                alisFiyati INTEGER NOT NULL,
                guncellemeTarihi VARCHAR(50) NOT NULL
            )";
            await new NpgsqlCommand(createFiyatTable, client).ExecuteNonQueryAsync();
            var createMusteriTable = @"
            CREATE TABLE IF NOT EXISTS MusteriTable(
                musteriID SERIAL PRIMARY KEY, 
                musteriAdi VARCHAR(50) NOT NULL, 
                musteriNo INTEGER NOT NULL,
                iletisim VARCHAR(50) NOT NULL,
                kayitTarihi VARCHAR(50) NOT NULL
            )";
            await new NpgsqlCommand(createMusteriTable, client).ExecuteNonQueryAsync();
            var createPersonelTable = @"
            CREATE TABLE IF NOT EXISTS PersonelTable(
                personelID SERIAL PRIMARY KEY, 
                personelAdi VARCHAR(50) NOT NULL, 
                personelNo INTEGER NOT NULL,
                unvani VARCHAR(50) NOT NULL,
                calismaDurumu VARCHAR(50) NOT NULL,
                iletisim VARCHAR(50) NOT NULL,
                iseBaslamaTarihi VARCHAR(50) NOT NULL,
                calismaGunleri VARCHAR(50) NOT NULL,
                mesaisi VARCHAR(50) NOT NULL,
                maasi INTEGER NOT NULL
            )";
            await new NpgsqlCommand(createPersonelTable, client).ExecuteNonQueryAsync();
            var createSatisTable = @"
            CREATE TABLE IF NOT EXISTS SatisTable(
                satisID SERIAL PRIMARY KEY, 
                urunlerinAdiFiyati VARCHAR(255) NOT NULL, 
                araToplam INTEGER NOT NULL,
                vergiTutari INTEGER NOT NULL,
                odemeTipi VARCHAR(50) NOT NULL,
                islemTarihi VARCHAR(50) NOT NULL,
                musteriID INTEGER NOT NULL,
                personelID INTEGER NOT NULL,
                FOREIGN KEY (musteriID) REFERENCES MusteriTable(musteriID) ON DELETE CASCADE,
                FOREIGN KEY (personelID) REFERENCES PersonelTable(personelID) ON DELETE CASCADE
            )";
            await new NpgsqlCommand(createSatisTable, client).ExecuteNonQueryAsync();
            var createUrunTable = @"
            CREATE TABLE IF NOT EXISTS UrunTable(
                urunID SERIAL PRIMARY KEY, 
                urunAdi VARCHAR(50) NOT NULL, 
                barkodNo VARCHAR(50) NOT NULL,
                resim VARCHAR(255) NOT NULL,
                alisTarihi VARCHAR(50) NOT NULL,
                sonTuketimTarihi VARCHAR(50) NOT NULL,
                kategoriID INTEGER NOT NULL,
                tedarikciID INTEGER NOT NULL,
                fiyatID INTEGER NOT NULL,
                stokID INTEGER NOT NULL,
                satisID INTEGER,
                FOREIGN KEY (kategoriID) REFERENCES KategoriTable(kategoriID) ON DELETE CASCADE,
                FOREIGN KEY (tedarikciID) REFERENCES TedarikciTable(tedarikciID) ON DELETE CASCADE,
                FOREIGN KEY (fiyatID) REFERENCES FiyatTable(fiyatID) ON DELETE CASCADE,
                FOREIGN KEY (stokID) REFERENCES StokTable(stokID) ON DELETE CASCADE,
                FOREIGN KEY (satisID) REFERENCES SatisTable(satisID) ON DELETE CASCADE
            )";
            await new NpgsqlCommand(createUrunTable, client).ExecuteNonQueryAsync();

        }


    }

}
