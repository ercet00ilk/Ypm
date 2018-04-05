using System;
using YPM.SuretVarlik.Mulk.Suret.Gunluk;

namespace YPM.Depo.Veri.Gunluk
{
    public interface IGunlukDepo
          : IDisposable
    {
        void Ekle(GunlukVekil suanKiGunluk);
    }
}