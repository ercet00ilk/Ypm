using System;
using YPM.SuretVarlik.Mulk.Suret.Gunluk;

namespace YPM.Depo.Veri.Gunluk
{
    public class GunlukDepo
        : IGunlukDepo
    {
        private bool Disposed { get; set; }

        ~GunlukDepo()
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

        public void Ekle(GunlukVekil suanKiGunluk)
        {
            throw new NotImplementedException();
        }
    }
}