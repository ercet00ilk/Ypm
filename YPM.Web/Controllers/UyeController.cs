using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using YPM.Depo.Veri.Kisi;
using YPM.SuretVarlik.Mulk.Model.Istisna;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Web.Controllers
{
    public class UyeController
        : OrtakController
    {
        private readonly IKisiDeposu _kisi;

        public UyeController(IKisiDeposu kisi)
        {
            _kisi = kisi;
        }

        public IActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YeniKayit(KisiKayitModel kkm)
        {
            if (ModelState.IsValid)
            {
                await _kisi.Ekle(kkm);
            }

            return View(kkm);
        }


        public IActionResult GuvenliGiris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuvenliGiris(KisiGirisModel kgm)
        {
            if (ModelState.IsValid)
            {

            }

            return View(kgm);
        }


        public IActionResult Error()
        {
            return View(new IstisnaViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}