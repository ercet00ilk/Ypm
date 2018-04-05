using System;

namespace YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Depo
{
    public class DepoIstisna
          : OrtakIstisna, IDisposable
    {
        public string TamYol { get; set; }
        public string Method { get; set; }
        public int KisiId { get; set; }
        public string TabanHata { get; set; }
        public string Sonuc { get; set; }
        public bool IslemOnay { get; set; }
        public DateTime Tarih { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public static DepoIstisna YeniIstisna()
        {
            return new DepoIstisna();
        }

        public void Yazdir(DepoIstisna istisna)
        {
            throw new NotImplementedException();
        }
    }
}