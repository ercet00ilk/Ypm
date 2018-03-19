using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Kisi;
using YPM.SuretVarlik.Mulk.Model.Kisi;
using YPM.Veri.Kaynak;

namespace YPM.Depo.Genel.Kisi
{
    public class KisiDeposu
        : IKisiDeposu
    {
        private readonly IKisiBirim _kisi = KisiBirim.OrnekVer();
        private bool Disposed { get; set; }

        public KisiDeposu(IKisiBirim kisi)
        {
            _kisi = kisi;
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
                    if (_kisi != null) _kisi.Dispose();
                }
                Disposed = true;
            }
        }

        public async Task Ekle(KisiKayitModel kkm)
        {
            await _kisi.EkleAsync(new KisiGercek()
            {
                Ad = kkm.name,
                Soyad = kkm.surname,
                EPosta = kkm.email,
                Sifre = kkm.password
            });
        }
    }
}
