using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YPM.Web.Genel.Wrapper.Cookie;

namespace YPM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]                // /Admin
    [Route("admin/ana")]            // /Admin/Ana
    public class AnaController
        : AdminOrtakController
    {
        // GET: /Admin/Ana/Giris
        [Route("")]
        [Route("giris")]
        public IActionResult Giris([FromServices] ICerezSar _cerezSar)
        {
            {
                BeniHatirla(_cerezSar);
            }

            return View();
        }

        [Route("giris2")]
        public IActionResult Giris2()
        {
            return View();
        }
    }
}