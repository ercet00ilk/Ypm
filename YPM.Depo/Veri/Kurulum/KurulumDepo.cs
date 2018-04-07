using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Depo;

namespace YPM.Depo.Veri.Kurulum
{
    public class KurulumDepo
           : IKurulumDepo
    {
        private bool Disposed { get; set; }

        ~KurulumDepo()
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
                    using (IKurulumDepo kur = new KurulumDepo())
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
            bool islemOnay = new bool();

            bool donenDeger = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var olay = await gorev.Kurulum.BulAsync(x => x.Ad == "AnaKurulum");

                    if (olay == null) donenDeger = true;
                    else donenDeger = !(olay.Sonuc);

                    gorev.Tamamla();

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public async Task<bool> KuruluMu() ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return donenDeger;
        }

        public async Task KurulumYap()
        {
            bool islemOnay = new bool();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var anaKurulum = await gorev.Kurulum.EkleAsync(new KurulumGercek() { Ad = "AnaKurulum", Sonuc = true });

                    gorev.Kurulum.AtesleProsedurOlustur().Wait();

                    gorev.Tamamla();

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (DepoIstisna istisna = DepoIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public async Task KurulumYap() ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                }

                return;
            }
        }
    }
}