using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Kurulum;

namespace YPM.Depo.Genel.Kurulum
{
    public class KurulumDeposu
        : IKurulumDeposu
    {
        private readonly IKurulumBirim _kurulum = KurulumBirim.OrnekVer();

        public Task<bool> KuruluMu()
        {
            throw new NotImplementedException();
        }

        public async Task KurulumYap()
        {
            await _kurulum.AtesleProsedurOlustur();
            return;
        }
    }
}
