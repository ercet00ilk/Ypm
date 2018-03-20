using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Kurulum;

namespace YPM.Depo.Genel.Kurulum
{
    public class KurulumDeposu
        : IKurulumDeposu
    {
        private readonly IKurulumBirim _kurulum = KurulumBirim.OrnekVer();
        private bool Disposed { get; set; }

        ~KurulumDeposu()
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

        public async Task<bool> KuruluMu()
        {
            bool donenDeger = new bool();

            var islem = await _kurulum.BulAsync(x => x.Ad == "AnaKurulum");

            if (islem == null) donenDeger = false;
            else donenDeger = islem.Sonuc;

            return donenDeger;
        }

        public async Task KurulumYap()
        {
            var atesle = _kurulum.AtesleProsedurOlustur();

            await Task.WhenAll(atesle);

            return;
        }
    }
}
