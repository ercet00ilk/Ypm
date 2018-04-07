using System.Collections.Generic;

namespace YPM.SuretVarlik.Mulk.Suret.Urun.Kategori
{
    public class UrunKategoriDetaySuret
    {
        public int KategoriId { get; set; }
        public string Aciklama { get; set; }
        public string Ad { get; set; }
        public bool AktifMi { get; set; }
        public string AnahtarKelime { get; set; }
        public IDictionary<int, string> OzellikGrubu { get; set; }
        public string SayfaBaslik { get; set; }
        public string Tanim { get; set; }
    }
}