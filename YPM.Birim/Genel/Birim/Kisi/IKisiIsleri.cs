using System;
using YPM.SuretVarlik.Mulk.Enum.Ortak;

namespace Birim.Genel.Birim.Kisi
{
    public interface IKisiIsleri
              : IDisposable
    {
        VarYok EPostaVarMi(string email);
    }
}
