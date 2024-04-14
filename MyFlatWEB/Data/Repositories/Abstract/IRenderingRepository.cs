using MyFlatWEB.Areas.Management.Models.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Data.Repositories.Abstract
{
    public interface IRenderingRepository
    {
        List<string> GetServiceNames();

        List<ServiceOrdersCountModel> GetServiceOrdersCount();
    }
}
