using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YPM.Depo.Genel.Kurulum
{
    public interface IKurulumDeposu
        : IDisposable
    {
        Task<bool> KuruluMu();
        Task KurulumYap();
    }
}
