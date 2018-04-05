using System;
using System.Collections.Generic;

namespace YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori
{
    public class UrunKategoriGercek
        : IDisposable
    {
        public int UrunKategoriId { get; set; }

        public int BabaId { get; set; }

        public string Ad { get; set; }

        public bool AktifMi { get; set; }

        public string Tanim { get; set; }

        public string SayfaBaslik { get; set; }

        public string Aciklama { get; set; }

        public string AnahtarKelime { get; set; }

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

        void IDisposable.Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}