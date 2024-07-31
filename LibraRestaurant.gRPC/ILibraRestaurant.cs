using LibraRestaurant.gRPC.Interfaces;

namespace LibraRestaurant.gRPC;

public interface ILibraRestaurant
{
    IUsersContext Users { get; }
}