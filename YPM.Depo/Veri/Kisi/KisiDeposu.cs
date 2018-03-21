using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Birim.Genel.Birim.Generic;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.Birim.Genel.Birim.Lokasyon;
using YPM.Depo.Ortak;
using YPM.GercekVarlik.Mulk.Varlik.Kisi.Ortak;
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

            KisiGercek donus = new KisiGercek();

            using (IGorevli gorev = Gorevli.YeniGorev())
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
                    using (ILokasyonBirim lokasyon = LokasyonBirim.YeniLokasyon())
                    {
                        using (LokasyonGercek lg = new LokasyonGercek()
                        {
                            BaglananId = kg.Id,
                            IpAdr = kkm.IpAdr,
                            MacAdr = kkm.MacAdr,
                            KayitTarihi = kkm.KayitTarihi
                        })
                        {
                            donus = await gorev.Kisi.EkleAsync(kg);

                            var miLokasyon = await gorev.Lokasyon.BulAsync(x => x.MacAdr == kkm.MacAdr);

                            if (miLokasyon == null) await gorev.Lokasyon.EkleAsync(lg);
                            
                        }
                    }
                }

                gorev.Tamamla();
            }

            return donenDeger;
        }

        public async Task<VarYok> EPostaKontrolAsync(string email)
        {
            VarYok donenDeger = new VarYok();

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
