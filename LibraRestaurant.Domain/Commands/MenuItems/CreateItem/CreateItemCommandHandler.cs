using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Notifications;
using LibraRestaurant.Shared.Events.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Shared.Events.MenuItem;

namespace LibraRestaurant.Domain.Commands.MenuItems.CreateItem
{
    public sealed class CreateItemCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateItemCommand>
    {
        private readonly IMenuItemRepository _itemRepository;

        public CreateItemCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IMenuItemRepository itemRepository) : base(bus, unitOfWork, notifications)
        {
            _itemRepository = itemRepository;
        }

        public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            if (!await TestValidityAsync(request))
            {
                return;
            }

            var item = new MenuItem(
                request.ItemId,
                request.Title,
                request.Slug,
                request.Summary,
                request.SKU,
                request.Price,
                request.Quantity,
                request.Recipe,
                request.Instruction,
                DateTime.Now,
                null);

            _itemRepository.Add(item);

            if (await CommitAsync())
            {
                await Bus.RaiseEventAsync(new ItemCreatedEvent(item.ItemId));
            }
        }
    }
}
