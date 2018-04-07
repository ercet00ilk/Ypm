using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Reflection;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Depo;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Depo.Veri.Kisi
{
    public class KisiDepo
         : IKisiDepo
    {
        private bool Disposed { get; set; }

        ~KisiDepo()
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

        public async Task<BasariliBasarisizDurum> Ekle(KisiKayitModel kkm)
        {
            bool islemOnay = new bool();

            BasariliBasarisizDurum donenDeger = new BasariliBasarisizDurum();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    using (KisiGercek kg = new KisiGercek()
                    {
                        Ad = Aes.Sifrele(kkm.name),
                        Soyad = Aes.Sifrele(kkm.surname),
                        EPosta = kkm.email,
                        Sifre = Aes.Sifrele(kkm.password),
                        KayitTarihi = kkm.KayitTarihi,
                        EpostaKontrol = kkm.EpostaKontrol,
                        EpostaOnayliMi = kkm.EpostaOnayliMi
                    })
                    {
                        KisiGercek donus = new KisiGercek();

                        donus = await gorev.Kisi.EkleAsync(kg);

                        using (ILokasyonBirim lokasyon = LokasyonBirim.YeniLokasyon())
                        {
                            using (LokasyonGercek lg = new LokasyonGercek()
                            {
                                KisiId = donus.KisiId,
                                IpAdr = kkm.IpAdr,
                                MacAdr = kkm.MacAdr,
                                KayitTarihi = kkm.KayitTarihi
                            })
                            {
                                try
                                {
                                    var miLokasyon = await gorev.Lokasyon.BulAsync(x => x.MacAdr == kkm.MacAdr && x.KisiId == donus.KisiId);

                                    if (miLokasyon == null) await gorev.Lokasyon.EkleAsync(lg);

                                    donenDeger = BasariliBasarisizDurum.Basarili;
                                }
                                catch (Exception)
                                {
                                    donenDeger = BasariliBasarisizDurum.Basarisiz;
                                }
                            }
                        }

                        donus.Dispose();
                    }

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
                        istisna.Sonuc = " public async Task<BasariliBasarisizDurum> Ekle(KisiKayitModel kkm) ";
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

        public async Task<VarYokDurum> EPostaKontrolAsync(string email)
        {
            VarYokDurum donenDeger = new VarYokDurum();

            try
            {
                using (IKisiBirim kisi = KisiBirim.YeniKisi())
                {
                    donenDeger = await kisi.EPostaKontrolAsync(email);
                }
            }
            catch (Exception)
            {
            }

            return donenDeger;
        }

        public DateTime TarihGetir()
        {
            return Tarih.GuncelTarihVer();
        }
    }
}