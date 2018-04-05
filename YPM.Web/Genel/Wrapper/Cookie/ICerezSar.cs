using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace YPM.Web.Genel.Wrapper.Cookie
{
    public interface ICerezSar
    {
        Dictionary<string, string> Getir(string anahtar);

        void Olustur(string anahtar, Dictionary<string, string> deger, CookieOptions secenek);

        bool VarMi(string anahtar);

        void Sil(string anahtar);
    }
}