using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Kurulum
{
    public class KurulumBirim
         : GenericBirim<KurulumGercek>, IKurulumBirim
    {
        public KurulumBirim(YpmSebil sebil)
            : base(sebil)
        {

        }

        public static IKurulumBirim OrnekVer()
        {
            return new KurulumBirim(new YpmSebil());
        }

        public Task AtesleProsedurOlustur()
        {
            throw new NotImplementedException();
        }
    }
}
