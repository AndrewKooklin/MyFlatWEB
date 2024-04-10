using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Models;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageView")]
    public class ManageViewController : Controller
    {
        public IActionResult ManageHome()
        {
            if (UserRoles.Roles.Contains("Admin"))
            {
                return View("ManageHome");
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    }
}
