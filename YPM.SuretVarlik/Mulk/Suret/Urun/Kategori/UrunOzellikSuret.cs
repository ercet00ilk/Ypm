namespace YPM.SuretVarlik.Mulk.Suret.Urun.Kategori
{
    public class UrunOzellikSuret
    {
        public int UrunOzellikId { get; set; }
        public string Ad { get; set; }
        public int KategoriSayisi { get; set; }
        public int OzellikSayisi { get; set; }
        public bool Durum { get; set; }

        public bool SeciliMi { get; set; }
    }
}