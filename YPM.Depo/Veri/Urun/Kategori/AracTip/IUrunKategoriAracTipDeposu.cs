using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori.AracTip
{
    public interface IUrunKategoriAracTipDeposu
        : IDisposable
    {
        Task Ekle(string aracTipAd);
        Task<List<UrunKategoriAracTipModel>> Listele();
        Task Sil(int id);
    }
}
