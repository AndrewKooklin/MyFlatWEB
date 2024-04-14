using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Areas.Management.Models.Rendering
{
    public class ServiceOrdersCountModel
    {
        public string ServiceName { get; set; }

        public int OrdersCount { get; set; }
    }
}
