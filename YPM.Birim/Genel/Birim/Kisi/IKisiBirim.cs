using GercekVarlik.Mulk.Varlik.Kisi.Ortak;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.SuretVarlik.Mulk.Enum.Ortak;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Birim.Genel.Birim.Kisi
{
    public interface IKisiBirim
           : IGenericBirim<KisiGercek>
    {
        Task<VarYok> EPostaKontrolAsync(string email);
    }
}
