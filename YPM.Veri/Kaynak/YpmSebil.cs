using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<KurulumGercek> KurulumTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(VtBilgi.Islem.BaglantiCumlesiVer());

            base.OnConfiguring(optionsBuilder);
        }
    }
}