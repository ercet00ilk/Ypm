using System;
using System.ComponentModel;

namespace YPM.SuretVarlik.Mulk.Suret.Urun.Kategori
{
    public class UrunOzellikSuret
        : IDisposable
    {
        public int UrunOzellikId { get; set; }

        [DisplayName("Adı")]
        public string Ad { get; set; }

        [DisplayName("Kategori Sayısı")]
        public int KategoriSayisi { get; set; }

        [DisplayName("Özellik Sayısı")]
        public int OzellikSayisi { get; set; }

        [DisplayName("Durum")]
        public bool Durum { get; set; }

        [DisplayName("Seçim")]
        public bool SeciliMi { get; set; }

        public int BabaId { get; set; }

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
        ~UrunOzellikSuret()
        {
            Dispose(false);
        }

        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion
    }
}