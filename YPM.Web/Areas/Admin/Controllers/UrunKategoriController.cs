using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using YPM.Depo.Veri.Gunluk;
using YPM.Depo.Veri.Sistem;
using YPM.Depo.Veri.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;
using YPM.Web.Areas.Admin.Models.Urun.Kategori;
using YPM.Web.Genel.Wrapper.Session;

namespace YPM.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UrunKategoriController
        : AdminOrtakController
    {
        private bool Disposed { get; set; }

        [Route("/admin/urunkategori/ekle")]
        public IActionResult Ekle([FromServices] IUrunKategoriDepo _urunKategori)
        {
            // Liste tekrar gelecek

            UrunKategoriEkleModel ke = new UrunKategoriEkleModel
            {
                TumOzellikGruplari = new List<SelectListItem>()
            };

            List<UrunOzellikSuret> TumOzellikListesi = new List<UrunOzellikSuret>();
            var tumOzellikListesi = _urunKategori.TumUrunOzellikDinamikListesi();

            foreach (var ozellik in tumOzellikListesi)
            {
                ke.TumOzellikGruplari.Add(new SelectListItem { Value = ozellik.UrunOzellikId.ToString(), Text = ozellik.Ad.ToString() });
            }

            return View(ke);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/urunkategori/ekle")]
        public IActionResult Ekle(
             UrunKategoriEkleModel model,
            [FromServices] IUrunKategoriDepo _urunKategori,
            [FromServices] IGunlukDepo _gunluk,
            [FromServices] ISistemDepo _sistem,
            [FromServices] ISessionSar _sessionSar)
        {
            model = KategoriEkleKontrol(model, _urunKategori);

            if (_urunKategori.BoyleBirKategoriVarMi(model.Ad)) ModelState.AddModelError("", "Böyle bir kategori zaten var.");

            if (ModelState.IsValid)
            {
                UrunKategoriSuret uks = new UrunKategoriSuret
                {
                    Ad = model.Ad,
                    AktifMi = model.AktifMi,
                    Tanim = model.Tanim,
                    SayfaBaslik = model.SayfaBaslik,
                    Aciklama = model.Aciklama,
                    AnahtarKelime = model.AnahtarKelime,
                    BabaId = 0,

                    YeniEklenecekOzellikler = new List<int>()
                };

                for (int i = 0; i < model.OzellikGrubuEkleId.Length; i++)
                {
                    uks.YeniEklenecekOzellikler.Add(model.OzellikGrubuEkleId[i]);
                }

                if (_urunKategori.UrunKategoriEkle(uks))
                {
                    //_gunluk.Ekle(
                    //  new GunlukVekil(
                    //          GetType().FullName,
                    //          MethodBase.GetCurrentMethod().Name,
                    //          _sistem.TarihGetir(),
                    //          GunlukDurum.ModelIstisna,
                    //          _sessionSar.SuAnki.AktifKisi.KisiId,
                    //          " Kategori ekleme işlemi başarılı. "
                    //      ));


                    ViewBag.Script = "$(function () { $('#EkleModal').modal('show');});";
                    ViewBag.Baslik = "Ekledim Gitti";
                    ViewBag.Aciklama = "Vatana millete hayırlı uğurlu olsun.";
                    ViewBag.AltBilgi = "<button type='button' class='btn btn-default' data-dismiss='modal'>Umursama</button>"
                                     + "<button type ='button' class='btn btn-primary'>Atarlan</button>";




                }
                else
                {
                    //_gunluk.Ekle(
                    //  new GunlukVekil(
                    //          GetType().FullName,
                    //          MethodBase.GetCurrentMethod().Name,
                    //          _sistem.TarihGetir(),
                    //          GunlukDurum.ModelIstisna,
                    //          _sessionSar.SuAnki.AktifKisi.KisiId,
                    //          " Kategori ekleme işlemi başarısız. "
                    //      ));


                    ViewBag.Script = "$(function () { $('#EkleModal').modal('show');});";
                    ViewBag.Baslik = "Eklenmedi";
                    ViewBag.Aciklama = "Hayıtlısı be gülüm...";
                    ViewBag.AltBilgi = "<button type='button' class='btn btn-default' data-dismiss='modal'>Umursama</button>"
                                     + "<button type ='button' class='btn btn-primary'>Atarlan</button>";
                }
            }

            // Modelde oluşan hataları ekler
            //foreach (var modelState in ViewData.ModelState.Values)
            //{
            //    foreach (var error in modelState.Errors)
            //    {
            //        _gunluk.Ekle(
            //            new GunlukVekil(
            //                    GetType().FullName,
            //                    MethodBase.GetCurrentMethod().Name,
            //                    _sistem.TarihGetir(),
            //                    GunlukDurum.ModelIstisna,
            //                    _sessionSar.SuAnki.AktifKisi.KisiId,
            //                    error.ErrorMessage
            //                ));
            //    }
            //}

            model.TumOzellikGruplari = new List<SelectListItem>();

            List<UrunOzellikSuret> TumOzellikListesi = new List<UrunOzellikSuret>();
            var tumOzellikListesi = _urunKategori.TumUrunOzellikDinamikListesi();

            foreach (var ozellik in tumOzellikListesi)
            {
                model.TumOzellikGruplari.Add(new SelectListItem { Value = ozellik.UrunOzellikId.ToString(), Text = ozellik.Ad.ToString() });
            }

            return View(model);
        }

        private UrunKategoriEkleModel KategoriEkleKontrol(UrunKategoriEkleModel model, [FromServices] IUrunKategoriDepo _urunKategori)
        {
            if (model.OzellikGrubuEkleId != null)
            {
                if (!(model.OzellikGrubuEkleId.Length > 0))
                {
                    ModelState.AddModelError("", "Lütfen Özellikleri Ekleyiniz.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen İlgili Özellikleri Seçiniz.");
            }

            if (model.Ad != null)
            {
                if (_urunKategori.KontrolEt(model.Ad))
                {
                    ModelState.AddModelError("", "Bu isimde bir kategori zaten var.");
                }
            }

            return model;
        }

        [Route("/admin/urunkategori/detay/{katId:int}")]
        public IActionResult Detay(
            int katId,
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            UrunKategoriSuret ds = new UrunKategoriSuret();
            ds = _urunKategori.UrunKategoriGetir(katId);

            UrunKategoriDetayModel model = new UrunKategoriDetayModel
            {
                KategoriId = ds.KategoriId,
                Aciklama = ds.Aciklama,
                Ad = ds.Ad,
                AktifMi = ds.AktifMi,
                AnahtarKelime = ds.AnahtarKelime,
                OzellikGrubu = ds.OzellikGrubu,
                SayfaBaslik = ds.SayfaBaslik,
                Tanim = ds.Tanim
            };

            return View(model);
        }

        [Route("/admin/urunkategori/duzenle/{katId:int}")]
        public IActionResult Duzenle(
         int katId,
         [FromServices]IUrunKategoriDepo _urunKategori)
        {

            UrunKategoriEkleModel ukem = new UrunKategoriEkleModel();

            {
                UrunKategoriSuret uks = new UrunKategoriSuret();

                uks = _urunKategori.UrunKategoriGetir(katId);
                ukem.Aciklama = uks.Aciklama;
                ukem.Ad = uks.Ad;
                ukem.AktifMi = uks.AktifMi;
                ukem.AnahtarKelime = uks.AnahtarKelime;
                ukem.SayfaBaslik = uks.SayfaBaslik;
                ukem.Tanim = uks.Tanim;


                uks.Dispose();
            }

            {
                ukem.TumOzellikGruplari = new List<SelectListItem>();

                foreach (var ozellik in _urunKategori.TumUrunOzellikDinamikListesi())
                {
                    ukem.TumOzellikGruplari
                        .Add(new SelectListItem
                        {
                            Value = ozellik.UrunOzellikId.ToString(),
                            Text = ozellik.Ad.ToString()
                        });
                }
            }

            {
                ukem.OzellikGrubuEkleId = _urunKategori.KategorininOzellikGrubuGetir(katId);
            }

            return View(ukem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/urunkategori/duzennle/{katId:int}")]
        public IActionResult Duzennle(
            int katId,
            [FromForm] UrunKategoriEkleModel model,
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (!(katId > 0)) return NotFound();

            UrunKategoriSuret uks = new UrunKategoriSuret();

            {
                uks.KategoriId = katId;
                uks.Aciklama = model.Aciklama;
                uks.Ad = model.Ad;
                uks.AktifMi = model.AktifMi;
                uks.AnahtarKelime = model.AnahtarKelime;
                uks.SayfaBaslik = model.SayfaBaslik;
                uks.Tanim = model.Tanim;
            }

            {
                uks.YeniEklenecekOzellikler = new List<int>();
                uks.YeniEklenecekOzellikler.AddRange(model.OzellikGrubuEkleId);
            }

            if (_urunKategori.KategorininOzellikleriniDuzenle(uks))
            {
                //_gunluk.Ekle(
                //  new GunlukVekil(
                //          GetType().FullName,
                //          MethodBase.GetCurrentMethod().Name,
                //          _sistem.TarihGetir(),
                //          GunlukDurum.ModelIstisna,
                //          _sessionSar.SuAnki.AktifKisi.KisiId,
                //          " Kategori ekleme işlemi başarılı. "
                //      ));

                uks.Dispose();
                return RedirectToAction("detay", new { katId });

            }
            else
            {
                //_gunluk.Ekle(
                //  new GunlukVekil(
                //          GetType().FullName,
                //          MethodBase.GetCurrentMethod().Name,
                //          _sistem.TarihGetir(),
                //          GunlukDurum.ModelIstisna,
                //          _sessionSar.SuAnki.AktifKisi.KisiId,
                //          " Kategori ekleme işlemi başarısız. "
                //      ));

                uks.Dispose();
                return RedirectToAction("detay", new { katId });


            }
        }

        [Route("/admin/urunkategori/altekle")]
        public IActionResult AltEkle(
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            UrunKategoriAltEkleModel aem = new UrunKategoriAltEkleModel();

            {
                aem.TumKategoriler = new List<SelectListItem>();

                // Tip SelectListIteme Benzediği için aynen geçtim.
                List<UrunOzellikSuret> TumKategoriListesi = new List<UrunOzellikSuret>();

                aem.TumKategoriler.Add(new SelectListItem() { Text = "Seçiniz", Selected = true, Value = "" });

                var tumKategoriListesi = _urunKategori.TumUrunKategoriDinamikListesi();

                foreach (var kat1 in tumKategoriListesi.Where(x => x.BabaId.Equals(0)))
                {
                    aem.TumKategoriler.Add(new SelectListItem { Value = kat1.KategoriId.ToString(), Text = "-" + kat1.Ad.ToString() });

                    foreach (var kat2 in tumKategoriListesi.Where(x => x.BabaId.Equals(kat1.KategoriId)))
                    {
                        aem.TumKategoriler.Add(new SelectListItem { Value = kat2.KategoriId.ToString(), Text = "--" + kat2.Ad.ToString() });

                        foreach (var kat3 in tumKategoriListesi.Where(x => x.BabaId.Equals(kat2.KategoriId)))
                        {
                            aem.TumKategoriler.Add(new SelectListItem { Value = kat3.KategoriId.ToString(), Text = "---" + kat3.Ad.ToString() });
                        }
                    }
                }
            }

            {
                aem.TumOzellikGruplari = new List<SelectListItem>();

                foreach (var ozellik in _urunKategori.TumUrunOzellikDinamikListesi())
                {
                    aem.TumOzellikGruplari
                        .Add(new SelectListItem
                        {
                            Value = ozellik.UrunOzellikId.ToString(),
                            Text = ozellik.Ad.ToString()
                        });
                }
            }

            return View(aem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/urunkategori/altekle")]
        public IActionResult AltEkle(
            UrunKategoriAltEkleModel model,
           [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (!(model.AnaKatId > 0)) ModelState.AddModelError("", "Lütfen Kategori seçiniz.");

            if (model.OzellikGrubuEkleId == null) ModelState.AddModelError("", "Lütfen Nitelik seçiniz.");

            if (_urunKategori.BoyleBirKategoriVarMi(model.Ad)) ModelState.AddModelError("", "Böyle bir kategori zaten var.");

            if (ModelState.IsValid)
            {
                UrunKategoriSuret uks = new UrunKategoriSuret();

                {
                    uks.Aciklama = model.Aciklama;
                    uks.Ad = model.Ad;
                    uks.AktifMi = model.AktifMi;
                    uks.AnahtarKelime = model.AnahtarKelime;
                    uks.BabaId = model.AnaKatId;
                    uks.SayfaBaslik = model.SayfaBaslik;
                    uks.Tanim = model.Tanim;
                }

                {
                    uks.YeniEklenecekOzellikler = new List<int>();
                    uks.YeniEklenecekOzellikler.AddRange(model.OzellikGrubuEkleId);
                }

                if (_urunKategori.UrunKategoriEkle(uks))
                {
                }
                else
                {
                }
            }

            {
                model.TumKategoriler = new List<SelectListItem>();

                // Tip SelectListIteme Benzediği için aynen geçtim.
                List<UrunOzellikSuret> TumKategoriListesi = new List<UrunOzellikSuret>();

                model.TumKategoriler.Add(new SelectListItem() { Text = "Seçiniz", Selected = true, Value = "0" });

                var tumKategoriListesi = _urunKategori.TumUrunKategoriDinamikListesi();

                foreach (var kat1 in tumKategoriListesi.Where(x => x.BabaId.Equals(0)))
                {
                    model.TumKategoriler.Add(new SelectListItem { Value = kat1.KategoriId.ToString(), Text = "-" + kat1.Ad.ToString() });

                    foreach (var kat2 in tumKategoriListesi.Where(x => x.BabaId.Equals(kat1.KategoriId)))
                    {
                        model.TumKategoriler.Add(new SelectListItem { Value = kat2.KategoriId.ToString(), Text = "--" + kat2.Ad.ToString() });

                        foreach (var kat3 in tumKategoriListesi.Where(x => x.BabaId.Equals(kat2.KategoriId)))
                        {
                            model.TumKategoriler.Add(new SelectListItem { Value = kat3.KategoriId.ToString(), Text = "---" + kat3.Ad.ToString() });
                        }
                    }
                }
            }

            {
                model.TumOzellikGruplari = new List<SelectListItem>();

                foreach (var ozellik in _urunKategori.TumUrunOzellikDinamikListesi())
                {
                    model.TumOzellikGruplari
                        .Add(new SelectListItem
                        {
                            Value = ozellik.UrunOzellikId.ToString(),
                            Text = ozellik.Ad.ToString()
                        });
                }
            }

            return View(model);
        }


        [Route("/admin/urunkategori/ozellik")]
        public IActionResult Ozellik(
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            List<UrunOzellikSuret> modelList = new List<UrunOzellikSuret>();

            modelList = _urunKategori.KategoriOzellikDetayGetir();

            return View(modelList);
        }


        [Route("/admin/urunkategori/ozellikekle")]
        public IActionResult OzellikEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/urunkategori/ozellikekle")]
        public IActionResult OzellikEkle(
            UrunKategoriOzellikEkle model,
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (_urunKategori.BoyleBirOzellikVarMi(model.Ad)) ModelState.AddModelError("", "Böyle bir özellik zaten var.");

            if (ModelState.IsValid)
            {
                _urunKategori.UrunOzellikEkle(new UrunOzellikSuret { Ad = model.Ad, Durum = model.Durum });

                return RedirectToAction("Ozellik");
            }

            return View(model);
        }

        [Route("/admin/urunkategori/ozellikdurum/{ozellikId:int}")]
        public IActionResult OzellikDurum(
            int ozellikId,
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (!(ozellikId > 0)) return NotFound();
            _urunKategori.OzellikDurumDegistir(ozellikId);

            return RedirectToAction("Ozellik");
        }

        [Route("/admin/urunkategori/ozelliksil/{ozellikId:int}")]
        public IActionResult OzellikSil(
             int ozellikId,
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (!(ozellikId > 0)) return NotFound();
            if (_urunKategori.OzellikBagliMi(ozellikId))
            {

                return RedirectToAction("Ozellik");
            }
            else
            {
                _urunKategori.OzellikSil(ozellikId);

                return RedirectToAction("Ozellik");
            }


        }

        [ResponseCache(Duration = 0, NoStore = true)]
        [Route("/admin/urunkategori/ozellikdetay/{ozellikId:int}")]
        public IActionResult OzellikDetay(
            int ozellikId,
            [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (!(ozellikId > 0)) return NotFound();


            UrunKategoriOzellikGrupDetayModel model = new UrunKategoriOzellikGrupDetayModel();

            {
                UrunOzellikSuret uos = new UrunOzellikSuret();
                try
                {
                    uos = _urunKategori.UrunOzellikGetir(ozellikId);

                    model.Ad = uos.Ad;
                    model.Durum = uos.Durum;
                    model.OzellikGrupDetayId = uos.UrunOzellikId;
                }
                finally
                {
                    if (uos != null) uos.Dispose();
                }
            }

            {
                model.TumKategoriSecilen = new List<UrunOzellikSuret>();
                model.TumKategoriPostedilen = new List<UrunOzellikSuret>();

                var tumKategoriListesi = _urunKategori.TumUrunKategoriDinamikListesi();



                foreach (var item in tumKategoriListesi)
                {
                    model.TumKategoriSecilen.Add(new UrunOzellikSuret { Ad = item.Ad, UrunOzellikId = item.KategoriId, BabaId = item.BabaId, Durum = false });
                    model.TumKategoriPostedilen.Add(new UrunOzellikSuret { Ad = item.Ad, UrunOzellikId = item.KategoriId, BabaId = item.BabaId, Durum = false });
                }
            }

            {
                var seciliOlanlar = _urunKategori.OzelligeBagliKategorileriGetir(model.OzellikGrupDetayId).ToList();
                var TkS = model.TumKategoriSecilen;

                for (int i = 0; i < seciliOlanlar.Count; i++)
                {
                    model.TumKategoriSecilen.Where(x => x.UrunOzellikId.Equals(seciliOlanlar[i])).FirstOrDefault().Durum = true;
                    model.TumKategoriPostedilen.Where(x => x.UrunOzellikId.Equals(seciliOlanlar[i])).FirstOrDefault().Durum = true;
                }

            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/urunkategori/ozellikdettay")]
        public IActionResult OzellikDettay(
          UrunKategoriOzellikGrupDetayModel model,
          [FromServices]IUrunKategoriDepo _urunKategori)
        {
            UrunOzellikSuret uos = new UrunOzellikSuret();

            uos.UrunOzellikId = model.OzellikGrupDetayId;
            uos.TumKategoriPostedilen = new List<UrunOzellikSuret>();
            uos.TumKategoriPostedilen = model.TumKategoriPostedilen;

            if (_urunKategori.UrunOzelliginKategorileriniDuzenle(uos))
                return View();

            else
                return RedirectToAction("giris", "ana", new { area = "" });
        }

        protected override void Dispose(bool disposing)
        {
            if (Disposed) return;

            //            if (disposing && _urunKategori != null) _urunKategori.Dispose();

            Disposed = true;

            base.Dispose(disposing);
        }
    }
}