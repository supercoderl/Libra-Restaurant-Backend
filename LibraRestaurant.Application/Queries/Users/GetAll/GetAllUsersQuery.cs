using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels.Users;
using MediatR;

namespace LibraRestaurant.Application.Queries.Users.GetAll;

public sealed record GetAllUsersQuery(
    PageQuery Query,
    bool IncludeDeleted,
    string SearchTerm = "",
    SortQuery? SortQuery = null) :
    IRequest<PagedResult<UserViewModel>>;