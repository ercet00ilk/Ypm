using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.Birim.Genel.Birim.Kurulum;

namespace YPM.Depo.Veri.Kurulum
{
    public class KurulumDeposu
        : IKurulumDeposu
    {
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

            using (IGorevli gorev = Gorevli.YeniGorev())
            {
                var islem = await gorev.Kurulum.BulAsync(x => x.Ad == "AnaKurulum");

                if (islem == null) donenDeger = true;
                else donenDeger = !(islem.Sonuc);

                gorev.Tamamla();
            }

            return donenDeger;
        }

        public async Task KurulumYap()
        {
            using (IGorevli gorev = Gorevli.YeniGorev())
            {
                var anaKurulum = await gorev.Kurulum.EkleAsync(new KurulumGercek() { Ad = "AnaKurulum", Sonuc = true });

                gorev.Kurulum.AtesleProsedurOlustur().Wait();

                gorev.Tamamla();
            }

            return;
        }
    }
}
