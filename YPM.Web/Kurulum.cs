using System;
using YPM.Birim.Genel.Birim.Kurulum;

namespace YPM.Web
{
    public class Kurulum
    {
        public static readonly Kurulum Islem = new Kurulum();

        private Kurulum()
        {
        }

        internal void Kur()
        {
            using (IKurulumIsleri kur = new KurulumIsleri())
            {
                if (kur.KuruluMu()) kur.KurulumYap();
            }
        }
    }
}