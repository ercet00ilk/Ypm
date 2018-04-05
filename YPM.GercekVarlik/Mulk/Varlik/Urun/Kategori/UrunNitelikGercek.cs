using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunNitelikGercek
    {
        public UrunNitelikGercek()
        {
            this.NitelikKategoriler = new HashSet<UrunKategoriNitelikGercek>();
        }

        public int UrunNitelikId { get; set; }

        public string Ad { get; set; }

        public ICollection<UrunKategoriNitelikGercek> NitelikKategoriler  { get; set; }
    }
}
