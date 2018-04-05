using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.SuretVarlik.Mulk.Suret.Urun.Kategori
{
    public class UrunKategoriSuret
    {
        public int UrunKategoriId { get; set; }
        public string AnahtarKelime { get; set; }
        public string SayfaBaslik { get; set; }
        public string Aciklama { get; set; }
        public string Tanim { get; set; }
        public bool AktifMi { get; set; }
        public string Ad { get; set; }
        public int UrunUstKategoriId { get; set; }
        public List<int> YeniEklenecekNitelikler { get; set; }
    }
}
