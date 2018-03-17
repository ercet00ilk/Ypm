using System;
using YPM.Yonetim.Genel.Kurulum;

namespace YPM.Birim.Genel.Birim.Kurulum
{
    public class KurulumIsleri
           : IKurulumIsleri
    {
        private bool Disposed { get; set; }

        ~KurulumIsleri()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (Disposed) return;
            if (Disposing)
            {
                //if (_ornek != null) _ornek = null;

            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool KuruluMu()
        {
            return KurulumIsci.KuruluMu();
        }

        public void KurulumYap()
        {
            KurulumIsci.KurulumYap();
            return;
        }
    }
}
