using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunKategoriNitelikGercek
    {
        public int UrunKategoriNitelikId { get; set; }



        public int UrunKategoriId { get; set; }

        public UrunKategoriGercek UrunKategori { get; set; }


        public int UrunNitelikId { get; set; }

        public UrunNitelikGercek UrunNitelik { get; set; }
    }
}
