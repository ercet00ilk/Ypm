using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Depo.Veri.Kisi
{
    public interface IKisiDepo
       : IDisposable
    {
        Task<BasariliBasarisizDurum> Ekle(KisiKayitModel kkm);

        Task<VarYokDurum> EPostaKontrolAsync(string email);

        DateTime TarihGetir();
    }
}
