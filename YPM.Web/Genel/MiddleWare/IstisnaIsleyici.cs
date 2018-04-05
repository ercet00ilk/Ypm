using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YPM.Depo.Veri.Gunluk;
using YPM.Depo.Veri.Sistem;
using YPM.Web.Genel.Wrapper.Session;

namespace YPM.Web.Genel.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IstisnaIsleyici
    {
        private readonly RequestDelegate _next;
        private readonly IGunlukDepo _gunluk;
        private readonly ISistemDepo _sistem;
        private readonly ISessionSar _session;
        private readonly ILogger<IstisnaIsleyici> _gunlukcu;

        public IstisnaIsleyici(
            RequestDelegate next,
            ILoggerFactory logFactory,
            IGunlukDepo gunluk,
            ISistemDepo sistem,
            ISessionSar session
            )
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _gunluk = gunluk;
            _sistem = sistem;
            _session = session;
            _gunlukcu = logFactory?.CreateLogger<IstisnaIsleyici>() ?? throw new ArgumentNullException(nameof(logFactory));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                // Alttaki Degerlerle çekilmiyor?

                //using (GunlukVekil suanKiGunluk = GunlukVekil.YeniGunluk(
                //    httpContext.Items.GetType().FullName.ToString(),
                //  _next(httpContext).GetType().DeclaringMethod.Name.,
                //  _sistem.TarihGetir(),
                //  GunlukDurum.Istisna,
                //  _session.SuAnki.AktifKisi.KisiId,
                //  e.GetBaseException().ToString(),
                //  " İstisna oluştu. "
                //  ))
                //{
                //    _gunluk.Ekle(suanKiGunluk);
                //}

                return;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class IstisnaIsleyiciExtensions
    {
        public static IApplicationBuilder UseIstisnaIsleyici(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IstisnaIsleyici>();
        }
    }
}