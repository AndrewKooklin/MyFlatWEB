using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Areas.Management.Models.Rendering
{
    public class OrdersByServiceModel
    {
        public List<ServiceOrdersCountModel> ServiceOrders { get; set; }

        public int OrdersCount { get; set; }
    }
}
