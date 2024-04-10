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
