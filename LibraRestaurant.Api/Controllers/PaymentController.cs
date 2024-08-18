using LibraRestaurant.Api.Models;
using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Services;
using LibraRestaurant.Application.ViewModels.Payments;
using LibraRestaurant.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace LibraRestaurant.Api.Controllers
{
    [ApiController]
    /*    [Authorize]*/
    [Route("/api/v1/[controller]")]
    public sealed class PaymentController : ApiController
    {
        private readonly IPaypalService _paypalService;
        private readonly IVnPayService _vnPayService;
        private readonly IStripeService _stripeService;

        public PaymentController(
            INotificationHandler<DomainNotification> notifications,
            IPaypalService paypalService,
            IVnPayService vnPayService,
            IStripeService stripeService) : base(notifications)
        {
            _paypalService = paypalService;
            _vnPayService = vnPayService;
            _stripeService = stripeService;
        }

        [HttpPost("/paypal/order")]
        [SwaggerOperation("Create order")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<CreateOrderResponse>))]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest viewModel)
        {
            return Ok(await _paypalService.CreateOrder(viewModel));
        }

        [HttpGet("/paypal/capture/{id}")]
        [SwaggerOperation("Get capture order")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<CaptureOrderResponse>))]
        public async Task<IActionResult> GetPlanDetails([FromRoute] string id)
        {
            return Response(await _paypalService.CaptureOrder(id));
        }

        [HttpGet("/paypal/transactions")]
        [SwaggerOperation("Get transactions")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<string>))]
        public async Task<IActionResult> GetTransactions()
        {
            return Ok(await _paypalService.GetTransactions());
        }

        [HttpPost("/vnpay")]
        [SwaggerOperation("Pay")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<string>))]
        public async Task<IActionResult> PayVnPay([FromBody] CreateVNPayViewModel viewModel)
        {
            return Ok(await _vnPayService.Pay(viewModel));
        }

        [HttpPost("/stripe")]
        [SwaggerOperation("Pay")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Session>))]
        public async Task<IActionResult> PayStripe(SessionStripe request)
        {
            return Ok(await _stripeService.CreateOrderStripe(request));
        }

        [HttpGet("/stripe/{id}")]
        [SwaggerOperation("Retrieve session")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Session>))]
        public async Task<IActionResult> RetrieveStripe([FromRoute] string id)
        {
            return Ok(await _stripeService.RetrieveSession(id));
        }
    }
}
