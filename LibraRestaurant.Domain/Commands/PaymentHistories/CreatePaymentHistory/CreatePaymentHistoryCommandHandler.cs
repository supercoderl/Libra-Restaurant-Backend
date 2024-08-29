
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Shared.Events.Menu;
using LibraRestaurant.Shared.Events.PaymentHistory;

namespace LibraRestaurant.Domain.Commands.PaymentHistories.CreatePaymentHistory
{
    public sealed class CreatePaymentHistoryCommandHandler : CommandHandlerBase,
        IRequestHandler<CreatePaymentHistoryCommand>
    {
        private readonly IPaymentHistoryRepository _paymentHistoryRepository;

        public CreatePaymentHistoryCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IPaymentHistoryRepository paymentHistoryRepository) : base(bus, unitOfWork, notifications)
        {
            _paymentHistoryRepository = paymentHistoryRepository;
        }

        public async Task Handle(CreatePaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            if (!await TestValidityAsync(request))
            {
                return;
            }

            var paymentHistory = new Entities.PaymentHistory(
                request.PaymentHistoryId,
                request.TransactionId,
                request.OrderId,
                request.PaymentMethodId,
                request.Amount,
                request.CurrencyId,
                request.ResponseJSON,
                request.CallbackURL,
                request.CreatedAt,
                request.Status);

            _paymentHistoryRepository.Add(paymentHistory);

            if (await CommitAsync())
            {
                await Bus.RaiseEventAsync(new PaymentHistoryCreatedEvent(paymentHistory.PaymentHistoryId));
            }
        }
    }
}
