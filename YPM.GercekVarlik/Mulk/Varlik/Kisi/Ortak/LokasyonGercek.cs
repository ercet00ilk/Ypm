using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using GercekVarlik.Mulk.Varlik.Ortak;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using YPM.GercekVarlik.Mulk.Varlik.Ortak;

namespace YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak
{
    public class LokasyonGercek
        : AbsOrtakVarlik, IKayitTarihi, IBaglantiBilgi, IKaynakIade
    {
        public int LokasyonId { get; set; }
        public int KisiId { get; set; }
        public string IpAdr { get; set; }
        public string MacAdr { get; set; }
        public DateTime KayitTarihi { get; set; }

        public KisiGercek Kisi { get; set; }

        #region IKaynakIade

        [NotMapped]
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

        #endregion IKaynakIade
    }
}