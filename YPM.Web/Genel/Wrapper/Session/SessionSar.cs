using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using YPM.SuretVarlik.Mulk.Suret.Session;

namespace YPM.Web.Genel.Wrapper.Session
{
    public class SessionSar
        : ISessionSar
    {
        private readonly IHttpContextAccessor _http;
        private ISession _session => _http.HttpContext.Session;

        public SessionSar(IHttpContextAccessor http)
        {
            _http = http;
        }

        public SessionIslemSuret SuAnki
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Ekle(string anahtar, object deger)
        {
            _session.SetString(anahtar, JsonConvert.SerializeObject(deger));
            return;
        }

        public T Getir<T>(string anahtar)
        {
            var deger = _session.GetString(anahtar);

            return deger == null ? default(T) : JsonConvert.DeserializeObject<T>(deger);
        }

        public void Sil(string anahtar)
        {
            _session.Remove(anahtar);
        }

        public void TumunuTemizle()
        {
            _session.Clear();
        }
    }
}