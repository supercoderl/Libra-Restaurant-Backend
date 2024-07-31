using LibraRestaurant.gRPC.Interfaces;

namespace LibraRestaurant.gRPC;

public sealed class LibraRestaurant : ILibraRestaurant
{
    public LibraRestaurant(
        IUsersContext users)
    {
        Users = users;
    }

    public IUsersContext Users { get; }
}