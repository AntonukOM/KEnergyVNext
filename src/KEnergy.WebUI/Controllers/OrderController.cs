using KEnergy.WebUI.Models;
using Microsoft.AspNet.Mvc;

namespace KEnergy.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IApplicationDbContext _context;

        public OrderController(IApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Orders = _context.Orders;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
