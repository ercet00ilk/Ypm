using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.Birim.Genel.Birim.Urun.Kategori;
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
        }

        public static IGorevli YeniGorev()
        {
            return new Gorevli(new YpmSebil());
        }

        public IKisiBirim Kisi { get; private set; }
        public IKurulumBirim Kurulum { get; private set; }
        public ILokasyonBirim Lokasyon { get; private set; }
        public IUrunKategoriBirim UrunKategori { get; set; }

        public void Dispose()
        {
            _sebil.Dispose();
        }

        public int Tamamla()
        {
            return _sebil.SaveChanges();
        }
    }
}