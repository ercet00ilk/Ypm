using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using YPM.Depo.Veri.Gunluk;
using YPM.Depo.Veri.Sistem;
using YPM.Depo.Veri.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;
using YPM.Web.Genel.Wrapper.Session;
using YPM.Web.Models.Urun.Kategori;

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

            UrunKategoriEkleModel ke = new UrunKategoriEkleModel();
            ke.TumOzellikGruplari = new List<SelectListItem>();

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

            if (ModelState.IsValid)
            {
                UrunKategoriSuret uks = new UrunKategoriSuret();
                uks.Ad = model.Ad;
                uks.AktifMi = model.AktifMi;
                uks.Tanim = model.Tanim;
                uks.SayfaBaslik = model.SayfaBaslik;
                uks.Aciklama = model.Aciklama;
                uks.AnahtarKelime = model.AnahtarKelime;
                uks.BabaId = 0;

                uks.YeniEklenecekOzellikler = new List<int>();

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

            UrunKategoriDetayModel model = new UrunKategoriDetayModel();
            model.KategoriId = ds.KategoriId;
            model.Aciklama = ds.Aciklama;
            model.Ad = ds.Ad;
            model.AktifMi = ds.AktifMi;
            model.AnahtarKelime = ds.AnahtarKelime;
            model.OzellikGrubu = ds.OzellikGrubu;
            model.SayfaBaslik = ds.SayfaBaslik;
            model.Tanim = ds.Tanim;

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
        [Route("/admin/urunkategori/duzenle/{katId:int}")]
        public IActionResult Duzenle(
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

            if (_urunKategori.UrunKategoriDuzenle(uks))
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
            }

            uks.Dispose();

            return View();
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
            UrunKategoriAltEkleModel aem,
           [FromServices]IUrunKategoriDepo _urunKategori)
        {
            if (!(aem.AnaKatId > 0)) ModelState.AddModelError("", "Lütfen Kategori seçiniz.");

            if (aem.OzellikGrubuEkleId == null) ModelState.AddModelError("", "Lütfen Nitelik seçiniz.");

            if (ModelState.IsValid)
            {
                UrunKategoriSuret uks = new UrunKategoriSuret();

                {
                    uks.Aciklama = aem.Aciklama;
                    uks.Ad = aem.Ad;
                    uks.AktifMi = aem.AktifMi;
                    uks.AnahtarKelime = aem.AnahtarKelime;
                    uks.BabaId = aem.AnaKatId;
                    uks.SayfaBaslik = aem.SayfaBaslik;
                    uks.Tanim = aem.Tanim;
                }

                {
                    uks.YeniEklenecekOzellikler = new List<int>();
                    uks.YeniEklenecekOzellikler.AddRange(aem.OzellikGrubuEkleId);
                }

                if (_urunKategori.UrunKategoriEkle(uks))
                {
                }
                else
                {
                }
            }

            {
                aem.TumKategoriler = new List<SelectListItem>();

                // Tip SelectListIteme Benzediği için aynen geçtim.
                List<UrunOzellikSuret> TumKategoriListesi = new List<UrunOzellikSuret>();

                aem.TumKategoriler.Add(new SelectListItem() { Text = "Seçiniz", Selected = true, Value = "0" });

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


        [Route("/admin/urunkategori/ozellikekle")]
        public IActionResult OzellikEkle()
        {
            return View();
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