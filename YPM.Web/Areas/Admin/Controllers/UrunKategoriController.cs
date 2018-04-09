using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using YPM.Depo.Veri.Gunluk;
using YPM.Depo.Veri.Sistem;
using YPM.Depo.Veri.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;
using YPM.Web.Genel.Wrapper.Session;
using YPM.Web.Models.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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

                uks.YeniEklenecekNitelikler = new List<int>();

                for (int i = 0; i < model.OzellikGrubuEkleId.Length; i++)
                {
                    uks.YeniEklenecekNitelikler.Add(model.OzellikGrubuEkleId[i]);
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
                    ModelState.AddModelError("", "Lütfen Nitelikleri Ekleyiniz.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen İlgili Nitelikleri Seçiniz.");
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

        [Route("/Admin/UrunKategori/Detay/{katId:int}")]
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

        [Route("/Admin/UrunKategori/Duzenle/{katId:int}")]
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

        protected override void Dispose(bool disposing)
        {
            if (Disposed) return;

            //            if (disposing && _urunKategori != null) _urunKategori.Dispose();

            Disposed = true;

            base.Dispose(disposing);
        }
    }
}