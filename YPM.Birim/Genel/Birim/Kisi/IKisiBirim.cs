using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using YPM.Birim.Genel.Birim.Generic;

namespace YPM.Birim.Genel.Birim.Kisi
{
    public interface IKisiBirim
           : IGenericBirim<KisiGercek>
    {
        new KisiGercek Getir(int kisiId);
    }
}
