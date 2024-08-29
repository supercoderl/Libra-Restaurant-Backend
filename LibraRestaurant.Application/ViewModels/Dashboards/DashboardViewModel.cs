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
    }
}
