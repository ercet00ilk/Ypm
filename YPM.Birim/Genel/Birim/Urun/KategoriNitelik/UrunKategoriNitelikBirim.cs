using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Urun.KategoriNitelik
{
    public class UrunKategoriNitelikBirim
        : GenericBirim<UrunKategoriNitelikGercek>, IUrunKategoriNitelikBirim
    {
        private readonly YpmSebil _sebil;

        public UrunKategoriNitelikBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }
    }
}