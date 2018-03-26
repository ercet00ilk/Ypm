using System;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.Birim.Genel.Birim.Urun.Kategori.AracTip;

namespace YPM.Birim.Genel.Birim.Generic
{
    public interface IGorevli
         : IDisposable
    {
        IKisiBirim Kisi { get; }
        IKurulumBirim Kurulum { get; }
        ILokasyonBirim Lokasyon { get; }

        IUrunKategoriAracTipBirim UrunKategoriAracTip { get; }

        int Tamamla();
    }
}