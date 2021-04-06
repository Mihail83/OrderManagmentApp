using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                _orderService.SaveOrder(_mapperToOrder.Map(model));
                return RedirectToAction(nameof(OrderManager));
            }
            SetSelectListToViewBag();
            return View();
            
        }

        private void SetSelectListToViewBag()
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
                //ViewBag.shipDest= shipDestinationsList;
            }
        }
    }
}
