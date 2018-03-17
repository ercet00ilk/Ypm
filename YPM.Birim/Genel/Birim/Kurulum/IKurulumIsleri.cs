using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.Birim.Genel.Birim.Kurulum
{
    public interface IKurulumIsleri
        : IDisposable
    {
        bool KuruluMu();
        void KurulumYap();
    }
}
