using GercekVarlik.Mulk.Varlik.Ortak;
using System;
using YPM.GercekVarlik.Mulk.Varlik.Ortak;

namespace GercekVarlik.Mulk.Varlik.Kurulum.Ortak
{
    public class KurulumGercek
        : AbsOrtakVarlik, IKimlikBilgi, IOlayBilgi,IKaynakIade
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public string Ad { get; set; }
        public bool Sonuc { get; set; }

        #region IKaynakIade


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

        #endregion
    }
}