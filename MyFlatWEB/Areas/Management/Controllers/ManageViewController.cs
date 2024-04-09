using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageView")]
    public class ManageViewController : Controller
    {
        public IActionResult ManageHome()
        {
            return View("ManageHome");
        }
    }
}
