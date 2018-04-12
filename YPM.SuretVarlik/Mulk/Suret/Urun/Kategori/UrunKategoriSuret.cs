using System;
using System.Collections.Generic;

namespace YPM.SuretVarlik.Mulk.Suret.Urun.Kategori
{
    public class UrunKategoriSuret
          : IDisposable
    {
        public int KategoriId { get; set; }
        public string AnahtarKelime { get; set; }
        public string SayfaBaslik { get; set; }
        public string Aciklama { get; set; }
        public string Tanim { get; set; }
        public bool AktifMi { get; set; }
        public string Ad { get; set; }
        public int BabaId { get; set; }
        public IDictionary<int, string> OzellikGrubu { get; set; }
        public List<int> YeniEklenecekOzellikler { get; set; }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (OzellikGrubu != null) OzellikGrubu = null;
                    if (YeniEklenecekOzellikler != null) YeniEklenecekOzellikler = null;
                }

                disposedValue = true;
            }
        }

        ~UrunKategoriSuret()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}