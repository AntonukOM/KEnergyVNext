using System;
using System.Collections.Generic;
using System.Linq;
using KEnergy.WebUI.DSL.Interfaces;
using KEnergy.WebUI.Models;
using Microsoft.Data.Entity.Infrastructure;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlOrderRepository : SqlAbstractRepository, IOrderRepository
    {
        public IEnumerable<Order> Orders
        {
            get { return Context.Orders; }
        }

        public void Add(Order order)
        {
            order.CreationDate = DateTime.Now;
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public void Edit(Order order)
        {
            Order edited = FindById(order.OrderId);
            if (edited != null)
            {
                edited.ManagerId = order.ManagerId;
                edited.Number = order.Number;
                edited.Note = order.Note;
                edited.ShipmentDate = order.ShipmentDate;
            }
            Context.SaveChanges();
        }

        public Order FindById(int orderId)
        {
            Order order = Orders
                .FirstOrDefault(x => x.OrderId == orderId);
            return order;
        }

        public void Delete(int orderId)
        {
            Order orderToDelete = FindById(orderId);
            if (orderToDelete != null)
            {
                Context.Orders.Remove(orderToDelete);
                Context.SaveChanges();
            }
        }
    }
}