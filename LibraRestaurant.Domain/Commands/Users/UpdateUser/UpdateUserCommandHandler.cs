using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Notifications;
using LibraRestaurant.Shared.Events.User;
using MediatR;

namespace LibraRestaurant.Domain.Commands.Users.UpdateUser;

public sealed class UpdateUserCommandHandler : CommandHandlerBase,
    IRequestHandler<UpdateUserCommand>
{
    private readonly IUser _user;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(
        IMediatorHandler bus,
        IUnitOfWork unitOfWork,
        INotificationHandler<DomainNotification> notifications,
        IUserRepository userRepository,
        IUser user) : base(bus, unitOfWork, notifications)
    {
        _userRepository = userRepository;
        _user = user;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await TestValidityAsync(request))
        {
            return;
        }

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    $"There is no user with Id {request.UserId}",
                    ErrorCodes.ObjectNotFound));
            return;
        }

        if (_user.GetUserId() != request.UserId && _user.GetUserRole() != UserRole.Admin)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    $"No permission to update user {request.UserId}",
                    ErrorCodes.InsufficientPermissions));

            return;
        }

        if (request.Email != user.Email)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser is not null)
            {
                await NotifyAsync(
                    new DomainNotification(
                        request.MessageType,
                        $"There is already a user with email {request.Email}",
                        DomainErrorCodes.User.AlreadyExists));
                return;
            }
        }

        if (_user.GetUserRole() == UserRole.Admin)
        {
            user.SetRole(request.Role);
        }

        user.SetEmail(request.Email);
        user.SetFirstName(request.FirstName);
        user.SetLastName(request.LastName);

        _userRepository.Update(user);

        if (await CommitAsync())
        {
            await Bus.RaiseEventAsync(new UserUpdatedEvent(user.Id));
        }
    }
}