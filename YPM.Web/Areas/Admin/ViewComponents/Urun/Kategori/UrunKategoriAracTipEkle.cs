using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Web.Areas.Admin.ViewComponents.Urun.Kategori
{
    public class UrunKategoriAracTipEkle
        : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("AracTipEkle", new UrunKategoriAracTipModel());
        }

      
    }
}
