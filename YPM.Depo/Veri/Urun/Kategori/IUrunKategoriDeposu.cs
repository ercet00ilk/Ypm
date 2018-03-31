using System.Collections.Generic;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori
{
    public interface IUrunKategoriDeposu
    {
        ICollection<UrunKategoriSuret> TumUrunKategoriListesi();
        ICollection<UrunKategoriNitelikSuret> TumUrunKategoriNitelikListesi();
    }
}
