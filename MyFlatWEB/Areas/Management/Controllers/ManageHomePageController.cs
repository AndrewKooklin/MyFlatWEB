using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageHomePage/")]
    public class ManageHomePageController : Controller
    {



        [Route("HomePage")]
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
