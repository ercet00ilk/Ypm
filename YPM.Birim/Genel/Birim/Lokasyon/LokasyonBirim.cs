using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Lokasyon
{
    public class LokasyonBirim
             : GenericBirim<LokasyonGercek>, ILokasyonBirim
    {
        private readonly YpmSebil _sebil;

        public LokasyonBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }

        public static ILokasyonBirim YeniLokasyon()
        {
            return new LokasyonBirim(new YpmSebil());
        }
    }
}