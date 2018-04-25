using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;

namespace YPM.Web.Areas.Admin.Models.Urun.Kategori
{
    public class UrunKategoriOzellikGrupDetayModel
    {
        public int OzellikGrupDetayId { get; set; }

        public string Ad { get; set; }

        [DisplayName("Aktif Mi")]
        public bool Durum { get; set; }

        public List<SelectListItem> TumKategoriler { get; internal set; }

        public List<UrunOzellikSuret> TumKategoriSecilen { get; set; }
        public List<UrunOzellikSuret> TumKategoriPostedilen { get; set; }
    }
}