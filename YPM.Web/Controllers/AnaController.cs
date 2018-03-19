using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YPM.SuretVarlik.Mulk.Model.Istisna;

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