using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageView/")]
    public class ManageViewController : Controller
    {
        private DataManager _dataManager;
        int _totalCountOrders;
        List<OrderModel> _allOrders = new List<OrderModel>();
        List<string> _statusNamesList = new List<string>();

        public ManageViewController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _allOrders = _dataManager.Rendering.GetAllOrders();
            _totalCountOrders = _allOrders.Count;
            _statusNamesList = _dataManager.Rendering.GetStatusNames();
        }

        [Route("ManageHome")]
        public IActionResult ManageHome()
        {
            OrdersByServiceModel model = new OrdersByServiceModel();
            model.ServiceOrders = _dataManager.Rendering.GetServiceOrdersCount();
            model.OrdersCount = _totalCountOrders;

            return View("ManageHome", model);
        }

        [Route("AllOrders")]
        public IActionResult AllOrders()
        {
            OrdersModel ordersModel = new OrdersModel();
            InputDataModel inputDataModel = new InputDataModel();
            ordersModel.StatusNames = _statusNamesList.AsEnumerable().Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            ordersModel.OrderModels = _allOrders;
            ordersModel.TotalCountOrders = _totalCountOrders;
            ordersModel.Title = "All Orders";

            return View(ordersModel);
        }

        [HttpGet]
        [Route("OrdersByService/{serviceName?}")]
        public IActionResult OrdersByService(string serviceName)
        {
            OrdersModel ordersModel = new OrdersModel();
            ordersModel.StatusNames = _statusNamesList.AsEnumerable().Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            ordersModel.OrderModels = _dataManager.Rendering.GetOrdersByService(serviceName);
            ordersModel.CountOrdersByParameter = ordersModel.OrderModels.Count;
            ordersModel.TotalCountOrders = _totalCountOrders;
            ordersModel.Title = $"Service \"{serviceName}\" : {ordersModel.CountOrdersByParameter} order(s)";

            return View(ordersModel);
        }

        [HttpGet]
        [HttpPost]
        [Route("OrdersByPeriod/{datefrom?}/{dateto?}")]
        public IActionResult OrdersByPeriod(string datefrom, string dateto, string periodname)
        {
            OrdersModel ordersModel = new OrdersModel();

            if (String.IsNullOrEmpty(datefrom) || String.IsNullOrEmpty(dateto))
            {
                ordersModel.StatusNames = _statusNamesList.AsEnumerable().Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ordersModel.OrderModels = _allOrders;
                ordersModel.TotalCountOrders = _totalCountOrders;
                ordersModel.Title = $"All Orders";

                return View("AllOrders", ordersModel);
            }
            else if (!String.IsNullOrEmpty(datefrom) || !String.IsNullOrEmpty(dateto))
            {
                DateTime startDate = Convert.ToDateTime(datefrom, new CultureInfo("ru-RU"));

                DateTime endDate = Convert.ToDateTime(dateto, new CultureInfo("ru-RU"));

                PeriodModel periodModel = new PeriodModel();

                if (!startDate.Equals(DateTime.MinValue) || !endDate.Equals(DateTime.MinValue))
                {
                    periodModel.DateFrom = startDate;
                    periodModel.DateTo = endDate;
                }
                else
                {
                    return View("AllOrders", ordersModel);
                }

                ordersModel = new OrdersModel();
                ordersModel.StatusNames = _statusNamesList.AsEnumerable().Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ordersModel.OrderModels = _dataManager.Rendering.GetOrdersByPeriod(periodModel).GetAwaiter().GetResult();
                if (ordersModel.OrderModels == null || ordersModel.OrderModels.Count == 0)
                {
                    ordersModel.Title = $"No orders per {periodname}";
                    ordersModel.TotalCountOrders = _totalCountOrders;
                    return View("AllOrders", ordersModel);
                }
                ordersModel.TotalCountOrders = _totalCountOrders;
                ordersModel.CountOrdersByParameter = ordersModel.OrderModels.Count;
                ordersModel.Title = $"Orders per {periodname} : {ordersModel.CountOrdersByParameter} order(s)";

                return View("AllOrders", ordersModel);
            }

            return RedirectToAction("AllOrders", "ManageView");
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
