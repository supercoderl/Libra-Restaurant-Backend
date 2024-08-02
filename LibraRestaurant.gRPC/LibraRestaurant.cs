using LibraRestaurant.gRPC.Interfaces;

namespace LibraRestaurant.gRPC;

public sealed class LibraRestaurant : ILibraRestaurant
{
    public LibraRestaurant(
        IUsersContext users, IMenuItemsContext items, IMenusContext menus)
    {
        Users = users;
        Items = items;
        Menus = menus;
    }

    public IUsersContext Users { get; }

    public IMenuItemsContext Items {  get; }

    public IMenusContext Menus { get; }
}