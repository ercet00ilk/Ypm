using System;
using System.Collections.Generic;
using System.Text;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;

namespace YPM.Birim.Genel.Birim.Generic
{
    public interface IGorevli
       : IDisposable
    {
        IKisiBirim Kisi { get; }
        IKurulumBirim Kurulum { get; }
        int Tamamla();
    }
}
