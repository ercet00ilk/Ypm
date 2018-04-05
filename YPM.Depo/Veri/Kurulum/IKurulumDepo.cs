using System;
using System.Threading.Tasks;

namespace YPM.Depo.Veri.Kurulum
{
    public interface IKurulumDepo
     : IDisposable
    {
        Task<bool> KuruluMu();

        Task KurulumYap();
    }
}