using Microsoft.Extensions.Caching.Memory;
using System;

namespace YPM.Web.Genel.Wrapper.Cache
{
    public class OnBellekSar
        : IOnBellekSar
    {
        private readonly IMemoryCache _cache;

        public OnBellekSar(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Ekle<T>(string anahtar, T deger, int dakika)
        {
            _cache.Set<T>(anahtar, deger, DateTimeOffset.Now.AddMinutes(dakika));
            return;
        }

        public T Getir<T>(string anahtar)
        {
            return _cache.Get<T>(anahtar);
        }

        public void Sil(string anahtar)
        {
            _cache.Remove(anahtar);
            return;
        }

        public bool VarMi<T>(string anahtar, out T deger)
        {
            return !_cache.TryGetValue<T>(anahtar, out deger);
        }
    }
}