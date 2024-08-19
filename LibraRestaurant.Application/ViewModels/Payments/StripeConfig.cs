using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.ViewModels.Payments
{
    public class StripeConfig
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string SuccessURL { get; set; }
        public string CancelURL { get; set; }

        public StripeConfig(string apiKey, string successURL, string cancelURL, string secretKey)
        {
            ApiKey = apiKey;
            SuccessURL = successURL;
            CancelURL = cancelURL;
            SecretKey = secretKey;

        }
    }
}
