using System.ComponentModel;

namespace YPM.SuretVarlik.Mulk.Suret.Urun.Kategori
{
    public class UrunOzellikSuret
    {
        public int UrunOzellikId { get; set; }

        [DisplayName("Adı")]
        public string Ad { get; set; }

        [DisplayName("Kategori Sayısı")]
        public int KategoriSayisi { get; set; }

        [DisplayName("Özellik Sayısı")]
        public int OzellikSayisi { get; set; }

        [DisplayName("Durum")]
        public bool Durum { get; set; }

        [DisplayName("Seçim")]
        public bool SeciliMi { get; set; }
    }
}