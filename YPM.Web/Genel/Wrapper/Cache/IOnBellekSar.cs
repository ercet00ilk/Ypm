using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Genel.Wrapper.Cache
{
    public interface IOnBellekSar
    {
        void Ekle<T>(string anahtar, T deger, int dakika);

        void Sil(string anahtar);

        bool VarMi<T>(string anahtar, out T deger);

        T Getir<T>(string anahtar);

        
    }

    /** Kullanımı
     * 
     * 
     *     {
                _onBellekSar.Ekle<int>("AdminUrunKategoriEkle", katId, 15);
            }

            int deger = new int();
            string deger2 = string.Empty;
            int deger3 = new int();

            {
                if (_onBellekSar.VarMi<int>("AdminUrunKategoriEkle", out deger)) deger2 = "qwe";

                deger3 = _onBellekSar.Getir<int>("AdminUrunKategoriEkle");

                _onBellekSar.Sil("AdminUrunKategoriEkle");
            }
    */
}
