using System;
using System.Collections.Generic;
using System.Text;
using YPM.SuretVarlik.Mulk.Enum.Ortak;

namespace YPM.SuretVarlik.Mulk.Suret.Gunluk
{
    public class GunlukVekil
       : IDisposable
    {
        private string tamYol;
        private string method;
        private DateTime tarih;
        private GunlukDurum durum;
        private int kisiId;
        private string istisna;
        private string sonuc;

        public GunlukVekil(
            string tamYol,
            string method,
            DateTime tarih,
            GunlukDurum durum,
            int kisiId,
            string sonuc
            )
        {
            this.tamYol = tamYol;
            this.method = method;
            this.tarih = tarih;
            this.durum = durum;
            this.kisiId = kisiId;
            this.sonuc = sonuc;
        }

        public GunlukVekil(
           string tamYol,
           string method,
           DateTime tarih,
           GunlukDurum durum,
           int kisiId,
           string istisna,
           string sonuc
           )
        {
            this.tamYol = tamYol;
            this.method = method;
            this.tarih = tarih;
            this.durum = durum;
            this.kisiId = kisiId;
            this.istisna = istisna;
            this.sonuc = sonuc;
        }

        private bool Disposed { get; set; }

        ~GunlukVekil()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;

            if (disposing)
            {


                Disposed = true;
            }

            return;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static GunlukVekil YeniGunluk(
            string tamYol,
            string method,
            DateTime tarih,
            GunlukDurum durum,
            int kisiId,
            string sonuc
            )
        {
            return new GunlukVekil(tamYol, method, tarih, durum, kisiId, sonuc);
        }

        public static GunlukVekil YeniGunluk(
           string tamYol,
            string method,
            DateTime tarih,
            GunlukDurum durum,
            int kisiId,
            string istisna,
            string sonuc)
        {
            return new GunlukVekil(tamYol, method, tarih, durum, kisiId, istisna, sonuc);
        }





    }
}
