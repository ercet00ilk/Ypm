using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunKategoriGercek
    {
        public int UrunKategoriId { get; set; }

        public int UrunUstKategoriId { get; set; }

        public string Ad { get; set; }

        public string ResimYol { get; set; }

        public string LinkYol { get; set; }
    }
}
