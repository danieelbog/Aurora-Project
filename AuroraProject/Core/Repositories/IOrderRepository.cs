using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderId);
        ICollection<Order> GetOrders(int shoppingCartID);
        ICollection<Order> GetUnpayedOrders(int shoppingCartID);
        void AddOrder(Order order);
        void RemoveOrder(Order order);

    }
}