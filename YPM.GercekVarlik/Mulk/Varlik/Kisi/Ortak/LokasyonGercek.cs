using GercekVarlik.Mulk.Varlik.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using YPM.GercekVarlik.Mulk.Varlik.Ortak;

namespace YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak
{
    public class LokasyonGercek
        : AbsOrtakVarlik, IKimlikBilgi, IKayitTarihi, IBaglananKimlikBilgi, IBaglantiBilgi, IKaynakIade
    {
        public int Id { get; set; }
        public int BaglananId { get; set; }
        public string IpAdr { get; set; }
        public string MacAdr { get; set; }
        public DateTime KayitTarihi { get; set; }

        #region IKaynakIade


        public bool Disposed { get; set; }

        ~LokasyonGercek()
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
