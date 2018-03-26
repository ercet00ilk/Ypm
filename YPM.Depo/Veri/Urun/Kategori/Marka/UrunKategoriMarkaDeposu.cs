using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.Depo.Veri.Urun.Kategori.Marka
{
    public class UrunKategoriMarkaDeposu
        : IUrunKategoriMarkaDeposu
    {
        private bool Disposed { get; set; }

        ~UrunKategoriMarkaDeposu()
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
