using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/Statuses")]
    public class StatusesController : Controller
    {


        [HttpPost]
        public IActionResult ChangeStatus()
        {
            return View();
        }
    }
}
