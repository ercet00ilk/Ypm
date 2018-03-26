using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.Depo.Veri.Sistem
{
    public interface ISistemDepo
        : IDisposable
    {
        DateTime TarihGetir();
    }
}
