using System;
using System.Collections.Generic;
using System.Text;
using YPM.GercekVarlik.Mulk.Varlik.Ortak;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunAracTip
        : IKaynakIade
    {
        public int UrunAracTipId { get; set; }

        public string UrunAracTipAd { get; set; }

        private bool Disposed { get; set; }

        ~UrunAracTip()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (Disposed) return;

            if (Disposing)
            {
            }

            Disposed = true;

        }
    }
}
