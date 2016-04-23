using System.Collections.Generic;
using KEnergy.WebUI.Helpers.UI;
using KEnergy.WebUI.Models;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace KEnergy.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ManagerSelectList _managerSelectList;

        public OrderController(ApplicationDbContext context)
        {
            this._context = context;
            this._managerSelectList = new ManagerSelectList(_context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ManagerList = _managerSelectList.ManagerList;
            return View(_context.Orders);
        }

        //ToDo
        [HttpGet]
        public IActionResult FilterByManager(int? filterContext)
        {
            List<Order> filteredList = new List<Order>();
            if (filterContext != null)
            {
                filteredList = _context
                    .Orders.Where(m => m.ManagerId == filterContext).ToList();
            }
            else
            {
                filteredList = _context.Orders.ToList();
            }
            return PartialView("FilteredOrders", filteredList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.TitleFromView = "Add";
            ViewBag.Items = _managerSelectList.ManagerList;
            return View("Edit", new Order());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TitleFromView = "Edit";
            Order order = _context.Orders
                .FirstOrDefault(x => x.OrderId == id);
            ViewBag.Items = _managerSelectList.ManagerList;
            return View(order);
        }

        [HttpPost]
        public ActionResult Save(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.OrderId == 0)
                {
                    _context.Orders.Add(order);
                }
                else
                {
                    _context.Orders.Update(order);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error model exception");
            return View("Edit", order);
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
