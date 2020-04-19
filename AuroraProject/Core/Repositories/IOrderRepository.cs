using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderId);
        ICollection<Order> GetOrders(string userId);
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        IEnumerable<Order> GetOrdersInShoppingCart(string userId);

    }
}