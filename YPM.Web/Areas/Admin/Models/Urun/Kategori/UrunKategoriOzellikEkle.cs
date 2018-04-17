using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Areas.Admin.Models.Urun.Kategori
{
    public class UrunKategoriOzellikEkle
    {
        public int UrunOzellikId { get; set; }

        public string Ad { get; set; }

        public bool Durum { get; set; }
    }
}
