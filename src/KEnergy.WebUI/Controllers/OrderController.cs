using System.Collections.Generic;
using KEnergy.WebUI.Helpers.UI;
using KEnergy.WebUI.Models;
using Microsoft.AspNet.Mvc;
using System.Linq;
using KEnergy.WebUI.DSL.Interfaces;

namespace KEnergy.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ManagerSelectList _managerSelectList;
        private readonly IOrderRepository  _orderRepository;

        public OrderController(IOrderRepository orders, IManagerRepository managers)
        {
            this._orderRepository = orders;
            this._managerSelectList = new ManagerSelectList(managers);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ManagerList = _managerSelectList.ManagerList;
            return View(_orderRepository.Orders);
        }

        //ToDo
        [HttpGet]
        public IActionResult FilterByManager(int? filterContext)
        {
            return PartialView("FilteredOrders", _orderRepository.FilredByManager(filterContext));
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.TitleFromView = "Add";
            ViewBag.Items = _managerSelectList.ManagerList;
            return View("Edit", new Order());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.TitleFromView = "Edit";
            Order order = _orderRepository.FindById(id);
            ViewBag.Items = _managerSelectList.ManagerList;
            return View(order);
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return null;
        }

        [HttpPost]
        public IActionResult Save(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.OrderId == 0)
                {
                    _orderRepository.Add(order);
                }
                else
                {
                    _orderRepository.Edit(order);
                }
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
