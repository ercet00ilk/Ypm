using System;
using System.Collections.Generic;
using System.Text;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;
using YPM.Birim.Genel.Birim.Lokasyon;

namespace YPM.Birim.Genel.Birim.Generic
{
    public interface IGorevli
         : IDisposable
    {
        IKisiBirim Kisi { get; }
        IKurulumBirim Kurulum { get; }
        ILokasyonBirim Lokasyon { get; }
        int Tamamla();
    }
}
