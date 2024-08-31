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
            // Lấy tháng và năm hiện tại
            var (currentMonth, currentYear) = GetMonthAndYear(DateTime.Now);

            // Lấy tháng và năm của tháng trước
            var (lastMonth, lastMonthYear) = GetMonthAndYear(DateTime.Now, true);

            int orderCount = await _bus.QueryAsync(new CountOrderQuery(null, null));
            double paymentAmount = await _bus.QueryAsync(new GetPaymentAmountQuery());
            int customerInThisMonth = await _bus.QueryAsync(new CountOrderQuery(currentMonth, currentYear));
            int customerInLastMonth = await _bus.QueryAsync(new CountOrderQuery(lastMonth, lastMonthYear));
            
            double percentageChange;

            if (customerInLastMonth == 0)
            {
                // Trường hợp đặc biệt: Tháng trước không có khách, chỉ hiển thị số lượng khách tháng này
                percentageChange = customerInThisMonth > 0 ? 100 : 0; // Nếu có khách trong tháng này, coi như tăng 100%
            }
            else
            {
                // Tính toán tỷ lệ phần trăm tăng/giảm
                percentageChange = ((double)(customerInThisMonth - customerInLastMonth) / customerInLastMonth) * 100;
            }



            DashboardViewModel result = new DashboardViewModel
            {
                OrderCount = orderCount,
                PaymentAmount = paymentAmount,
                Customer = new DashboardCustomer
                {
                    CustomerCountInThisMonth = customerInThisMonth,
                    CustomerCountInLastMonth = customerInLastMonth,
                    Percentage = percentageChange,
                }
            };

            return result;
        }

        public (int month, int year) GetMonthAndYear(DateTime dateTime, bool isPreviousMonth = false)
        {
            int month = dateTime.Month;
            int year = dateTime.Year;

            if (isPreviousMonth)
            {
                month--;
                if (month == 0)
                {
                    month = 12;
                    year--;
                }
            }

            return (month, year);
        }
    }
}
