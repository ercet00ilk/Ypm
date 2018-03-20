using System;
using System.Threading.Tasks;
using YPM.Depo.Genel.Kurulum;

namespace YPM.Web
{
    public class Kurulum
    {
        public static readonly Kurulum Islem = new Kurulum();

        private Kurulum()
        {
        }

        internal async Task Kur()
        {


            IKurulumDeposu kur = new KurulumDeposu();

            try
            {
                if (await kur.KuruluMu()) kur.KurulumYap().Wait();
            }
            finally
            {
                ((IDisposable)kur).Dispose();
            }
        }



    }
}