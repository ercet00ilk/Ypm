namespace YPM.GercekVarlik.Mulk.Varlik.Urun
{
    internal interface IFiyat
    {
        string Birim { get; set; }
        double Kdv { get; set; }
        double Iskonto { get; set; }
        double OrtAlis { get; set; }
        double SonAlis { get; set; }

    }
}