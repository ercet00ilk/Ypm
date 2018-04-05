using System;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunKategoriNitelikGercek
        : IDisposable
    {
        public int UrunKategoriNitelikId { get; set; }

        public int UrunKategoriId { get; set; }

        public virtual UrunKategoriGercek Kategori { get; set; }

        public int UrunNitelikId { get; set; }

        public virtual UrunNitelikGercek Nitelik { get; set; }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Kategori != null) Kategori = null;
                    if (Nitelik != null) Nitelik = null;
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