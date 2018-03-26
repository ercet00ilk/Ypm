using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPM.Depo.Veri.Urun.Kategori.AracTip;

namespace YPM.Web.Areas.Admin.Models.Shared.Urun.Kategori
{
    public class UrunKategoriAracTipListeleViewComponent
        : ViewComponent
    {
        private readonly IUrunKategoriAracTipDeposu _aracTipDepo;

        public UrunKategoriAracTipListeleViewComponent(IUrunKategoriAracTipDeposu aracTipDepo)
        {
            _aracTipDepo = aracTipDepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AracTipListele",await _aracTipDepo.Listele());
        }
    }
}
