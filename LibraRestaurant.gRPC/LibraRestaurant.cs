using LibraRestaurant.gRPC.Interfaces;

namespace LibraRestaurant.gRPC;

public sealed class LibraRestaurant : ILibraRestaurant
{
    public LibraRestaurant(
        IUsersContext users, IMenuItemsContext items, IMenusContext menus, ICategoriesContext categories, ICurrenciesContext currencies, IOrdersContext orders)
    {
        Users = users;
        Items = items;
        Menus = menus;
        Currencies = currencies;
        Categories = categories;
        Orders = orders;
    }

    public IUsersContext Users { get; }

    public IMenuItemsContext Items {  get; }

    public IMenusContext Menus { get; }

    public ICategoriesContext Categories { get; }

    public ICurrenciesContext Currencies { get; }

    public IOrdersContext Orders { get; }
}