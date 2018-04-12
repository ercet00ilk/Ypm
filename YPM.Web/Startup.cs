using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YPM.Depo.Veri.Gunluk;
using YPM.Depo.Veri.Kisi;
using YPM.Depo.Veri.Kurulum;
using YPM.Depo.Veri.Sistem;
using YPM.Depo.Veri.Urun.Kategori;
using YPM.Web.Genel.MiddleWare;
using YPM.Web.Genel.Wrapper.Cache;
using YPM.Web.Genel.Wrapper.Cookie;
using YPM.Web.Genel.Wrapper.Session;

namespace YPM.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            KurulumDepo.Kur().Wait();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection servisler)
        {
            servisler.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            servisler.AddSingleton<ISessionSar, SessionSar>();
            servisler.AddSingleton<ICerezSar, CerezSar>();
            servisler.AddSingleton<IOnBellekSar, OnBellekSar>();

            servisler.AddTransient<IGunlukDepo, GunlukDepo>();
            servisler.AddTransient<IKisiDepo, KisiDepo>();
            servisler.AddTransient<ISistemDepo, SistemDepo>();
            servisler.AddTransient<IUrunKategoriDepo, UrunKategoriDepo>();

            servisler.AddMvc()
                 .AddSessionStateTempDataProvider();

            servisler.AddMemoryCache();

            servisler.AddSession();

            servisler.AddDistributedMemoryCache();

            servisler.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            //app.UseIdentity();

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