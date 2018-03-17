using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YPM.Web.Models.Istisna;

namespace YPM.Web.Controllers
{
    public class AnaController
        : OrtakController
    {
        public IActionResult Giris()
        {
            return View();
        }

        public IActionResult Istisna()
        {
            return View(new IstisnaViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}