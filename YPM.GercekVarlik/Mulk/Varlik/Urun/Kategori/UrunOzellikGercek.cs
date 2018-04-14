using System;
using System.Collections.Generic;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunOzellikGercek
       : IDisposable
    {
        public int UrunOzellikId { get; set; }

        public string Ad { get; set; }

        public bool Durum { get; set; }

        public ICollection<UrunKategoriOzellikGercek> KategoriOzellik { get; } = new List<UrunKategoriOzellikGercek>();

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
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