using System;
using System.Threading.Tasks;
using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Users.GetAll;
using LibraRestaurant.Application.Queries.Users.GetUserById;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels.Users;
using LibraRestaurant.Domain.Commands.Users.ChangePassword;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Commands.Users.DeleteUser;
using LibraRestaurant.Domain.Commands.Users.LoginUser;
using LibraRestaurant.Domain.Commands.Users.UpdateUser;
using LibraRestaurant.Domain.Interfaces;

namespace LibraRestaurant.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IMediatorHandler _bus;
    private readonly IUser _user;

    public UserService(IMediatorHandler bus, IUser user)
    {
        _bus = bus;
        _user = user;
    }

    public async Task<UserViewModel?> GetUserByUserIdAsync(Guid userId)
    {
        return await _bus.QueryAsync(new GetUserByIdQuery(userId));
    }

    public async Task<UserViewModel?> GetCurrentUserAsync()
    {
        return await _bus.QueryAsync(new GetUserByIdQuery(_user.GetUserId()));
    }

    public async Task<PagedResult<UserViewModel>> GetAllUsersAsync(
        PageQuery query,
        bool includeDeleted,
        string searchTerm = "",
        SortQuery? sortQuery = null)
    {
        return await _bus.QueryAsync(new GetAllUsersQuery(query, includeDeleted, searchTerm, sortQuery));
    }

    public async Task<Guid> CreateUserAsync(CreateUserViewModel user)
    {
        var userId = Guid.NewGuid();

        await _bus.SendCommandAsync(new CreateUserCommand(
            userId,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Password));

        return userId;
    }

    public async Task UpdateUserAsync(UpdateUserViewModel user)
    {
        await _bus.SendCommandAsync(new UpdateUserCommand(
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Role));
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        await _bus.SendCommandAsync(new DeleteUserCommand(userId));
    }

    public async Task ChangePasswordAsync(ChangePasswordViewModel viewModel)
    {
        await _bus.SendCommandAsync(new ChangePasswordCommand(viewModel.Password, viewModel.NewPassword));
    }

    public async Task<string> LoginUserAsync(LoginUserViewModel viewModel)
    {
        return await _bus.QueryAsync(new LoginUserCommand(viewModel.Email, viewModel.Password));
    }
}