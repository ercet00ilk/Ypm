using System;
using System.Collections.Generic;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunNitelikGercek
        : IDisposable
    {
        public int UrunNitelikId { get; set; }

        public string Ad { get; set; }

        public ICollection<UrunKategoriNitelikGercek> KategoriNitelik { get; } = new List<UrunKategoriNitelikGercek>();

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

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