using LibraRestaurant.gRPC.Interfaces;

namespace LibraRestaurant.gRPC;

public interface ILibraRestaurant
{
    IUsersContext Users { get; }
    IMenuItemsContext Items { get; }
    IMenusContext Menus { get; }
    ICategoriesContext Categories { get; }
    ICurrenciesContext Currencies { get; }
    IOrdersContext Orders { get; }
}