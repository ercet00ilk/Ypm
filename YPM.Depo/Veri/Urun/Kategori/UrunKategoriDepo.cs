﻿using Microsoft.EntityFrameworkCore.Storage;
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
                                UrunKategoriId = item.UrunKategoriId,
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
                            Ad = "Örnek Nitelik"
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

        public UrunKategoriDetaySuret UrunKategoriDetayGetir(int katId)
        {
            bool islemOnay = new bool();

            UrunKategoriDetaySuret ds = new UrunKategoriDetaySuret();

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

                        for (int i = 0; i < uks.YeniEklenecekNitelikler.Count; i++)
                        {
                            gorev.UrunKategoriOzellik.Ekle(new UrunKategoriOzellikGercek
                            {
                                UrunKategoriId = ukg.UrunKategoriId,
                                UrunOzellikId = uks.YeniEklenecekNitelikler[i]
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
    }
}