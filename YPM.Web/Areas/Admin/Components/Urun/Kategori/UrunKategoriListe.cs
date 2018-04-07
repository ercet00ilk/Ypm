using Microsoft.AspNetCore.Mvc;
using YPM.Depo.Veri.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Components.Urun.Kategori
{
    [ViewComponent(Name = "UrunKategoriListe")]
    public class UrunKategoriListe
        : ViewComponent
    {
        private readonly IUrunKategoriDepo _urunKategoriDepo;

        public UrunKategoriListe(IUrunKategoriDepo urunKategoriDepo)
        {
            _urunKategoriDepo = urunKategoriDepo;
        }

        public IViewComponentResult Invoke()
        {
            return View("UrunKategoriListe", _urunKategoriDepo.TumUrunKategoriDinamikListesi());
        }
    }
}