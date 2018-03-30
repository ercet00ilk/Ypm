using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Birim
{
    public class BirimIstisna
           : OrtakIstisna,IDisposable
    {
        public IDictionary Veri { get; set; }
        public string Link { get; set; }
        public int HSonuc { get; set; }
        public string Kaynak { get; set; }
        public string Mesaj { get; set; }
        public string YiginIzleme { get; set; }
        public bool IslemOnay { get; set; }
        public DateTime Tarih { get; set; }
        public string Method { get; set; }
        public string TamYol { get; set; }
        public string Sonuc { get; set; }
        public string TabanHata { get; set; }
        public string Hata { get; set; }
        public int KisiId { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public static BirimIstisna YeniIstisna()
        {
            return new BirimIstisna();
        }

        public void Yazdir(BirimIstisna istisna)
        {
            throw new NotImplementedException();
        }
    }
}
