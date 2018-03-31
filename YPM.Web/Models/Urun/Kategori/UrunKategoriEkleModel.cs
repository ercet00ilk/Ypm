using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Models.Urun.Kategori
{
    public class UrunKategoriEkleModel
    {
        [Required(ErrorMessage = "Lütfen KategoriAdı giriniz.")]
        [StringLength(140, MinimumLength = 2, ErrorMessage = "Kategori Adını 2 - 140 karakter arasında girebilirsiniz.")]
        public string Ad { get; set; }

        public bool AktifMi { get; set; }

        public string Tanim { get; set; }

        public string SayfaBaslik { get; set; }

        public string MetaAciklama { get; set; }

        public string MetaAnahtarKelime { get; set; }

        public int[] NitelikEkleId { get; set; }

        public List<UrunKategoriNitelik> KategorininNitelikleri { get; set; }

        public List<SelectListItem> TumNitelikler { get; set; }

    }


    public class UrunKategoriNitelik
    {
        public int UKNId { get; set; }

        public string Ad { get; set; }
    }



}
