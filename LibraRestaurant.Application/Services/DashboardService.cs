using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Orders.CountOrder;
using LibraRestaurant.Application.Queries.PaymentHistories.GetPaymentAmount;
using LibraRestaurant.Application.ViewModels.Dashboards;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IMediatorHandler _bus;

        public DashboardService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<DashboardViewModel?> Analytic()
        {
            int orderCount = await _bus.QueryAsync(new CountOrderQuery());
            double paymentAmount = await _bus.QueryAsync(new GetPaymentAmountQuery());
            DashboardViewModel result = new DashboardViewModel
            {
                OrderCount = orderCount,
                PaymentAmount = paymentAmount,
            };

            return result;
        }
    }
}
