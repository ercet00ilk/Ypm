using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Genel.Yapi.Istisna
{
    public class NullReferansIstisna
        : OrtakIstisna
    {
        private readonly string _aciklama;

        public NullReferansIstisna(string aciklama)
        {
            _aciklama = aciklama;
        }
    }
}
