using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.ViewModels.Payments
{
    public class PaypalConfig
    {
        public string BaseURL { get; set; }
        public string ClientID { get; set; }
        public string Secret { get; set; }

        public PaypalConfig(string baseURL, string clientID, string secret)
        {
            BaseURL = baseURL;
            ClientID = clientID;
            Secret = secret;
        }
    }
}
