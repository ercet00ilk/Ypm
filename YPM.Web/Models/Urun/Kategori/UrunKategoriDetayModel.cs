using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Models.Urun.Kategori
{
    public class UrunKategoriDetayModel
    {
        public int KategoriId { get; set; }

        public string Ad { get; set; }

        public bool AktifMi { get; set; }

        public IDictionary<int, string> OzellikGrubu { get; set; }

        public string Tanim { get; set; }

        public string SayfaBaslik { get; set; }

        public string Aciklama { get; set; }

        public string AnahtarKelime { get; set; }
    }
}
