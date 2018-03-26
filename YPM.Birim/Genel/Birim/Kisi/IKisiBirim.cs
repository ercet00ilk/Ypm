using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Enum.Ortak;

namespace YPM.Birim.Genel.Birim.Kisi
{
    public interface IKisiBirim
           : IGenericBirim<KisiGercek>
    {
        Task<VarYokDurum> EPostaKontrolAsync(string email);
    }
}