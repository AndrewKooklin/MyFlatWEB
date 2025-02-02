﻿using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Models.Rendering;
using System.Collections.Generic;
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

        List<OrderModel> GetOrdersByService(string serviceName);

        Task<List<OrderModel>> GetOrdersByPeriod(PeriodModel model);

        Task<bool> ChangeStatusOrder(ChangeStatusModel changeStatusModel);
    }
}
