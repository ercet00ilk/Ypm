using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Genel.Helper
{

    public static class CookieExtensions
    {
        public static Dictionary<string, string> FromStringToDictionary(this string legacyCookie)
        {
            return legacyCookie.Split('&').Select(s => s.Split('=')).ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }

        public static string FromDictionaryToString(this Dictionary<string, string> dict)
        {
            return string.Join("&", dict.Select(kvp => string.Join("=", kvp.Key, kvp.Value)));
        }
    }
}
