using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Birim;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Depo;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori
{
    public class UrunKategoriDeposu
          : IUrunKategoriDeposu
    {
        private static ICollection<UrunKategoriSuret> _tumUrunKategoriListesi;
        //private static ICollection<UrunKategoriNitelikSuret> _tumUrunKategoriNitelikListesi;

        public UrunKategoriDeposu()
        {
            _tumUrunKategoriListesi = new List<UrunKategoriSuret>();
            //_tumUrunKategoriNitelikListesi = new List<UrunKategoriNitelikSuret>();

            using (IGorevli gorev = Gorevli.YeniGorev())
            {
                var urunKategori = gorev.UrunKategori.GetirTumKoleksiyon();

                if (urunKategori.Count() > 0)
                {
                    foreach (var item in urunKategori)
                    {
                        _tumUrunKategoriListesi.Add(new UrunKategoriSuret()
                        {
                            Ad = item.Ad,
                            KategoriId = item.UrunKategoriId,
                            UstKategoriId = item.UrunUstKategoriId
                        });
                    }
                }
                else
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = "_tumUrunKategoriListesi Boş Geldi.";
                        istisna.Sonuc = "  public UrunKategoriDeposu() ";
                        istisna.IslemOnay = false;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }
                }

                var urunKategoriNitelik = gorev.UrunKategoriNitelik.GetirTumKoleksiyon();

                //if (urunKategoriNitelik.Count() > 0)
                //{
                //    foreach (var item in urunKategoriNitelik)
                //    {
                //        _tumUrunKategoriNitelikListesi.Add(new UrunKategoriNitelikSuret()
                //        {
                //            Ad = item.Ad,
                //            UrunKategoriNitelikId = item.UrunKategoriNitelikGercekId
                //        });
                //    }
                //}
                //else
                //{
                //    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                //    {
                //        istisna.TamYol = GetType().FullName;
                //        istisna.Method = MethodBase.GetCurrentMethod().Name;
                //        istisna.KisiId = 0;
                //        istisna.TabanHata = "_tumUrunKategoriNitelikListesi Boş Geldi.";
                //        istisna.Sonuc = "  public UrunKategoriDeposu() ";
                //        istisna.IslemOnay = false;
                //        istisna.Tarih = Tarih.GuncelTarihVer();
                //        istisna.Yazdir(istisna);
                //    }
                //}
                
            }

        }

        public ICollection<UrunKategoriSuret> TumUrunKategoriListesi()
        {
            return _tumUrunKategoriListesi;
        }

        public ICollection<UrunKategoriNitelikSuret> TumUrunKategoriNitelikListesi()
        {
            ////return _tumUrunKategoriNitelikListesi;

            return null;
        }

    }
}
