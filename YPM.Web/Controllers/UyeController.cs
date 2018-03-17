using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YPM.Web.Models.Basic.Uye;

namespace YPM.Web.Controllers
{
    public class UyeController
        : OrtakController
    {
        public IActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult YeniKayit(KisiKayitModel kkm)
        {
            if (ModelState.IsValid)
            {

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
    }
}