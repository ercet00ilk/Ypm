using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using YPM.SuretVarlik.Mulk.Model.Istisna;
using YPM.Web.Genel.Wrapper.Cookie;
using YPM.Web.Genel.Wrapper.Session;

namespace YPM.Web.Controllers
{
    public class AnaController
        : OrtakController
    {
        public IActionResult Giris(
            [FromServices] ICerezSar _cerezSar,
            [FromServices] ISessionSar _sessionSar)
        {

            {
                if (!UyeGirisYaptiMi()) BeniHatirla(_cerezSar);
            }

            return View();
        }

        [Route("/Istisna")]
        public IActionResult Istisna()
        {
            return View(new IstisnaViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //}

        ////
        //// GET: /Ana/

        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        //// GET: /Ana/Hosgeldiniz/
        //// Requires using System.Text.Encodings.Web;
        //public string Welcome(string ad, string soyad)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {ad}, NumTimes is: {soyad}");
        //}

        // GET: Movies/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movie);
        //}
    }
}