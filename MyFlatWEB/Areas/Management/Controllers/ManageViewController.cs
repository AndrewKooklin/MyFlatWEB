using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFlatWEB.Data;
using MyFlatWEB.Models;
using MyFlatWEB.Models.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageView/")]
    public class ManageViewController : Controller
    {
        private DataManager _dataManager;
        private IEnumerable<string> _statusNames;

        public ManageViewController(DataManager dataManager)
        {
            _dataManager = dataManager;
            
        }

        [Route("ManageHome")]
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

        [Route("AllOrders")]
        public IActionResult AllOrders()
        {
            StatusesModel statusesModel = new StatusesModel();
            _statusNames = _dataManager.Rendering.GetStatusNames().AsEnumerable();
            StatusesModel.StatusNames = _statusNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            var model = _dataManager.Rendering.GetAllOrders();

            return View(model);
        }
    }
}
