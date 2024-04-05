using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    public class ManageViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
