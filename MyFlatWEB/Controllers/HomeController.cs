using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyFlatWEB.Data;
using MyFlatWEB.Models;

namespace MyFlatWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager _dataManager;
        IEnumerable<string> _categoryServiceNames;
        OrderModel _orderModel;

        public HomeController(ILogger<HomeController> logger,
                              DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _categoryServiceNames = _dataManager.Rendering.GetCategoryServiceNames().AsEnumerable();
        }

        public IActionResult Index()
        {
            _orderModel = new OrderModel
            {
                CategoryServiceNames = _categoryServiceNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
            return View(_orderModel);
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult ProjectDetails()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Blogs()
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
