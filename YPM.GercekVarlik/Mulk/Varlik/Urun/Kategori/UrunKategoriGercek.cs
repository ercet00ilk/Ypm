using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunKategoriGercek
    {
        public UrunKategoriGercek()
        {
            this.KategoriNitelikler = new HashSet<UrunKategoriNitelikGercek>();
        }

        public int UrunKategoriId { get; set; }

        public int UrunUstKategoriId { get; set; }

        public string Ad { get; set; }

        public bool AktifMi { get; set; }

        public string Tanim { get; set; }

        public string SayfaBaslik { get; set; }

        public string Aciklama { get; set; }

        public string AnahtarKelime { get; set; }


        public ICollection<UrunKategoriNitelikGercek> KategoriNitelikler { get; set; }
    }
}
