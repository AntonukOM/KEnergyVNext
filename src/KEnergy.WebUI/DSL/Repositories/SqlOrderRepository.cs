using System;
using System.Collections.Generic;
using System.Linq;
using KEnergy.WebUI.DSL.Interfaces;
using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlOrderRepository : AbstractSqlRepository, IOrderRepository
    {
        public SqlOrderRepository(ApplicationDbContext context) : base(context) { }
        public IEnumerable<Order> Orders
        {
            get { return _context.Orders; }
        }

        public void Add(Order order)
        {
            order.CreationDate = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
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
            _context.SaveChanges();
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
                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
            }
        }


    }
}