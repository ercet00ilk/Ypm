using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using YPM.Depo.Veri.Kisi;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
using YPM.SuretVarlik.Mulk.Model.Istisna;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Web.Controllers
{
    [Route("uye")]
    public class UyeController
        : OrtakController
    {
        private bool Disposed { get; set; }
        private readonly IKisiDeposu _kisi;

        public UyeController(IKisiDeposu kisi)
        {
            _kisi = kisi;
        }

        [Route("yenikayit")]
        public IActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YeniKayit(KisiKayitModel kkm)
        {
            if (ModelState.IsValid)
            {
                kkm = await OyleBirKisiVarMi(kkm);

                if (ModelState.IsValid)
                {
                    kkm = BosAlanlariDoldur(kkm);

                    if (ModelState.IsValid)
                    {
                        if (await KisiKaydet(kkm))
                        {
                            ViewBag.Sonuc = "Başarılı bir şekilde kayıt oldunuz. Telefonunuza gelen doğrulama kodu ile üye girişi yapabilirsiniz.";
                        }
                        else
                        {
                            ViewBag.Sonuc = "Sistem servis dışı.. Lütfen daha sonra tekrar deneyiniz. ";
                        }

                        return View("MesajVer");
                    }
                }
            }

            return View(kkm);
        }

        [Route("guvenligiris")]
        public IActionResult GuvenliGiris()
        {
            return Content("qwe");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuvenliGiris(KisiGirisModel kgm)
        {
            if (ModelState.IsValid)
            {
            }

            return View(kgm);
        }

        public IActionResult Istisna()
        {
            return View(new IstisnaViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        protected override void Dispose(bool disposing)
        {
            if (Disposed) return;

            if (disposing && _kisi != null) _kisi.Dispose();

            base.Dispose(disposing);
        }

        #region Private

        private async Task<bool> KisiKaydet(KisiKayitModel kkm)
        {
            bool donenDeger = new bool();

            switch (await _kisi.Ekle(kkm))
            {
                case BasariliBasarisiz.Basarisiz:
                    donenDeger = false;
                    break;

                case BasariliBasarisiz.Basarili:
                    donenDeger = true;
                    break;

                default:
                    throw new ApplicationException("Uye.KisiKaydet() switch default döndü.");
            }

            return donenDeger;
        }

        private KisiKayitModel BosAlanlariDoldur(KisiKayitModel kkm)
        {
            kkm.KayitTarihi = _kisi.TarihGetir();

            kkm.MacAdr = MacAdresiGetir();

            kkm.IpAdr = IpAdresiGetir();

            kkm.EpostaKontrol = RandomSekizKarakterGetir();

            kkm.EpostaOnayliMi = false;

            return kkm;
        }

        private string IpAdresiGetir()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        private string RandomSekizKarakterGetir()
        {
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper().ToString();
        }

        private string MacAdresiGetir()
        {
            string donusDegeri = string.Empty;

            donusDegeri = MacGetirBir();

            if (donusDegeri == string.Empty) donusDegeri = MacGetirIki();

            if (string.IsNullOrEmpty(donusDegeri)) donusDegeri = "bos";

            return donusDegeri;
        }

        private string MacGetirBir()
        {
            string sMacAddress = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)                          // Only Ethernet network interfaces
                {
                    sMacAddress = nic.GetPhysicalAddress().ToString();

                    if (sMacAddress != string.Empty) return sMacAddress;
                }
            }

            return sMacAddress;
        }

        private string MacGetirIki()
        {
            return Path.Combine((new HostingEnvironment()).ContentRootPath, "AppData");
        }

        private async Task<KisiKayitModel> OyleBirKisiVarMi(KisiKayitModel kkm)
        {
            if (await _kisi.EPostaKontrolAsync(kkm.email) == VarYok.Var ? true : false) ModelState.AddModelError("", "Bu EPosta adresi alınmış. Başka bir tane deneyin..");
            return kkm;
        }

        #endregion Private
    }
}