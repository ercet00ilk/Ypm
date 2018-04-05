using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Urun.Nitelik
{
    public class UrunNitelikBirim
              : GenericBirim<UrunNitelikGercek>, IUrunNitelikBirim
    {
        private readonly YpmSebil _sebil;

        public UrunNitelikBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }
    }
}