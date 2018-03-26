using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YPM.Depo.Veri.Gunluk;
using YPM.Depo.Veri.Kisi;
using YPM.Depo.Veri.Kurulum;
using YPM.Depo.Veri.Session;
using YPM.Depo.Veri.Sistem;
using YPM.Depo.Veri.Urun.Kategori.AracTip;
using YPM.Depo.Veri.Urun.Kategori.Marka;
using YPM.Web.Genel.MiddleWare;

namespace YPM.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            KurulumDeposu.Kur().Wait();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Depo
            services.AddTransient<IGunlukDepo, GunlukDepo>();
            services.AddTransient<IKisiDeposu, KisiDeposu>();
            services.AddTransient<ISistemDepo, SistemDepo>();
            services.AddTransient<ISessionDepo, SessionDepo>();
            services.AddTransient<IUrunKategoriAracTipDeposu, UrunKategoriAracTipDeposu>();
            services.AddTransient<IUrunKategoriMarkaDeposu, UrunKategoriMarkaDeposu>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logFactory)
        {
            logFactory.AddConsole(Configuration.GetSection("Logging"));
            logFactory.AddDebug();



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseIstisnaIsleyici();
                app.UseBrowserLink();
            }
            else
            {
                app.UseIstisnaIsleyici();
                app.UseExceptionHandler("/istisna");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Ana}/{action=Giris}/{id?}"
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=ana}/{action=giris}/{id?}");
            });
        }
    }


    /*
    app.Use(async (context, next) =>
    {
        Debug.WriteLine("Middleware araya girdi.");

        await next.Invoke();

        Debug.WriteLine("Sonraki üyeler çalıştırıldı ve response veriliyor.");
    });


        /burak adresine request atarsak "/burak adresi ile gelindi." şeklinde bir response alacağız.Aksi tüm durumlar için ise "Response veriliyor." almaya devam ediyor olacağız.

    app.Map("/burak", internalApp =>
    {
        internalApp.Run(async context =>
        {
            await context.Response.WriteAsync("/burak adresi ile gelindi.");
        });
    });

     HTTP GET request'te bulunulduğu zaman "HTTP GET request'te bulunuldu." şeklinde bir response alacağız. Aksi tüm durum ise yine "Response veriliyor." şeklinde bir response almaya devam ediyor olacağız.


    app.MapWhen(x => x.Request.Method == "GET", internalApp =>
    {
        internalApp.Run(async context =>
        {
            await context.Response.WriteAsync("HTTP GET request'te bulunuldu.");
        });
    });


    app.Run(async context =>
    {
        Debug.WriteLine("Short-circuit yapıldı.");

        await context.Response.WriteAsync("Response veriliyor.");
    });

    */
}