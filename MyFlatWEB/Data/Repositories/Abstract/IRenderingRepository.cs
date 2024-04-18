using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Models.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Data.Repositories.Abstract
{
    public interface IRenderingRepository
    {
        List<string> GetServiceNames();

        List<string> GetStatusNames();

        List<ServiceOrdersCountModel> GetServiceOrdersCount();

        Task<bool> SaveOrder(OrderModel order);

        List<OrderModel> GetAllOrders();

        Task<bool> ChangeStatusOrder(ChangeStatusModel changeStatusModel);
    }
}
