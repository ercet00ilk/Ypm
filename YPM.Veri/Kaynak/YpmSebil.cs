using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using Microsoft.EntityFrameworkCore;
using YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;

namespace YPM.Veri.Kaynak
{
    public class YpmSebil
       : DbContext
    {
        public YpmSebil(DbContextOptions<YpmSebil> options)
            : base(options)
        {
        }

        public YpmSebil()
        {
        }

        public DbSet<KisiGercek> KisiTbl { get; set; }
        public DbSet<LokasyonGercek> LokasyonTbl { get; set; }

        public DbSet<KurulumGercek> KurulumTbl { get; set; }

        public DbSet<UrunKategoriGercek> UrunKategoriTbl { get; set; }
        public DbSet<UrunOzellikGercek> UrunOzellikTbl { get; set; }
        public DbSet<UrunKategoriOzellikGercek> UrunKategoriOzellikTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(VtBilgi.Islem.BaglantiCumlesiVer());

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Mulk");

            /*******
             * Kisi Mulk
             *
             */

            //  ==> PrimaryKey,Proroperty
            modelBuilder.Entity<KisiGercek>().ToTable("Kisi", "MulkKisi");
            modelBuilder.Entity<KisiGercek>().Property(c => c.KisiId).ValueGeneratedOnAdd();
            modelBuilder.Entity<KisiGercek>()
                .HasKey(c => c.KisiId);
            modelBuilder.Entity<KisiGercek>().Property(x => x.Ad).HasMaxLength(400);
            modelBuilder.Entity<KisiGercek>().Property(x => x.EPosta).HasMaxLength(150);
            modelBuilder.Entity<KisiGercek>().Property(x => x.Soyad).HasMaxLength(400);
            modelBuilder.Entity<KisiGercek>().Property(x => x.Sifre).HasMaxLength(400);
            modelBuilder.Entity<KisiGercek>().Property(x => x.EpostaKontrol).HasMaxLength(20);

            modelBuilder.Entity<LokasyonGercek>().ToTable("Lokasyon", "MulkKisi");
            modelBuilder.Entity<LokasyonGercek>().Property(c => c.LokasyonId).ValueGeneratedOnAdd();
            modelBuilder.Entity<LokasyonGercek>()
                .HasKey(c => c.LokasyonId);
            modelBuilder.Entity<LokasyonGercek>().Property(x => x.MacAdr).HasMaxLength(200);
            modelBuilder.Entity<LokasyonGercek>().Property(x => x.IpAdr).HasMaxLength(200);

            //  ==> ForeignKey

            modelBuilder.Entity<LokasyonGercek>()
              .HasOne(c => c.Kisi)
              .WithMany(d => d.Lokasyonlar)
              .HasForeignKey(c => c.KisiId)
              .OnDelete(DeleteBehavior.Cascade);

            /*******
            * Kurulum Mulk
            *
            */

            //  ==> PrimaryKey,Proroperty
            modelBuilder.Entity<KurulumGercek>().ToTable("Kurulum", "MulkKurulum");
            modelBuilder.Entity<KurulumGercek>().Property(c => c.KurulumId).ValueGeneratedOnAdd();
            modelBuilder.Entity<KurulumGercek>()
                .HasKey(c => c.KurulumId);
            modelBuilder.Entity<KurulumGercek>().Property(c => c.Ad).HasMaxLength(200);
            modelBuilder.Entity<KurulumGercek>().Property(c => c.Tip).HasMaxLength(200);

            //  ==> ForeignKey

            /*******
            * Urun Mulk
            *
            */

            //  ==> PrimaryKey,Proroperty
            modelBuilder.Entity<UrunKategoriGercek>().ToTable("UrunKategori", "MulkUrun");
            modelBuilder.Entity<UrunKategoriGercek>().Property(c => c.UrunKategoriId).ValueGeneratedOnAdd();
            modelBuilder.Entity<UrunKategoriGercek>()
                .HasKey(c => c.UrunKategoriId);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.Ad).HasMaxLength(250);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.Aciklama).HasMaxLength(400);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.AnahtarKelime).HasMaxLength(400);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.SayfaBaslik).HasMaxLength(250);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.Tanim).HasMaxLength(400);

            modelBuilder.Entity<UrunOzellikGercek>().ToTable("UrunOzellik", "MulkUrun");
            modelBuilder.Entity<UrunOzellikGercek>().Property(x => x.UrunOzellikId).ValueGeneratedOnAdd();
            modelBuilder.Entity<UrunOzellikGercek>()
                .HasKey(c => c.UrunOzellikId);
            modelBuilder.Entity<UrunOzellikGercek>().Property(x => x.Ad).HasMaxLength(250);

            modelBuilder.Entity<UrunKategoriOzellikGercek>().ToTable("UrunKategoriOzellik", "MulkUrun");
            modelBuilder.Entity<UrunKategoriOzellikGercek>().Property(c => c.UrunKategoriOzellikId).ValueGeneratedOnAdd();
            modelBuilder.Entity<UrunKategoriOzellikGercek>()
                .HasKey(c => new
                {
                    c.UrunKategoriOzellikId,
                    c.UrunKategoriId,
                    c.UrunOzellikId
                });

            //  ==> ForeignKey

            modelBuilder
                .Entity<UrunKategoriOzellikGercek>()
                .HasOne(c => c.Kategori)
                .WithMany(d => d.KategoriOzellik)
                .HasForeignKey(c => c.UrunKategoriId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<UrunKategoriOzellikGercek>()
                .HasOne(c => c.Ozellik)
                .WithMany(d => d.KategoriOzellik)
                .HasForeignKey(c => c.UrunOzellikId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}