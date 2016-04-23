using System.Collections.Generic;
using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void Add(Order order);
        void Edit(Order order);
        Order FindById(int orderId);
        void Delete(int orderId);
    }
}
