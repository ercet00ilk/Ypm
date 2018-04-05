using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YPM.SuretVarlik.Mulk.Model.Kisi;
using YPM.Web.Genel.Wrapper.Cookie;

namespace YPM.Web.Controllers
{
    public class OrtakController
        : Controller
    {
        protected void BeniHatirla(ICerezSar _cerezSar)
        {
            if (_cerezSar.VarMi("ypm_kontrol"))//=> Kontrol çerezi varsa
            {
                if (_cerezSar.VarMi("ypm_giris"))
                {
                    using (UyeController uc = new UyeController())
                    {
                        var cerez = new Dictionary<string, string>();
                        cerez = _cerezSar.Getir("ypm_giris");

                        var kgm = new KisiGirisModel();
                        kgm.email = (from c in cerez
                                     where c.Key == "email"
                                     select c.Value).FirstOrDefault();
                        kgm.password = (from c in cerez
                                        where c.Key == "password"
                                        select c.Value).FirstOrDefault();


                        uc.GuvenliGiris(kgm);


                        cerez = null;
                        kgm.Dispose();
                    }
                }
            }
            else _cerezSar
                    .Olustur( //=> Kontrol çerezi yoksa ekle
                "ypm_kontrol",
                new Dictionary<string, string>(){
                    { "test","test"},
                    { "expire","1 day" }},
                new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(1)
                });
        }

        protected bool UyeGirisYaptiMi()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}