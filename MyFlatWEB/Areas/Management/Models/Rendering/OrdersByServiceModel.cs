using System.Collections.Generic;

namespace MyFlatWEB.Areas.Management.Models.Rendering
{
    public class OrdersByServiceModel
    {
        public List<ServiceOrdersCountModel> ServiceOrders { get; set; }

        public int OrdersCount { get; set; }
    }
}
