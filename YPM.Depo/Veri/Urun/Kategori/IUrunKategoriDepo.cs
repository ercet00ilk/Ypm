﻿using System.Collections.Generic;
using YPM.SuretVarlik.Mulk.Suret.Urun.Kategori;

namespace YPM.Depo.Veri.Urun.Kategori
{
    public interface IUrunKategoriDepo
    {
        bool KontrolEt(string ad);

        ICollection<UrunKategoriSuret> TumUrunKategoriDinamikListesi();

        ICollection<UrunOzellikSuret> TumUrunOzellikDinamikListesi();

        bool UrunKategoriEkle(UrunKategoriSuret uks);

        UrunKategoriSuret UrunKategoriGetir(int katId);

        UrunKategoriSuret UrunKategoriDuzenle(int katId);

        bool UrunKategoriDuzenle(UrunKategoriSuret uks);

        int[] KategorininOzellikGrubuGetir(int katId);

        List<UrunOzellikSuret> KategoriOzellikDetayGetir();
    }
}