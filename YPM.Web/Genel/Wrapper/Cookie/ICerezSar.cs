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

        void TumunuTemizle();
    }

    /* Kullanımı

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

     */
}