using System;
using System.Collections.Generic;
using System.Text;

namespace Birim.Genel.Birim.Sistem
{
    public interface ISistemIsleri
        : IDisposable
    {
        DateTime TarihGetir();
        string MacAdresGetir();
        string IpAdrGetir();
    }
}
