﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFlatWEB.Models.Rendering
{
    public class OrdersModel
    {
        public string Title { get; set; }

        public string StatusName { get; set; }

        public List<OrderModel> OrderModels { get; set; }

        public IEnumerable<SelectListItem> StatusNames { get; set; }

        public string DateFrom { get; set; } = "";

        public string DateTo { get; set; } = "";

        public int TotalCountOrders { get; set; }

        public int CountOrdersByParameter { get; set; }
    }
}
