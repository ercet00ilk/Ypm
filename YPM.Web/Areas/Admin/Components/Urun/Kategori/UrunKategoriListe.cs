using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPM.Depo.Veri.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Model.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Components.Urun.Kategori
{
    [ViewComponent(Name = "UrunKategoriListe")]
    public class UrunKategoriListe
        : ViewComponent
    {
        private readonly IUrunKategoriDeposu _urunKategoriDepo;

        public UrunKategoriListe(IUrunKategoriDeposu urunKategoriDepo)
        {
            _urunKategoriDepo = urunKategoriDepo;
        }

        public IViewComponentResult Invoke()
        {
            return View("UrunKategoriListe", _urunKategoriDepo.Listele());
        }
    }
}
