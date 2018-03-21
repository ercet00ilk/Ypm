using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;

namespace YPM.Birim.Genel.Birim.Kurulum
{
    public interface IKurulumBirim
        : IGenericBirim<KurulumGercek>
    {
        Task AtesleProsedurOlustur();
    }
}