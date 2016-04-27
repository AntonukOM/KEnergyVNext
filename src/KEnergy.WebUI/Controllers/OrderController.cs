using System.Collections.Generic;
using System.Linq;
using KEnergy.WebUI.Helpers.UI;
using KEnergy.WebUI.Models;
using Microsoft.AspNet.Mvc;
using KEnergy.WebUI.DSL.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Http;

namespace KEnergy.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ManagerSelectList _managerSelectList;
        private readonly IOrderRepository  _orderRepository;
        private readonly IManagerRepository _managerRepository;

        public OrderController(IOrderRepository orders, IManagerRepository managers)
        {
            this._orderRepository = orders;
            this._managerRepository = managers;
            this._managerSelectList = new ManagerSelectList(_managerRepository);
            InitiateManagers();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Message = TempData["message"];
            ViewBag.ManagerList = _managerSelectList.ManagerList;
            return View(_orderRepository.Orders);
        }

        [HttpGet]
        public IActionResult FilterByManager(int? managerId)
        {
            return PartialView("FilteredOrders", _orderRepository.FilredByManager(managerId));
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


        //Todo
        [HttpGet]
        public IActionResult EditModal(int id)
        {
            ViewBag.TitleFromView = "Edit";
            Order order = _orderRepository.FindById(id);
            ViewBag.Items = _managerSelectList.ManagerList;
            return View("EditPartial", order);
        }

        //Todo
        [HttpGet]
        public IActionResult AddModal(Order order)
        {
            var result = true;
            ViewBag.ManagerList = _managerSelectList.ManagerList;
            return Content(result ? "Ok" : string.Empty);
            //return View("EditPartial", new Order());
        }

        //Todo
        [HttpPost]
        public IActionResult SaveModal(Order order)
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
            return View("EditPartial", order);
        }


        [HttpPost]
        public IActionResult Save(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.OrderId == 0)
                {
                    _orderRepository.Add(order);
                    TempData["message"] = $"Order number '{order.Number}' was added";
                }
                else
                {
                    _orderRepository.Edit(order);
                    TempData["message"] = $"Changes in order number '{order.Number}' was saved";
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error model exception");
            return View("Edit", order);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Location on google maps";
            return View();
        }


        [HttpGet]
        public JsonResult GetData()
        {
            Location address = new Location
            {
                Id = 1,
                Name = "K-Energy",
                GeoLat = 37.610489,
                GeoLong = 55.752308
            };
            return Json(address);
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

        private void InitiateManagers()
        {
            //initialize managers in order repository
            //for js filter corect work
            foreach (var o in _orderRepository.Orders)
            {
                o.Manager = _managerRepository.Managers
                    .FirstOrDefault(x => x.ManagerId == o.ManagerId);
            }
        }
    }
}
