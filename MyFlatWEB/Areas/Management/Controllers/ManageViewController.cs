using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Data;
using MyFlatWEB.Models;
using MyFlatWEB.Models.Rendering;
using System;
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
        private OrdersModel _ordersModel;

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
            OrdersModel ordersModel = new OrdersModel();
            InputDataModel inputDataModel = new InputDataModel();
            _statusNames = _dataManager.Rendering.GetStatusNames().AsEnumerable();
            ordersModel.StatusNames = _statusNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            ordersModel.OrderModels = _dataManager.Rendering.GetAllOrders();
            ordersModel.Title = "All Orders";

            return View(ordersModel);
        }

        [HttpGet]
        [Route("OrdersByService/{serviceName?}")]
        public IActionResult OrdersByService(string serviceName)
        {
            _ordersModel = new OrdersModel();
            _statusNames = _dataManager.Rendering.GetStatusNames().AsEnumerable();
            _ordersModel.StatusNames = _statusNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            _ordersModel.OrderModels = _dataManager.Rendering.GetOrdersByService(serviceName);
            _ordersModel.Title = $"{serviceName}";

            return View(_ordersModel);
        }

        [HttpGet]
        [HttpPost]
        [Route("OrdersByPeriod/{datefrom?}/{dateto?}")]
        public IActionResult OrdersByPeriod(string datefrom, string dateto)
        {
            if(String.IsNullOrEmpty(datefrom) || String.IsNullOrEmpty(dateto))
            {
                ModelState.AddModelError(string.Empty, "Fill dates.");
                return RedirectToAction("AllOrders", "ManageView");

            }
            else
            {
                return Json(true);
            }


            //return RedirectToAction("AllOrders", "ManageView");
        }

        [HttpGet]
        [HttpPut]
        [HttpPost]
        [HttpDelete]
        [Route("ChangeStatus/{id?}/{status?}/{service?}")]
        public IActionResult ChangeStatus(string id, string status, string service)
        {
            ChangeStatusModel changeStatus = new ChangeStatusModel();

            changeStatus.Id = Int32.Parse(id);
            changeStatus.Status = status;

            bool success = _dataManager.Rendering.ChangeStatusOrder(changeStatus).GetAwaiter().GetResult();

            if (success)
            {
                if (service.Equals("All Orders"))
                {
                    return RedirectToAction("AllOrders", "ManageView");
                }
                else
                {
                    return RedirectToAction("OrdersByService", new { serviceName = service });
                }
            }
            else
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "Server error";

                return View("ErrorView", errorModel);
            }
        }
    }
}
