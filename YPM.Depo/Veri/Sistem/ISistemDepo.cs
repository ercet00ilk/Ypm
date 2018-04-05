using System;

namespace YPM.Depo.Veri.Sistem
{
    public interface ISistemDepo
        : IDisposable
    {
        DateTime TarihGetir();
    }
}