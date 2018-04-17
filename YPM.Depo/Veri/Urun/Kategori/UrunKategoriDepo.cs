using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public bool KontrolEt(string ad)
        {
            bool islemOnay = new bool();

            bool donenSonuc = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var sonuc = gorev.UrunKategori.GetirTumKoleksiyon().Where(c => c.Ad == ad).FirstOrDefault();
                    if (sonuc != null) donenSonuc = true;
                    else donenSonuc = false;

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public bool KontrolEt(string ad) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return donenSonuc;
        }

        public ICollection<UrunKategoriSuret> TumUrunKategoriDinamikListesi()
        {
            bool islemOnay = new bool();

            List<UrunKategoriSuret> _tumUrunKategoriListesi = new List<UrunKategoriSuret>();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
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
                            BabaId = 0
                        });
                    }

                    if (gorev.UrunKategori.GetirTumKoleksiyon().Count() > 0)
                    {
                        foreach (var item in gorev.UrunKategori.GetirTumKoleksiyon())
                        {
                            _tumUrunKategoriListesi.Add(new UrunKategoriSuret()
                            {
                                KategoriId = item.UrunKategoriId,
                                BabaId = item.BabaId,
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
                            istisna.TabanHata = "_tumUrunKategoriListesi Boş Geldi.";
                            istisna.Sonuc = "  public ICollection<UrunKategoriSuret> TumUrunKategoriDinamikListesi() ";
                            istisna.IslemOnay = false;
                            istisna.Tarih = Tarih.GuncelTarihVer();
                            istisna.Yazdir(istisna);
                        }
                    }

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public ICollection<UrunKategoriSuret> TumUrunKategoriDinamikListesi() ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return _tumUrunKategoriListesi;
        }

        public ICollection<UrunOzellikSuret> TumUrunOzellikDinamikListesi()
        {
            bool islemOnay = new bool();

            List<UrunOzellikSuret> _tumUrunOzellikListesi = new List<UrunOzellikSuret>();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    if (!(gorev.UrunOzellik.GetirTumKoleksiyon().Count() > 0))
                    {
                        gorev.UrunOzellik.Ekle(new UrunOzellikGercek()
                        {
                            Ad = "Örnek Özellik"
                        });
                    }

                    if (gorev.UrunOzellik.GetirTumKoleksiyon().Count() > 0)
                    {
                        foreach (var item in gorev.UrunOzellik.GetirTumKoleksiyon())
                        {
                            _tumUrunOzellikListesi.Add(new UrunOzellikSuret()
                            {
                                Ad = item.Ad,
                                UrunOzellikId = item.UrunOzellikId
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
                            istisna.TabanHata = "_tumUrunOzellikListesi Boş Geldi.";
                            istisna.Sonuc = "  public ICollection<UrunOzellikSuret> TumUrunOzellikDinamikListesi() ";
                            istisna.IslemOnay = false;
                            istisna.Tarih = Tarih.GuncelTarihVer();
                            istisna.Yazdir(istisna);
                        }
                    }

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public ICollection<UrunOzellikSuret> TumUrunOzellikDinamikListesi() ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return _tumUrunOzellikListesi;
        }

        public UrunKategoriSuret UrunKategoriGetir(int katId)
        {
            bool islemOnay = new bool();

            UrunKategoriSuret ds = new UrunKategoriSuret();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var kategori = gorev.UrunKategori.Bul(x => x.UrunKategoriId.Equals(katId));
                    var ozellikGrubu = gorev.UrunKategoriOzellik.GetirTumKoleksiyon(x => x.UrunKategoriId.Equals(kategori.UrunKategoriId));

                    ds.Aciklama = kategori.Aciklama;
                    ds.Ad = kategori.Ad;
                    ds.AktifMi = kategori.AktifMi;
                    ds.AnahtarKelime = kategori.AnahtarKelime;
                    ds.KategoriId = kategori.UrunKategoriId;
                    ds.SayfaBaslik = kategori.SayfaBaslik;
                    ds.Tanim = kategori.Tanim;
                    ds.OzellikGrubu = (

                        from urKat in gorev.UrunKategori.GetirTumKoleksiyon()

                        join urKatOz in gorev.UrunKategoriOzellik.GetirTumKoleksiyon()
                            on urKat.UrunKategoriId
                            equals urKatOz.UrunKategoriId

                        join urOz in gorev.UrunOzellik.GetirTumKoleksiyon()
                            on urKatOz.UrunOzellikId
                            equals urOz.UrunOzellikId

                        where urKat.UrunKategoriId.Equals(kategori.UrunKategoriId)

                        select urOz

                                       ).ToDictionary(k => k.UrunOzellikId, v => v.Ad);

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds;
        }

        public bool UrunKategoriEkle(UrunKategoriSuret uks)
        {
            bool islemOnay = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    using (UrunKategoriGercek ukg = new UrunKategoriGercek()
                    {
                        Aciklama = uks.Aciklama,
                        Ad = uks.Ad,
                        AktifMi = uks.AktifMi,
                        AnahtarKelime = uks.AnahtarKelime,
                        BabaId = uks.BabaId,
                        SayfaBaslik = uks.SayfaBaslik,
                        Tanim = uks.Tanim
                    })
                    {
                        gorev.UrunKategori.Ekle(ukg);
                        List<int> donder = new List<int>();

                        uks.YeniEklenecekOzellikler.ForEach(x => donder.Add(x));

                        for (int i = 0; i < donder.Count; i++)
                        {
                            gorev.UrunKategoriOzellik.Ekle(new UrunKategoriOzellikGercek
                            {
                                UrunKategoriId = ukg.UrunKategoriId,
                                UrunOzellikId = donder[i]
                            });
                        }
                    }

                    islemOnay = true;
                }
                catch (Exception ex)
                {
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

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return islemOnay;
        }

        public UrunKategoriSuret UrunKategoriDuzenle(int katId)
        {
            bool islemOnay = new bool();

            UrunKategoriSuret ds = new UrunKategoriSuret();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var kategori = gorev.UrunKategori.Bul(x => x.UrunKategoriId.Equals(katId));
                    var ozellikGrubu = gorev.UrunKategoriOzellik.GetirTumKoleksiyon(x => x.UrunKategoriId.Equals(katId));

                    ds.Aciklama = kategori.Aciklama;
                    ds.Ad = kategori.Ad;
                    ds.AktifMi = kategori.AktifMi;
                    ds.AnahtarKelime = kategori.AnahtarKelime;
                    ds.KategoriId = kategori.UrunKategoriId;
                    ds.SayfaBaslik = kategori.SayfaBaslik;
                    ds.Tanim = kategori.Tanim;
                    ds.OzellikGrubu = (

                        from urKat in gorev.UrunKategori.GetirTumKoleksiyon()

                        join urKatOz in gorev.UrunKategoriOzellik.GetirTumKoleksiyon()
                            on urKat.UrunKategoriId
                            equals urKatOz.UrunKategoriId

                        join urOz in gorev.UrunOzellik.GetirTumKoleksiyon()
                            on urKatOz.UrunOzellikId
                            equals urOz.UrunOzellikId

                        where urKat.UrunKategoriId.Equals(kategori.UrunKategoriId)

                        select urOz

                                       ).ToDictionary(k => k.UrunOzellikId, v => v.Ad);

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds;
        }

        public int[] KategorininOzellikGrubuGetir(int katId)
        {
            bool islemOnay = new bool();

            List<int> ds = new List<int>();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var kategori = gorev.UrunKategori.Bul(x => x.UrunKategoriId.Equals(katId));
                    var ozellikler = gorev.UrunKategoriOzellik.GetirTumKoleksiyon().Where(x => x.UrunKategoriId.Equals(katId)).ToList();

                    for (int i = 0; i < ozellikler.Count(); i++)
                    {
                        ds.Add(ozellikler[i].UrunOzellikId);
                    }

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public int[] KategorininOzellikGrubuGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds.ToArray();
        }

        public bool UrunKategoriDuzenle(UrunKategoriSuret uks)
        {
            bool islemOnay = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var varlik = gorev.UrunKategori.Bul(x => x.UrunKategoriId.Equals(uks.KategoriId));

                    varlik.Aciklama = uks.Aciklama;
                    varlik.Ad = uks.Ad;
                    varlik.AktifMi = uks.AktifMi;
                    varlik.AnahtarKelime = uks.AnahtarKelime;
                    varlik.SayfaBaslik = uks.SayfaBaslik;
                    varlik.Tanim = uks.Tanim;

                    gorev.UrunKategori.Guncelle(varlik, uks.KategoriId);

                    List<int> eskiOzellikList = new List<int>();

                    eskiOzellikList = gorev.UrunKategoriOzellik.GetirTumKoleksiyon().Where(x => x.UrunKategoriId.Equals(uks.KategoriId)).Select(x => x.UrunOzellikId).ToList();

                    List<int> yeniOzellikList = new List<int>();

                    yeniOzellikList = uks.YeniEklenecekOzellikler;

                    for (int i = 0; i < yeniOzellikList.Count; i++)
                    {
                        int deger = yeniOzellikList[i];

                        if (eskiOzellikList.Contains(deger)) eskiOzellikList.Remove(deger);
                        else
                        {
                            gorev.UrunKategoriOzellik.Ekle(new UrunKategoriOzellikGercek
                            {
                                UrunKategoriId = uks.KategoriId,
                                UrunOzellikId = deger
                            });
                            if (eskiOzellikList.Contains(deger)) eskiOzellikList.Remove(deger);
                        }
                    }

                    for (int i = 0; i < eskiOzellikList.Count; i++)
                    {
                        int deger = eskiOzellikList[i];

                        var silinecekVarlik = gorev.UrunKategoriOzellik.GetirTumKoleksiyon()
                            .Where(x => x.UrunKategoriId.Equals(varlik.UrunKategoriId))
                            .Where(x => x.UrunOzellikId.Equals(deger)).FirstOrDefault();

                        gorev.UrunKategoriOzellik.Sil(silinecekVarlik);
                    }

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return islemOnay;
        }

        public List<UrunOzellikSuret> KategoriOzellikDetayGetir()
        {
            bool islemOnay = new bool();

            List<UrunOzellikSuret> ds = new List<UrunOzellikSuret>();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {

                    List<UrunOzellikGercek> urunOzellik = gorev.UrunOzellik.GetirTumKoleksiyon().ToList();

                    var urunKategori = gorev.UrunKategori.GetirTumKoleksiyon();

                    var urunKategoriOzellik = gorev.UrunKategoriOzellik.GetirTumKoleksiyon();


                    for (int i = 0; i < urunOzellik.Count; i++)
                    {
                        int urunOzellikId = urunOzellik[i].UrunOzellikId;
                        int urunKategoriId = urunKategoriOzellik.Where(x => x.UrunOzellikId.Equals(urunOzellikId)).Select(x => x.UrunKategoriId).FirstOrDefault();



                        ds.Add(new UrunOzellikSuret
                        {
                            UrunOzellikId = urunOzellik[i].UrunOzellikId,
                            Ad = urunOzellik[i].Ad,
                            Durum = urunOzellik[i].Durum,
                            KategoriSayisi = (

                                         from urKat in gorev.UrunKategori.GetirTumKoleksiyon()

                                         join urKatOz in gorev.UrunKategoriOzellik.GetirTumKoleksiyon()
                                             on urKat.UrunKategoriId
                                             equals urKatOz.UrunKategoriId

                                         join urOz in gorev.UrunOzellik.GetirTumKoleksiyon()
                                             on urKatOz.UrunOzellikId
                                             equals urOz.UrunOzellikId

                                         where urKatOz.UrunKategoriId.Equals(urunKategoriId)

                                         select urKatOz).Count()

                             ,
                            OzellikSayisi = (

                                         from urKat in gorev.UrunKategori.GetirTumKoleksiyon()

                                         join urKatOz in gorev.UrunKategoriOzellik.GetirTumKoleksiyon()
                                             on urKat.UrunKategoriId
                                             equals urKatOz.UrunKategoriId

                                         join urOz in gorev.UrunOzellik.GetirTumKoleksiyon()
                                             on urKatOz.UrunOzellikId
                                             equals urOz.UrunOzellikId

                                         where urKatOz.UrunOzellikId.Equals(urunOzellikId)

                                         select urKatOz).Count(),
                            SeciliMi = false

                        });
                    }

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public List<UrunOzellikSuret> KategoriOzellikDetayGetir() ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds;
        }

        public bool BoyleBirOzellikVarMi(string ad)
        {
            bool islemOnay = new bool();

            bool ds = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {

                    var ozellik = gorev.UrunOzellik.Bul(x => x.Ad == ad);

                    if (ozellik != null) ds = true;
                    else ds = false;


                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds;
        }

        public bool BoyleBirKategoriVarMi(string ad)
        {
            bool islemOnay = new bool();

            bool ds = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {

                    var kategori = gorev.UrunKategori.Bul(x => x.Ad == ad);

                    if (kategori != null) ds = true;
                    else ds = false;


                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds;
        }

        public void UrunOzellikEkle(UrunOzellikSuret urunOzellikSuret)
        {
            bool islemOnay = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {

                    gorev.UrunOzellik.Ekle(new UrunOzellikGercek { Ad = urunOzellikSuret.Ad, Durum = urunOzellikSuret.Durum });

                    gorev.Tamamla();

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return;
        }

        public void OzellikDurumDegistir(int ozellikId)
        {
            bool islemOnay = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {

                    var ozellik = gorev.UrunOzellik.Bul(x => x.UrunOzellikId.Equals(ozellikId));

                    if (ozellik.Durum) ozellik.Durum = false;
                    else ozellik.Durum = true;

                    gorev.UrunOzellik.Guncelle(ozellik, ozellik.UrunOzellikId);


                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return;
        }

        public void OzellikSil(int ozellikId)
        {
            bool islemOnay = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {
                    var ozellik = gorev.UrunOzellik.Bul(x => x.UrunOzellikId.Equals(ozellikId));

                    if (ozellik!=null) gorev.UrunOzellik.Sil(ozellik);
                   

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return;
        }

        public bool OzellikBagliMi(int ozellikId)
        {
            bool islemOnay = new bool();

            bool ds = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {

                try
                {
                    var ozellik = gorev.UrunOzellik.Bul(x => x.UrunOzellikId.Equals(ozellikId));

                    int bagKatSayi = gorev.UrunKategoriOzellik.GetirTumKoleksiyon().Where(x => x.UrunOzellikId.Equals(ozellik.UrunOzellikId)).Count();

                    if (bagKatSayi != 0) ds = true;
                    else ds = false;                    

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return ds;
        }
    }
}