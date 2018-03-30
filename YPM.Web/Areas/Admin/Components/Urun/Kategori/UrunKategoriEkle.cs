using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Areas.Admin.Components.Urun.Kategori
{
    [ViewComponent(Name = "UrunKategoriEkle")]
    public class UrunKategoriEkle
        :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("UrunKategoriEkle");
        }
    }
}
