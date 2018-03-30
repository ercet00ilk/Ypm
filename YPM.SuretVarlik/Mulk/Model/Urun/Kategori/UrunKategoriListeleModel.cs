using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YPM.SuretVarlik.Mulk.Model.Urun.Kategori
{
    public class UrunKategoriListeleModel
    {
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Lütfen Arac Tipi giriniz.")]
        [StringLength(140, MinimumLength = 2, ErrorMessage = "Araç Tipini 2 - 140 karakter arasında girebilirsiniz.")]
        public string Ad { get; set; }

        public int UstKategoriId { get; set; }
    }
}
