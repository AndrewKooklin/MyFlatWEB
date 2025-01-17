using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;

namespace MyFlatWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager _dataManager;
        OrderModel _orderModel = new OrderModel();
        private IEnumerable<string> _serviceNames;

        public HomeController(ILogger<HomeController> logger,
                              DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceNames = _dataManager.Rendering.GetServiceNames().AsEnumerable();
            ServicesModel.ServiceNames = _serviceNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
        }

        public IActionResult Home()
        {
            ViewBag.PlaceHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
            ViewBag.Contacts = _dataManager.PageEditor.GetContactsFromDB();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderModel order)
        {
            if (ModelState.IsValid)
            {
                var result = await _dataManager.Rendering.SaveOrder(order);
                if (result)
                {
                    ModelState.AddModelError(string.Empty, "Order added successfully.");
                    return RedirectToAction("Home");
                }
                else
                {
                    ServicesModel.ServiceNames = _serviceNames.Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });
                    ModelState.AddModelError(string.Empty, "Server error.");
                    return View("Home", _orderModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid order model.");
                _orderModel = order;
                ServicesModel.ServiceNames = _serviceNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                return View("Home", _orderModel);
            }
        }

        public IActionResult Projects()
        {
            var projects = _dataManager.PageEditor.GetProjectsFromDB();
            return View(projects);
        }

        public IActionResult ProjectDetails(int id)
        {
            var project = _dataManager.PageEditor.GetProjectById(id);
            return View(project);
        }

        public IActionResult Services()
        {
            var services = _dataManager.PageEditor.GetServicesFromDB();
            return View(services);
        }

        public IActionResult Blog()
        {
            var posts = _dataManager.PageEditor.GetPostsFromDB();
            return View(posts);
        }

        public IActionResult BlogDetails(int id)
        {
            var post = _dataManager.PageEditor.GetPostById(id);
            return View(post);
        }

        public IActionResult Contacts()
        {
            var contacts = _dataManager.PageEditor.GetContactsFromDB();
            ViewBag.Social = _dataManager.PageEditor.GetSocialLinksFromDB();
            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
