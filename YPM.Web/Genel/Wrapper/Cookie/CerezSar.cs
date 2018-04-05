using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.Web.Genel.Helper;

namespace YPM.Web.Genel.Wrapper.Cookie
{
    public class CerezSar
        : ICerezSar
    {
        private readonly IHttpContextAccessor _http;

        public CerezSar(IHttpContextAccessor http)
        {
            _http = http;
        }


        public Dictionary<string, string> Getir(string anahtar)
        {
            Dictionary<string, string> cookie = new Dictionary<string, string>();

            cookie = Aes.Coz(_http
                .HttpContext
                .Request
                .Cookies[anahtar])
                .FromStringToDictionary();

            return cookie;
        }

        public bool VarMi(string anahtar)
        {
            return _http
                .HttpContext
                .Request
                .Cookies
                .ContainsKey(anahtar);
        }

        public void Olustur(string anahtar, Dictionary<string, string> deger, CookieOptions secenek)
        {
            _http
                .HttpContext
                .Response
                .Cookies
                .Append(
                    anahtar, 
                    Aes.Sifrele(deger.FromDictionaryToString()), 
                    secenek);
        }

        public void Sil(string anahtar)
        {
            _http.HttpContext.Response.Cookies.Delete(anahtar);
        }
    }


}
