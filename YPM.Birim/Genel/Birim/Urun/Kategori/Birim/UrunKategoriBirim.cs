using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Urun.Kategori.Birim
{
    public class UrunKategoriBirim
            : GenericBirim<UrunKategoriGercek>, IUrunKategoriBirim
    {
        private readonly YpmSebil _sebil;

        public UrunKategoriBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }
    }
}