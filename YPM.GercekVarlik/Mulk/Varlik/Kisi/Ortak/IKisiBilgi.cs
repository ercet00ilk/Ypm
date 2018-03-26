using System;

namespace YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak
{
    internal interface IKisiBilgi
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        string EPosta { get; set; }
        string Sifre { get; set; }
        DateTime KayitTarihi { get; set; }
        string EpostaKontrol { get; set; }
        bool EpostaOnayliMi { get; set; }
    }
}