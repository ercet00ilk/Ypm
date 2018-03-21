using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
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

        public async Task<BasariliBasarisiz> Ekle(KisiKayitModel kkm)
        {
            BasariliBasarisiz donenDeger = new BasariliBasarisiz();

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

                donenDeger = BasariliBasarisiz.Basarili;
            }
            catch (Exception)
            {
                donenDeger = BasariliBasarisiz.Basarisiz;
            }

            return donenDeger;
        }

        public async Task<VarYok> EPostaKontrolAsync(string email)
        {
            VarYok donenDeger = new VarYok();

            try
            {
                using (IKisiBirim kisi = KisiBirim.YeniGorev())
                {
                    donenDeger = await kisi.EPostaKontrolAsync(email);
                }
            }
            catch (Exception)
            {

            }

            return donenDeger;
        }

     
    }
}
