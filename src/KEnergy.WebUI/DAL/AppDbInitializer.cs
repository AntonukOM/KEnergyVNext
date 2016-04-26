using System;
using System.Linq;
using KEnergy.WebUI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace KEnergy.WebUI.DAL
{
    public static class AppDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Managers.Any())
            {
                for (int i = 1; i < 8; ++i)
                {
                    context.Managers.Add(new Manager()
                    {
                        //ManagerId = i,
                        Name = $"Manager#{i}",
                        Surname = $"Surname{i}"
                    });
                }
                context.SaveChanges();
            }


            if (!context.Orders.Any())
            {
                for (int i = 1; i < 6; ++i)
                {
                    context.Orders.Add(new Order()
                    {
                        //OrderId = i,
                        Number = (i * new Random().Next()).ToString(),
                        CreationDate = DateTime.Now,
                        ShipmentDate = null,
                        Note = $"Some note {i}",
                        ManagerId = i
                    });
                }
                context.SaveChanges();
            }
        }
    }
}