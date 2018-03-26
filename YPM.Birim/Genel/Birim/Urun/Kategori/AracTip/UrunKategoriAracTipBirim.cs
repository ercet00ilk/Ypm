using System;
using System.Collections.Generic;
using System.Text;
using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Urun.Kategori.AracTip
{
    public class UrunKategoriAracTipBirim
        : GenericBirim<UrunAracTip>, IUrunKategoriAracTipBirim
    {
        private readonly YpmSebil _sebil;

        public UrunKategoriAracTipBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }
    }
}
