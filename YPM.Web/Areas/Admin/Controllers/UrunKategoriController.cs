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
            ke.TumNitelikler = new List<SelectListItem>();

            List<UrunNitelikSuret> TumNitelikListesi = new List<UrunNitelikSuret>();
            var tumNitelikListesi = _urunKategori.TumUrunNitelikListesi();

            foreach (var nitelik in tumNitelikListesi)
            {
                ke.TumNitelikler.Add(new SelectListItem { Value = nitelik.UrunNitelikId.ToString(), Text = nitelik.Ad.ToString() });
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

                for (int i = 0; i < model.NitelikEkleId.Length; i++)
                {
                    uks.YeniEklenecekNitelikler.Add(model.NitelikEkleId[i]);
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

            model.TumNitelikler = new List<SelectListItem>();

            List<UrunNitelikSuret> TumNitelikListesi = new List<UrunNitelikSuret>();
            var tumNitelikListesi = _urunKategori.TumUrunNitelikListesi();

            foreach (var nitelik in tumNitelikListesi)
            {
                model.TumNitelikler.Add(new SelectListItem { Value = nitelik.UrunNitelikId.ToString(), Text = nitelik.Ad.ToString() });
            }

            return View(model);
        }

        private UrunKategoriEkleModel KategoriEkleKontrol(UrunKategoriEkleModel model, IUrunKategoriDepo _urunKategori)
        {
            if (model.NitelikEkleId != null)
            {
                if (!(model.NitelikEkleId.Length > 0))
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

        [Route("/Admin/UrunKategori/Getir/{katId}")]
        public IActionResult Getir(int katId)
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AracTipEkle(UrunKategoriAracTipModel model)
        //{
        //    if (!string.IsNullOrEmpty(model.AracTipAd))
        //        await _aracTipDepo.Ekle(model.AracTipAd);
        //    return RedirectToAction("AracTip");
        //}

        //public async Task<IActionResult> AracSil(int? id)
        //{
        //    if (id is int) await _aracTipDepo.Sil((int)id);

        //    return RedirectToAction("AracTip");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AracTipEkle(UrunKategoriAracTipEkleModel atem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        atem.AracTipAd = atem.AracTipAd.ToUpper();

        //        await _UrunKategoriAracTip.Ekle(atem.AracTipAd);

        //        return RedirectToAction("AracTipListele");
        //    }

        //    return View(atem);
        //}

        //public async Task<IActionResult> AracTipListele()
        //{
        //    return View(await _UrunKategoriAracTip.Listele());
        //}

        //public IActionResult MarkaEkle()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> MarkaEkle(UrunKategoriMarkaEkleModel mem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        mem.Ad = mem.Ad.ToUpper();

        //        await _UrunKategoriMarka.Ekle(mem.Ad);

        //        return MarkaListele();
        //    }

        //    return View(mem);
        //}

        //public IActionResult MarkaListele()
        //{
        //    List<UrunKategoriMarkaEkleModel> list = new List<UrunKategoriMarkaEkleModel>();

        //    list=

        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            if (Disposed) return;

            //            if (disposing && _urunKategori != null) _urunKategori.Dispose();

            Disposed = true;

            base.Dispose(disposing);
        }
    }
}