using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace OrderManagmentApp.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly IMapper<Order, OrderViewModel> _mapperToViewModel;
        private readonly IMapper<OrderViewModel, Order> _mapperToOrder;
        private readonly ManagerService _managerService;
        private readonly ShipmentSpecialistService _shipmentSpecialistService;
        private readonly ShipmentDestinationService _shipmentDestinationService;


        public OrderController(
            OrderService orderService,
            IMapper<Order, OrderViewModel> mapper,
            IMapper<OrderViewModel, Order> mapperToOrder,
            ManagerService managerService,
            ShipmentSpecialistService shipmentSpecialistService,
            ShipmentDestinationService shipmentDestinationService)
        {
            _orderService = orderService;
            _mapperToViewModel = mapper;
            _mapperToOrder = mapperToOrder;
            _managerService = managerService;
            _shipmentSpecialistService = shipmentSpecialistService;
            _shipmentDestinationService = shipmentDestinationService;
        }
        public IActionResult OrderManager()
        {
            var AllOrderViewModel = new List<OrderViewModel>();
            foreach (var order in _orderService.GetOrdersToOrderManagerPage())
            {
                AllOrderViewModel.Add(_mapperToViewModel.Map(order));
            }

            return View(AllOrderViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetSelectListToViewBag();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_orderService.GetOrderById(model.Id ) == null)
                {
                    try
                    {
                        _orderService.SaveOrder(_mapperToOrder.Map(model));
                        return RedirectToAction(nameof(OrderManager));
                    }
                    catch (Exception ex)
                    {
                        // TODO нормальный перехват ошибок  Create = OrderViewModel

                        ModelState.AddModelError("BaseError", $"{ex.InnerException}");                    
                    }                    
                }
                else
                {                    
                    ModelState.AddModelError("NotUniqueID", $"Эта спецификация уже существует");
                }                
            }
            SetSelectListToViewBag();
            return View(model);            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _orderService.GetOrderById(id);
            SetSelectListToViewBag();
            if (order == null)
            {
                return RedirectToAction(nameof(Create));

            }
            return View(_mapperToViewModel.Map(order));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                _orderService.UpdateOrder(_mapperToOrder.Map(orderViewModel));
                return RedirectToAction(nameof(OrderManager));
            }
            else
            {
                SetSelectListToViewBag();  
                return View();
            }

            
        }

        private void SetSelectListToViewBag()  //???  Добавлять данные через ajax  ???
        {
            var managers = _managerService.GetManagers();
            if (managers != null)
            {
                var managerList = new SelectList(managers, "Id", "Name");
                ViewBag.managers = managerList;
            }

            var shipSpecialists = _shipmentSpecialistService.GetShipmentSpecialists();
            if (shipSpecialists != null)
            {
                var shipSpecialistsList = new SelectList(shipSpecialists, "Id", "Specialist");
                ViewBag.shipmentSpecialists = shipSpecialistsList;
            }
            var shipDestinations = _shipmentDestinationService.GetShipmentDestinations();
            if (shipDestinations != null)
            {
                ViewBag.shipDest = new SelectList(shipDestinations, "Id", "Destination");                
            }
        }
    }
}
