using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.ViewModels.Payments
{
    public class OrderInfo
    {
        public long OrderId { get; set; }
        public long Amount { get; set; }
        public string OrderDesc { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = string.Empty;

        public long PaymentTranId { get; set; }
        public string BankCode { get; set; } = string.Empty;
        public string PayStatus { get; set; } = string.Empty;
    }

    public class CreateVNPayViewModel
    {
        public bool IsQR { get; set; }
        public bool IsVNBank { get; set; }
        public bool IsIntCard { get; set; }
        public string? Locate { get; set; } = "vn";
        public double Amount {  get; set; }
        public Guid OrderID { get; set; }
        public string Status { get; set; } = "0";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
