using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Menus.GetAll;
using LibraRestaurant.Application.Queries.Menus.GetMenuById;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Commands.Menus.CreateMenu;
using LibraRestaurant.Domain.Commands.Menus.DeleteMenu;
using LibraRestaurant.Domain.Commands.Menus.UpdateMenu;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraRestaurant.Application.ViewModels.Messages;
using LibraRestaurant.Domain.Commands.Messages.SendMessage;
using LibraRestaurant.Application.Queries.Messages.GetAll;
using LibraRestaurant.Application.ViewModels.OrderLines;
using LibraRestaurant.Domain.Commands.OrderLines.UpdateOrderLine;
using LibraRestaurant.Domain.Commands.Messages.UpdateMessage;

namespace LibraRestaurant.Application.Services
{
    public sealed class MessageService : IMessageService
    {
        private readonly IMediatorHandler _bus;

        public MessageService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<PagedResult<MessageViewModel>> GetAllMessagesAsync(
            PageQuery query,
            bool includeDeleted,
            string searchTerm = "",
            string? type = null,
            SortQuery? sortQuery = null)
        {
            return await _bus.QueryAsync(new GetAllMessagesQuery(query, includeDeleted, searchTerm, type, sortQuery));
        }

        public async Task<int> SendMessageAsync(SendMessageViewModel message)
        {
            await _bus.SendCommandAsync(new SendMessageCommand(
                0,
                message.SenderId,
                message.ReceiverId,
                message.Content,
                DateTime.Now,
                false,
                message.ConversationId,
                message.MessageType,
                message.AttachmentUrl));

            return 0;
        }

        public async Task UpdateMessageAsync(UpdateMessageViewModel message)
        {
            await _bus.SendCommandAsync(new UpdateMessageCommand(
            message.MessageId,
            message.SenderId,
            message.ReceiverId,
            message.Content,
            message.Time,
            message.IsRead,
            message.ConversationId,
            message.MessageType,
            message.AttachmentUrl));
        }
    }
}
