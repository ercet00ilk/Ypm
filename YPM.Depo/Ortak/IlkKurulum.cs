using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YPM.Depo.Veri.Kurulum;

namespace YPM.Depo.Ortak
{
    public sealed class IlkKurulum
    {


        public static async Task Kur()
        {

            using (var transaction = new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (IKurulumDeposu kur = new KurulumDeposu())
                    {
                        if (await kur.KuruluMu()) kur.KurulumYap().Wait();

                        transaction.Complete();
                    }
                }
                catch (Exception)
                {
                    transaction.Dispose();
                }
            }


        }



    }
}
