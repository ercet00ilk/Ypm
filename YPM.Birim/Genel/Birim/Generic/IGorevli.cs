using Microsoft.EntityFrameworkCore.Storage;
using System;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Kurulum;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.Birim.Genel.Birim.Urun.Kategori.Birim;
using YPM.Birim.Genel.Birim.Urun.Kategori.Ozellik;
using YPM.Birim.Genel.Birim.Urun.Nitelik;

namespace YPM.Birim.Genel.Birim.Generic
{
    public interface IGorevli
         : IDisposable
    {
        IDbContextTransaction TransactionBaslat();

        IKisiBirim Kisi { get; }
        IKurulumBirim Kurulum { get; }
        ILokasyonBirim Lokasyon { get; }

        IUrunKategoriBirim UrunKategori { get; }
        IUrunOzellikBirim UrunOzellik { get; }
        IUrunKategoriOzellikBirim UrunKategoriOzellik { get; }

        int Tamamla();


    }
}