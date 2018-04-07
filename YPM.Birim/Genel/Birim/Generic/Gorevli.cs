using Microsoft.EntityFrameworkCore.Storage;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.Birim.Genel.Birim.Urun.Kategori.Birim;
using YPM.Birim.Genel.Birim.Urun.Kategori.Ozellik;
using YPM.Birim.Genel.Birim.Urun.Nitelik;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Generic
{
    public class Gorevli
            : IGorevli
    {
        private readonly YpmSebil _sebil;

        public Gorevli(YpmSebil sebil)
        {
            _sebil = sebil;
            Kisi = new KisiBirim(_sebil);
            Kurulum = new KurulumBirim(_sebil);
            Lokasyon = new LokasyonBirim(_sebil);
            UrunKategori = new UrunKategoriBirim(_sebil);
            UrunOzellik = new UrunOzellikBirim(_sebil);
            UrunKategoriOzellik = new UrunKategoriOzellikBirim(_sebil);
        }

        public static IGorevli YeniGorev()
        {
            return new Gorevli(new YpmSebil());
        }

        public IKisiBirim Kisi { get; private set; }
        public IKurulumBirim Kurulum { get; private set; }
        public ILokasyonBirim Lokasyon { get; private set; }
        public IUrunKategoriBirim UrunKategori { get; set; }
        public IUrunOzellikBirim UrunOzellik { get; set; }
        public IUrunKategoriOzellikBirim UrunKategoriOzellik { get; set; }

        public void Dispose()
        {
            _sebil.Dispose();
        }

        public int Tamamla()
        {
            return _sebil.SaveChanges();
        }

        public IDbContextTransaction TransactionBaslat()
        {
            return _sebil.Database.BeginTransaction();
        }
    }
}