using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Depo.Veri.Kisi
{
    public interface IKisiDeposu
        : IDisposable
    {
        Task<BasariliBasarisiz> Ekle(KisiKayitModel kkm);
        Task<VarYok> EPostaKontrolAsync(string email);
    }
}
