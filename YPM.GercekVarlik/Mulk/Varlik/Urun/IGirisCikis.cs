using System;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun
{
    internal interface IGirisCikis
    {

        string StoktakiMiktar { get; set; }
        double StokDegeri { get; set; }

        int GirisFirmaId { get; set; }
        int GirilenAdet { get; set; }
        int GirenKisiId { get; set; }
        DateTime GirisTarihi { get; set; }

        int CikisFirmaId { get; set; }
        int CikilanAdet { get; set; }
        int CikanKisiId { get; set; }
        DateTime CikisTarihi { get; set; }

    }
}