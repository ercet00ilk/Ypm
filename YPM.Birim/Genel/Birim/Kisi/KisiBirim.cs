using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Reflection;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Birim;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Kisi
{
    public class KisiBirim
           : GenericBirim<KisiGercek>, IKisiBirim
    {
        private readonly YpmSebil _sebil;

        public KisiBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }

        public static IKisiBirim YeniKisi()
        {
            return new KisiBirim(new YpmSebil());
        }

        public async Task<VarYokDurum> EPostaKontrolAsync(string email)
        {
            bool islemOnay = new bool();

            VarYokDurum donenDeger = new VarYokDurum();

            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    var mail = await gorev.Kisi.BulAsync(x => x.EPosta == email);

                    if (mail == null) donenDeger = VarYokDurum.Yok;
                    else donenDeger = VarYokDurum.Var;

                    gorev.Tamamla();

                    islemOnay = true;
                }
                catch (Exception ex)
                {
                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public virtual T Bul(Expression<Func<T, bool>> eslesen) ";
                        istisna.IslemOnay = islemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }

                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) islem.Commit();
                    else islem.Rollback();
                }
            }

            return donenDeger;
        }
    }
}