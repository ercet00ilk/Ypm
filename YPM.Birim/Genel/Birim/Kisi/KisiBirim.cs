using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
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

        public async Task<VarYok> EPostaKontrolAsync(string email)
        {
            bool islemOnay = new bool();

            VarYok donenDeger = new VarYok();

            using (var transaction = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            using (IGorevli gorev = Gorevli.YeniGorev())
            {
                try
                {
                    var mail = await gorev.Kisi.BulAsync(x => x.EPosta == email);

                    if (mail == null) donenDeger = VarYok.Yok;
                    else donenDeger = VarYok.Var;

                    gorev.Tamamla();

                    islemOnay = true;
                }
                catch (Exception)
                {
                    islemOnay = false;
                }
                finally
                {
                    if (islemOnay) transaction.Complete();
                    else transaction.Dispose();
                }
            }

            return donenDeger;
        }
    }
}