using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.SuretVarlik.Mulk.Model.Kisi;
using YPM.Veri.Kaynak;

namespace YPM.Depo.Veri.Kisi
{
    public class KisiDeposu
        : IKisiDeposu
    {
        private bool Disposed { get; set; }

        public KisiDeposu()
        {

        }


        ~KisiDeposu()
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

        public async Task Ekle(KisiKayitModel kkm)
        {

            try
            {
                using (IKisiBirim kisi = KisiBirim.YeniGorev())
                {
                    await kisi.EkleAsync(new KisiGercek()
                    {
                        Ad = kkm.name,
                        Soyad = kkm.surname,
                        EPosta = kkm.email,
                        Sifre = kkm.password
                    });
                }
            }
            catch (Exception ex)
            {

            }




        }
    }
}
