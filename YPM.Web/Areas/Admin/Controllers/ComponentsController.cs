using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Controllers
{
    public class ComponentsController
        : AdminOrtakController
    {
        public IActionResult UrunKategoriListele()
        {
            // ViewComponents/Urun/Kategori/UrunKategoriListele
            return ViewComponent("UrunKategoriListele");
        }
    }
}