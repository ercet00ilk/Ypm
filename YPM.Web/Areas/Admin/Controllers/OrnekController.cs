using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YPM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class OrnekController 
        : AdminOrtakController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}