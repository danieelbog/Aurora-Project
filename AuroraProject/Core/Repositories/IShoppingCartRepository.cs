using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCart(string userId);
    }
}