using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Kisi
{
    public class KisiBirim
           : GenericBirim<KisiGercek>, IKisiBirim
    {
        public KisiBirim(YpmSebil sebil)
            : base(sebil)
        {

        }

        public static IKisiBirim YeniGorev()
        {
            return new KisiBirim(new YpmSebil());
        }

      
    }
}
