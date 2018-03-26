using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori.AracTip
{
    public class UrunKategoriAracTipDeposu
        : IUrunKategoriAracTipDeposu
    {
        private bool Disposed { get; set; }

        ~UrunKategoriAracTipDeposu()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (Disposed) return;

            if (Disposing)
            {

            }

            Disposed = true;
        }

        public async Task Ekle(string aracTipAd)
        {
            using (IGorevli gorev = Gorevli.YeniGorev())
            using (UrunAracTip arac = new UrunAracTip() { UrunAracTipAd = aracTipAd })
            {
                await gorev.UrunKategoriAracTip.EkleAsync(arac);
            }
        }

        public async Task<List<UrunKategoriAracTipModel>> Listele()
        {


            List<UrunKategoriAracTipModel> list = new List<UrunKategoriAracTipModel>();

            {
                ICollection<UrunAracTip> koleksiyon = null;
                using (IGorevli gorev = Gorevli.YeniGorev())
                {
                    var sonuc = await gorev.UrunKategoriAracTip.GetirTumKoleksiyonAsyn();

                    if (sonuc != null) list = koleksiyon.Cast<UrunKategoriAracTipModel>().ToList();
                }
                koleksiyon = null;
            }



            //foreach (var item in sonuc)
            //{
            //    list.Add(new UrunKategoriAracTipModel() { AracTipAd = item.UrunAracTipAd, Id = item.UrunAracTipId });
            //}



            return list;
        }
    }
}
