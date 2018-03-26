namespace YPM.GercekVarlik.Mulk.Varlik.Urun
{
    internal interface IStokKod
    {
        string OemKimlik { get; set; }
        string StokKimlik { get; set; }
        string StokTamAd { get; set; }
        string Marka { get; set; }
        string Model { get; set; }
        string Etiket { get; set; }
    }
}