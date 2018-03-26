using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPM.Depo.Veri.Urun.Kategori.AracTip;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Models.Shared.Urun.Kategori
{
    public class UrunKategoriAracTipEkleViewComponent
        : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AracTipEkle", new UrunKategoriAracTipModel());
        }

    }
}
