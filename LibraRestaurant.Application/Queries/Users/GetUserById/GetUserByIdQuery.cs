using System;
using LibraRestaurant.Application.ViewModels.Users;
using MediatR;

namespace LibraRestaurant.Application.Queries.Users.GetUserById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserViewModel?>;