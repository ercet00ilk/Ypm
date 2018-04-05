using System;
using System.Collections.Generic;
using System.Text;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori
{
    public interface IUrunKategoriDepo
    {
        bool KontrolEt(string ad);
        ICollection<UrunKategoriSuret> TumUrunKategoriListesi();
        ICollection<UrunNitelikSuret> TumUrunNitelikListesi();
        bool UrunKategoriEkle(UrunKategoriSuret uks);
    }
}
