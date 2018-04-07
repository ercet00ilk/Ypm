using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
   public class UrunKategoriOzellikGercek
  : IDisposable
    {
        public int UrunKategoriOzellikId { get; set; }

        public int UrunKategoriId { get; set; }

        public virtual UrunKategoriGercek Kategori { get; set; }

        public int UrunOzellikId { get; set; }

        public virtual UrunOzellikGercek Ozellik { get; set; }

        #region IDisposable Support

        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Kategori != null) Kategori = null;
                    if (Ozellik != null) Ozellik = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
