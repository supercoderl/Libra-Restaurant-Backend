using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.ViewModels.Payments
{
    public class SessionStripe
    {
        public long Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string Mode { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
    }
}
