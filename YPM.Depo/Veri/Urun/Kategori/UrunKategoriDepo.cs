

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;
using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Depo;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori
{
    public class UrunKategoriDepo
           : IUrunKategoriDepo
    {
        private static ICollection<UrunKategoriSuret> _tumUrunKategoriListesi;
        private static ICollection<UrunNitelikSuret> _tumUrunNitelikListesi;

        public UrunKategoriDepo()
        {
            if (_tumUrunKategoriListesi == null)
            {
                _tumUrunKategoriListesi = new List<UrunKategoriSuret>();

                using (IGorevli gorev = Gorevli.YeniGorev())
                {
                    if (!(gorev.UrunKategori.GetirTumKoleksiyon().Count() > 0))
                    {
                        gorev.UrunKategori.Ekle(new UrunKategoriGercek()
                        {
                            Ad = "Örnek Kategori",
                            AktifMi = false,
                            Aciklama = "Örnek Meta Açıklama",
                            AnahtarKelime = "örnek,meta,anahtar,kelimeler",
                            SayfaBaslik = "Örnek Kategori",
                            Tanim = "Örnek Kategori Sayfası",
                            UrunUstKategoriId = 0

                        });
                    }

                    if (gorev.UrunKategori.GetirTumKoleksiyon().Count() > 0)
                    {
                        foreach (var item in gorev.UrunKategori.GetirTumKoleksiyon())
                        {
                            _tumUrunKategoriListesi.Add(new UrunKategoriSuret()
                            {
                                UrunKategoriId = item.UrunKategoriId,
                                UrunUstKategoriId = item.UrunUstKategoriId,
                                Ad = item.Ad,
                                Aciklama = item.Aciklama,
                                AktifMi = item.AktifMi,
                                AnahtarKelime = item.AnahtarKelime,
                                SayfaBaslik = item.SayfaBaslik,
                                Tanim = item.Tanim
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
                            istisna.TabanHata = "_tumUrunNitelikListesi Boş Geldi.";
                            istisna.Sonuc = "  public UrunKategoriDeposu() ";
                            istisna.IslemOnay = false;
                            istisna.Tarih = Tarih.GuncelTarihVer();
                            istisna.Yazdir(istisna);
                        }
                    }
                }
            }

            if (_tumUrunNitelikListesi == null)
            {
                _tumUrunNitelikListesi = new List<UrunNitelikSuret>();

                using (IGorevli gorev = Gorevli.YeniGorev())
                {

                    if (!(gorev.UrunNitelik.GetirTumKoleksiyon().Count() > 0))
                    {
                        gorev.UrunNitelik.Ekle(new UrunNitelikGercek()
                        {
                            Ad = "Örnek Nitelik"
                        });
                    }

                    if (gorev.UrunNitelik.GetirTumKoleksiyon().Count() > 0)
                    {
                        foreach (var item in gorev.UrunNitelik.GetirTumKoleksiyon())
                        {
                            _tumUrunNitelikListesi.Add(new UrunNitelikSuret()
                            {
                                Ad = item.Ad,
                                UrunNitelikId = item.UrunNitelikId
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
                            istisna.TabanHata = "_tumUrunNitelikListesi Boş Geldi.";
                            istisna.Sonuc = "  public UrunKategoriDeposu() ";
                            istisna.IslemOnay = false;
                            istisna.Tarih = Tarih.GuncelTarihVer();
                            istisna.Yazdir(istisna);
                        }
                    }
                }
            }
        }

        public bool KontrolEt(string ad)
        {
            bool donenSonuc = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            {
                var sonuc = gorev.UrunKategori.GetirTumKoleksiyon().Where(c => c.Ad == ad).FirstOrDefault();
                if (sonuc != null) donenSonuc = true;
                else donenSonuc = false;
            }

            return donenSonuc;
        }

        public ICollection<UrunKategoriSuret> TumUrunKategoriListesi()
        {
            return _tumUrunKategoriListesi;
        }

        public ICollection<UrunNitelikSuret> TumUrunNitelikListesi()
        {
            return _tumUrunNitelikListesi;
        }

        public bool UrunKategoriEkle(UrunKategoriSuret uks)
        {
            bool islemOnay = new bool();

            using (var transaction = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (IGorevli gorev = Gorevli.YeniGorev())
                    {
                        

                        // if (await kur.KuruluMu()) kur.KurulumYap().Wait();

                        islemOnay = true;
                    }
                }
                catch (Exception ex)
                {
                    islemOnay = false;

                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public bool UrunKategoriEkle(UrunKategoriSuret uks) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }
                }
                finally
                {
                    if (islemOnay) transaction.Complete();
                    else transaction.Dispose();
                }
            }

            return islemOnay;
        }
    }
}
