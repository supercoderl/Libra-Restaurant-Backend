using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels.Users;
using LibraRestaurant.Domain.Entities;

namespace LibraRestaurant.Application.SortProviders;

public sealed class UserViewModelSortProvider : ISortingExpressionProvider<UserViewModel, User>
{
    private static readonly Dictionary<string, Expression<Func<User, object>>> s_expressions = new()
    {
        { "email", user => user.Email },
        { "firstName", user => user.FirstName },
        { "lastName", user => user.LastName },
        { "lastloggedindate", user => user.LastLoggedinDate ?? DateTimeOffset.MinValue },
        { "role", user => user.Role },
        { "status", user => user.Status }
    };

    public Dictionary<string, Expression<Func<User, object>>> GetSortingExpressions()
    {
        return s_expressions;
    }
}