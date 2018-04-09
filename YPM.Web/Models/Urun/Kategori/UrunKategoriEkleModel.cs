using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YPM.Web.Models.Urun.Kategori
{
    public class UrunKategoriEkleModel
    {
        [Required(ErrorMessage = "Lütfen KategoriAdı giriniz.")]
        [StringLength(140, MinimumLength = 2, ErrorMessage = "Kategori Adını 2 - 140 karakter arasında girebilirsiniz.")]
        public string Ad { get; set; }

        public bool AktifMi { get; set; }

        [Required(ErrorMessage = "Lütfen Tanım giriniz.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Tanım 5 - 200 karakter arasında girilebilir.")]
        public string Tanim { get; set; }

        [Required(ErrorMessage = "Lütfen SayfaBaslik giriniz.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "SayfaBaslik 5 - 150 karakter arasında girilebilir.")]
        public string SayfaBaslik { get; set; }

        [Required(ErrorMessage = "Lütfen MetaAciklama giriniz.")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "MetaAciklama 5 - 300 karakter arasında girilebilir.")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Lütfen MetaAnahtarKelime giriniz.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "MetaAnahtarKelime 5 - 150 karakter arasında girilebilir.")]
        public string AnahtarKelime { get; set; }

        public int[] OzellikGrubuEkleId { get; set; }

        public List<SelectListItem> TumOzellikGruplari { get; set; }

    }
}