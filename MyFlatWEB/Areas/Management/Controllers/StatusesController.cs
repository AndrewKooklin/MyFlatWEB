using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/Statuses")]
    public class StatusesController : Controller
    {
        private DataManager _dataManager;

        public StatusesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost]
        public IActionResult ChangeStatus(string id, string status)
        {
            ChangeStatusModel changeStatus = new ChangeStatusModel();

            changeStatus.Id = Int32.Parse(id);
            changeStatus.Status = status;

            bool success = _dataManager.Rendering.ChangeStatusOrder(changeStatus).GetAwaiter().GetResult();

            if (success)
            {
                return RedirectToAction("AllOrders", "ManageView");
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
