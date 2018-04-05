using System;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.Birim.Genel.Birim.Urun.Kategori;
using YPM.Birim.Genel.Birim.Urun.KategoriNitelik;
using YPM.Birim.Genel.Birim.Urun.Nitelik;

namespace YPM.Birim.Genel.Birim.Generic
{
    public interface IGorevli
         : IDisposable
    {
        IKisiBirim Kisi { get; }
        IKurulumBirim Kurulum { get; }
        ILokasyonBirim Lokasyon { get; }

        IUrunKategoriBirim UrunKategori { get; }
        IUrunNitelikBirim UrunNitelik { get; }
        IUrunKategoriNitelikBirim UrunKategoriNitelik { get; }


        int Tamamla();
    }
}