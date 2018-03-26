using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.Depo.Veri.Session
{
    public interface ISessionDepo
          : IDisposable
    {
        int KisiIdGetir();
    }
}
