using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Data;
using MyFlatWEB.Models;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageView")]
    public class ManageViewController : Controller
    {
        private DataManager _dataManager;

        public ManageViewController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult ManageHome()
        {
            //if (UserRoles.Roles.Contains("Admin"))
            //{

                var model = _dataManager.Rendering.GetServiceOrdersCount();

                return View("ManageHome", model);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}
        }

        public IActionResult AllOrders()
        {
            var model = _dataManager.Rendering.GetAllOrders();

            return View(model);
        }
    }
}
