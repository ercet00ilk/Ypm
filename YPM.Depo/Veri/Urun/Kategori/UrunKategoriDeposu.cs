using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori
{
    public class UrunKategoriDeposu
          : IUrunKategoriDeposu
    {
        private static ICollection<UrunKategoriListeleModel> listeler;

        public UrunKategoriDeposu()
        {
            listeler = new List<UrunKategoriListeleModel>();

            using (IGorevli gorev = Gorevli.YeniGorev())
            {
                var donenDeger = gorev.UrunKategori.GetirTumKoleksiyon();
                foreach (var item in donenDeger)
                {
                    listeler.Add(new UrunKategoriListeleModel()
                    {
                        Ad = item.Ad,
                        KategoriId = item.UrunKategoriId,
                        UstKategoriId = item.UrunUstKategoriId
                    });
                }

            }

            if (listeler.Count <= 0)
                listeler.Add(new UrunKategoriListeleModel() { Ad = "bos", KategoriId = 0, UstKategoriId = 0 });
        }

        public ICollection<UrunKategoriListeleModel> Listele()
        {
            return listeler;
        }




        //public async Task Ekle(string aracTipAd)
        //{
        //    using (IGorevli gorev = Gorevli.YeniGorev())
        //    using (UrunAracTip arac = new UrunAracTip() { UrunAracTipAd = aracTipAd })
        //    {
        //        await gorev.UrunKategoriAracTip.EkleAsync(arac);
        //    }
        //}

        //public async Task<List<UrunKategoriAracTipModel>> Listele()
        //{

        //    List<UrunKategoriAracTipModel> list = new List<UrunKategoriAracTipModel>();

        //    {
        //        using (IGorevli gorev = Gorevli.YeniGorev())
        //        {
        //            var sonuc = await gorev.UrunKategoriAracTip.GetirTumKoleksiyonAsyn();

        //            //if (sonuc == null) list.Add(new UrunKategoriAracTipModel() { AracTipAd = "bos", Id = 0 });

        //            //if (sonuc.Count <= 0) list.Add(new UrunKategoriAracTipModel() { AracTipAd = "bos", Id = 0 });

        //            //if (sonuc.Count > 0) list = sonuc.Cast<UrunKategoriAracTipModel>().ToList();

        //            foreach (var item in sonuc)
        //            {
        //                list.Add(new UrunKategoriAracTipModel() { AracTipAd = item.UrunAracTipAd, Id = item.UrunAracTipId });
        //            }

        //        }
        //    }

        //    return list;
        //}

        //public async Task Sil(int id)
        //{
        //    using (IGorevli gorev = Gorevli.YeniGorev())
        //    {
        //        await gorev.UrunKategoriAracTip.SilAsync(id);
        //    }
        //}
    }
}
