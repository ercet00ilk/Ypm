using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Kurulum;

namespace YPM.Depo.Genel.Kurulum
{
    public class KurulumDeposu
        : IKurulumDeposu
    {
        private readonly IKurulumBirim _kurulum = KurulumBirim.OrnekVer();
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

        public Task<bool> KuruluMu()
        {
            throw new NotImplementedException();
        }

        public Task KurulumYap()
        {
            throw new NotImplementedException();
        }

        //public Task<bool> KuruluMu()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task KurulumYap()
        //{
        //    await _kurulum.AtesleProsedurOlustur();
        //    return;
        //}
    }
}
