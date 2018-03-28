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

        public DbSet<UrunKategoriGercek> KategoriTbl { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(VtBilgi.Islem.BaglantiCumlesiVer());

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Mulk");

            /*******
             * Kisi Mulk
             *
             */

            //  ==> PrimaryKey,Proroperty
            modelBuilder.Entity<KisiGercek>().ToTable("Kisi", "MulkKisi");
            modelBuilder.Entity<KisiGercek>().HasKey(c => c.KisiId);
            modelBuilder.Entity<KisiGercek>().Property(x => x.Ad).HasMaxLength(400);
            modelBuilder.Entity<KisiGercek>().Property(x => x.EPosta).HasMaxLength(150);
            modelBuilder.Entity<KisiGercek>().Property(x => x.Soyad).HasMaxLength(400);
            modelBuilder.Entity<KisiGercek>().Property(x => x.Sifre).HasMaxLength(400);
            modelBuilder.Entity<KisiGercek>().Property(x => x.EpostaKontrol).HasMaxLength(20);

            modelBuilder.Entity<LokasyonGercek>().ToTable("Lokasyon", "MulkKisi");
            modelBuilder.Entity<LokasyonGercek>().HasKey(c => c.LokasyonId);
            modelBuilder.Entity<LokasyonGercek>().Property(x => x.MacAdr).HasMaxLength(200);
            modelBuilder.Entity<LokasyonGercek>().Property(x => x.IpAdr).HasMaxLength(200);

            //  ==> ForeignKey

            /*******
            * Kurulum Mulk
            *
            */

            //  ==> PrimaryKey,Proroperty
            modelBuilder.Entity<KurulumGercek>().ToTable("Kurulum", "MulkKurulum");
            modelBuilder.Entity<KurulumGercek>().HasKey(c => c.KurulumId);
            modelBuilder.Entity<KurulumGercek>().Property(c => c.Ad).HasMaxLength(200);
            modelBuilder.Entity<KurulumGercek>().Property(c => c.Tip).HasMaxLength(200);

            //  ==> ForeignKey

            modelBuilder.Entity<LokasyonGercek>()
              .HasOne(c => c.Kisi)
              .WithMany(d => d.Lokasyonlar)
              .HasForeignKey(c => c.KisiId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            /*******
            * Urun Mulk
            *
            */

            //  ==> PrimaryKey,Proroperty
            modelBuilder.Entity<UrunKategoriGercek>().ToTable("Kategori", "MulkUrun");
            modelBuilder.Entity<UrunKategoriGercek>().HasKey(c => new { c.UrunKategoriId, c.UrunUstKategoriId });
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.Ad).HasMaxLength(250);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.LinkYol).HasMaxLength(250);
            modelBuilder.Entity<UrunKategoriGercek>().Property(x => x.ResimYol).HasMaxLength(250);

            //  ==> ForeignKey
        }
    }
}