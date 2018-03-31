using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using YPM.Depo.Veri.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;
using YPM.Web.Models.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunKategoriController
        : AdminOrtakController
    {

        private bool Disposed { get; set; }
        private readonly IUrunKategoriDeposu _urunKategori;

        public UrunKategoriController(IUrunKategoriDeposu urunKategori)
        {
            _urunKategori = urunKategori;
        }


        [Route("/admin/urunkategori/ekle")]
        public IActionResult Ekle()
        {


            // Liste tekrar gelecek




            UrunKategoriEkleModel ke = new UrunKategoriEkleModel();

            ke.TumNitelikler = new List<SelectListItem>();
            ke.TumNitelikler.Add(new SelectListItem() { Value = "1", Text = "Deneme" });
            //List<UrunKategoriNitelikSuret> TumNitelikListesi = new List<UrunKategoriNitelikSuret>();
            //var tumNitelikListesi = _urunKategori.TumUrunKategoriNitelikListesi();

            //foreach (var nitelik in tumNitelikListesi)
            //{
            //    ke.TumNitelikler.Add(new SelectListItem { Value = nitelik.UrunKategoriNitelikId.ToString(), Text = nitelik.Ad.ToString() });
            //}

            return View(ke);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/urunkategori/ekle")]
        public IActionResult Ekle(UrunKategoriEkleModel model)
        {
            if (ModelState.IsValid)
            {

            }

            model.TumNitelikler = new List<SelectListItem>();
            model.TumNitelikler.Add(new SelectListItem() { Value = "1", Text = "Deneme" });


            //List<UrunKategoriNitelikSuret> TumNitelikListesi = new List<UrunKategoriNitelikSuret>();
            //var tumNitelikListesi = _urunKategori.TumUrunKategoriNitelikListesi();

            //foreach (var nitelik in tumNitelikListesi)
            //{
            //    model.TumNitelikler.Add(new SelectListItem { Value = nitelik.UrunKategoriNitelikId.ToString(), Text = nitelik.Ad.ToString() });
            //}

            return View(model);
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