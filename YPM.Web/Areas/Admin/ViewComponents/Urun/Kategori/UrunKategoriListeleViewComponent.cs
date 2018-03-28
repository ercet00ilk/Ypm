using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPM.Depo.Veri.Urun.Kategori;

namespace YPM.Web.Areas.Admin.ViewComponents.Urun.Kategori
{
    [ViewComponent]
    public class UrunKategoriListeleViewComponent
        : ViewComponent
    {
        private readonly IUrunKategoriDeposu _kategoriDeposu;

        public UrunKategoriListeleViewComponent(IUrunKategoriDeposu kategoriDeposu)
        {
            _kategoriDeposu = kategoriDeposu;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //  UrunKategori/ViewComponents/Kategori/UrunKategoriListele
            return View("UrunKategoriListele", await _kategoriDeposu.Listele());
        }
    }
}
