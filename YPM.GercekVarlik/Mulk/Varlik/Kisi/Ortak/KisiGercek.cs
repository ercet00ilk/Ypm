using GercekVarlik.Mulk.Varlik.Ortak;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using YPM.GercekVarlik.Mulk.Varlik.Ortak;

namespace GercekVarlik.Mulk.Varlik.Kisi.Ortak
{
    public class KisiGercek
        : AbsOrtakVarlik, IKayitTarihi, IVarlikBilgi, IKaynakIade
    {
        public int KisiId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public string EpostaKontrol { get; set; }
        public bool EpostaOnayliMi { get; set; }

        public ICollection<LokasyonGercek> Lokasyonlar { get; set; }

        public KisiGercek()
        {
            this.Lokasyonlar = new HashSet<LokasyonGercek>();
        }

        #region IKaynakIade

        [NotMapped]
        public bool Disposed { get; set; }

        ~KisiGercek()
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