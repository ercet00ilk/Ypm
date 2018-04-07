using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
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
                .Split('&').Select(s => s.Split('=')).ToDictionary(kvp => kvp[0], kvp => kvp[1]);

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
                    Aes.Sifrele(string.Join("&", deger.Select(kvp => string.Join("=", kvp.Key, kvp.Value)))),
                    secenek);
        }

        public void Sil(string anahtar)
        {
            _http.HttpContext.Response.Cookies.Delete(anahtar);
        }

        public void TumunuTemizle()
        {
            foreach (var item in _http.HttpContext.Request.Cookies.Keys)
            {
                _http.HttpContext.Response.Cookies.Delete(item);
            }
        }
    }
}