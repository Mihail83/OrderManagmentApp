using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using OrderManagmentApp.Infrastructure.StateKeepers;
using OrderManagmentApp.Infrastructure.Enums;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;
using OrderManagmentApp.WEB.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagmentApp.WEB.Controllers
{
    [Authorize]
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
        public IActionResult ChangePage(int PageModification)
        {
            OrderManagerState ordersState = HttpContext.Session.Get<OrderManagerState>("orderManagerState");
            ordersState.PageState.CurrentPage = ordersState.PageState.CurrentPage + PageModification;
            SaveOrderManagerState(ordersState);
            return RedirectToAction("OrderManager");
        }

        [HttpPost]
        public IActionResult ChangeFilter(FilterStateOfOrders filterStateOfOrders )            
        {
            OrderManagerState ordersState = HttpContext.Session.Get<OrderManagerState>("orderManagerState");
            ordersState.FilterState = filterStateOfOrders;
            ordersState.PageState = new PageState();
            SaveOrderManagerState(ordersState);
            return RedirectToAction("OrderManager");
        }

        public IActionResult ChangeSort(OrderSortState orderSortState)
        {
            OrderManagerState ordersState = HttpContext.Session.Get<OrderManagerState>("orderManagerState");
            ordersState.SortState.CurrentSort = orderSortState;
            SaveOrderManagerState(ordersState);
            return RedirectToAction("OrderManager");
        }
    
        private void SaveOrderManagerState(OrderManagerState orderManagerState)
        {
            HttpContext.Session.Set<OrderManagerState>("orderManagerState", orderManagerState);
        }
        public IActionResult OrderManager()
        {            
            OrderManagerState ordersState = HttpContext.Session.Get<OrderManagerState>("orderManagerState");
            if (ordersState == null)
            {
                ordersState = new OrderManagerState();
                SaveOrderManagerState(ordersState);
            }

            var AllOrderViewModel = new List<OrderViewModel>();
            foreach (var order in _orderService.GetOrdersToOrderManagerPage(ordersState))   //две обязанности...   изменяет состояние otderstate
            {
                AllOrderViewModel.Add(_mapperToViewModel.Map(order));
            }

            SaveOrderManagerState(ordersState);
            var orderManagerViewModel = new OrderManagerViewModel 
            {
                orderViewModels =AllOrderViewModel, 
                state = ordersState
            };

            var managers = _managerService.GetManagers();
            if (managers != null)
            {
                var managerList = new SelectList(managers, "Id", "Name");
                ViewBag.managers = managerList.SetSelectedItemByValue(ordersState.FilterState.ValueOfFilterByManagerId.ToString());                 
            }

            var shipSpecialists = _shipmentSpecialistService.GetShipmentSpecialists();
            if (shipSpecialists != null)
            {
                var shipSpecialistsList = new SelectList(shipSpecialists, "Id", "Specialist");             
                ViewBag.shipmentSpecialists = shipSpecialistsList.SetSelectedItemByValue(ordersState.FilterState.ValueOfFilterByShipmentSpecId.ToString());
            }

            var shipDestinations = _shipmentDestinationService.GetShipmentDestinations();

            if (shipDestinations != null)
            {
                var shipSpecialistsList = new SelectList(shipDestinations, "Id", "Destination");
                ViewBag.shipDest = shipSpecialistsList.SetSelectedItemByValue(ordersState.FilterState.ValueOfFilterByShipmentDestId.ToString());
            }
            return View(orderManagerViewModel);
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
        [Authorize(Roles = "Advanced_user")]
        
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

        [Authorize(Roles = "Advanced_user")]
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
            var managers = _managerService.GetManagers(
                new Expression<Func<Manager, bool>>[] {(manager) => manager.IsDismissed == false} 
                );

            if (managers != null)
            {
                var managerList = new SelectList(managers, "Id", "Name");
                ViewBag.managers = managerList;
            }

            var shipSpecialists = _shipmentSpecialistService.GetShipmentSpecialists(
                new Expression<Func<ShipmentSpecialist, bool>>[]{ (shipSpec) => shipSpec.IsDismissed == false}
                );
            if (shipSpecialists != null)
            {
                var shipSpecialistsList = new SelectList(shipSpecialists, "Id", "Specialist");
                ViewBag.shipmentSpecialists = shipSpecialistsList;
            }

            var shipDestinations = _shipmentDestinationService.GetShipmentDestinations(
                new Expression<Func<ShipmentDestination, bool>>[] { (shipSpec) => shipSpec.IsDisabled == false}
                );
            if (shipDestinations != null)
            {
                ViewBag.shipDest = new SelectList(shipDestinations, "Id", "Destination");                
            }
        }
    }
}
