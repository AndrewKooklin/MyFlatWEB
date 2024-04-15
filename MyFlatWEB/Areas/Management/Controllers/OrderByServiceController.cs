﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/OrderByService")]
    public class OrderByServiceController : Controller
    {
        public IActionResult OrdersCountByService()
        {
            return View();
        }

        public IActionResult OrdersServiceDetails()
        {
            return View();
        }
    }
}
