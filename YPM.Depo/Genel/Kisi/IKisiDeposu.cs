using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Model.Kisi;

namespace YPM.Depo.Genel.Kisi
{
    public interface IKisiDeposu
    {
        Task Ekle(KisiKayitModel kkm);
    }
}
