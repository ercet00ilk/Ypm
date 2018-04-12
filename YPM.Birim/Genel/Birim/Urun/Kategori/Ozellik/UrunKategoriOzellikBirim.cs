using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Reflection;
using YPM.Birim.Genel.Birim.Generic;
using YPM.GercekVarlik.Mulk.Varlik.Urun.Kategori;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Birim;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Urun.Kategori.Ozellik
{
    public class UrunKategoriOzellikBirim
     : GenericBirim<UrunKategoriOzellikGercek>, IUrunKategoriOzellikBirim
    {
        private readonly YpmSebil _sebil;

        public UrunKategoriOzellikBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }

        public bool IcerirMi(int kategoriId, int deger)
        {
            bool islemOnay = new bool();

            bool icerirMi = new bool();


            using (IGorevli gorev = Gorevli.YeniGorev())
            using (IDbContextTransaction islem = gorev.TransactionBaslat())
            {
                try
                {
                    int sonuc = new int();

                    sonuc = gorev.UrunKategoriOzellik.GetirTumKoleksiyon()
                        .Where(x => x.UrunKategoriId.Equals(kategoriId))
                        .Where(x => x.UrunOzellikId.Equals(deger))
                        .Count();

                    if (sonuc > 0) icerirMi = true;
                    else icerirMi = false;

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
                        istisna.Sonuc = " public bool IcerirMi(int kategoriId, int deger) ";
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

            return icerirMi;
        }
    }
}