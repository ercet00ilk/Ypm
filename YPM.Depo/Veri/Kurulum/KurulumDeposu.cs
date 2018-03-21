﻿using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using System;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Birim.Genel.Birim.Generic;

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

        public static async Task Kur()
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (IKurulumDeposu kur = new KurulumDeposu())
                    {
                        if (await kur.KuruluMu()) kur.KurulumYap().Wait();

                        transaction.Complete();
                    }
                }
                catch (Exception)
                {
                    transaction.Dispose();
                }
            }
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