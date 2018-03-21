using GercekVarlik.Mulk.Varlik.Ortak;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using YPM.GercekVarlik.Mulk.Varlik.Ortak;

namespace GercekVarlik.Mulk.Varlik.Kurulum.Ortak
{
    public class KurulumGercek
        : AbsOrtakVarlik, IOlayBilgi, IKaynakIade
    {
        public int KurulumId { get; set; }
        public string Tip { get; set; }
        public string Ad { get; set; }
        public bool Sonuc { get; set; }

        #region IKaynakIade

        [NotMapped]
        public bool Disposed { get; set; }

        ~KurulumGercek()
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
            if (!Disposed)
            {
                if (Disposing)
                {
                }
                Disposed = true;
            }
        }

        #endregion IKaynakIade
    }
}