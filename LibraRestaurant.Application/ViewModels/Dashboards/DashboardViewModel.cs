using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.ViewModels.Dashboards
{
    public sealed class DashboardViewModel
    {
        public int OrderCount { get; set; }
        public double PaymentAmount { get; set; }
        public DashboardCustomer Customer { get; set; } = new DashboardCustomer();
    }

    public sealed class DashboardCustomer
    {
        public int CustomerCountInThisMonth { get; set; }
        public int CustomerCountInLastMonth { get; set; }
        public double Percentage { get; set; }
    }
}
