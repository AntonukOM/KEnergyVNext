using System;
using System.Linq;
using System.Threading.Tasks;
using KEnergy.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace KEnergy.WebUI.DAL
{
    public class DataInitializer
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task InitializeDataAsync()
        {
            await CreateUsersAsync();
            CreateOrders();
            CreateManagers();
        }

        private void CreateOrders()
        {
            if (!_context.Orders.Any())
            {
                for (int i = 1; i < 6; ++i)
                {
                    _context.Orders.Add(new Order()
                    {
                        OrderId = i,
                        Number = "1111111",
                        CreationDate = DateTime.Now,
                        ShipmentDate = new DateTime(2017, 11, 11),
                        Note = $"Some note {i}",
                        ManagerId = i
                    });
                }
                _context.SaveChanges();
            }
        }

        private void CreateManagers()
        {
            if (!_context.Managers.Any())
            {
                for (int i = 1; i < 8; ++i)
                {
                    _context.Managers.Add(new Manager()
                    {
                        ManagerId = i,
                        Name = $"Manager#{i}",
                        Surname = $"Surname{i}"
                    });
                }
                _context.SaveChanges();
            }
        }

        private async Task CreateUsersAsync()
        {
            var user = await _userManager.FindByEmailAsync("test@mail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "test@mail.com",
                    Email = "test@mail.com",
                    Surname = "Ivanenko",
                    Name = "Ivan",
                    Lastname = "Ivanovich",
                    Phone = "098 658-96-52",
                    Birthday = new DateTime(1969, 2, 20)
                };
                await _userManager.CreateAsync(user, "Test_1");
            }
        }
    }
}