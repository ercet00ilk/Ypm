using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YPM.Web.Models.Istisna
{
    public class IstisnaViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
