using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Suret.Session;

namespace YPM.Web.Genel.Wrapper.Session
{
    public interface ISessionSar
    {
        SessionIslemSuret SuAnki { get; set; }
    }
}
