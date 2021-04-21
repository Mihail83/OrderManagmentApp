using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagmentApp.WEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class ShipmentDestinationController : Controller
    {
        private readonly ShipmentDestinationService _shipmentDestinationService;
        private readonly IMapper<ShipmentDestination, ShipmentDestinationViewModel> _mapperToViewModel;
        private readonly IMapper<ShipmentDestinationViewModel, ShipmentDestination> _mapperToShipmentDestination;
        public ShipmentDestinationController
            (
                ShipmentDestinationService shipmentDestinationService,
                IMapper<ShipmentDestination, ShipmentDestinationViewModel> mapperToViewModel,
                IMapper<ShipmentDestinationViewModel, ShipmentDestination> mapperToShipmentDestination
            )
        {
            _shipmentDestinationService = shipmentDestinationService;
            _mapperToViewModel = mapperToViewModel;
            _mapperToShipmentDestination = mapperToShipmentDestination;
        }
        public IActionResult ShipmentDestinationList()
        {
            var shipmentDestinationViewModels = new List<ShipmentDestinationViewModel>();
            foreach (var manager in _shipmentDestinationService.GetShipmentDestinations())
            {
                shipmentDestinationViewModels.Add(_mapperToViewModel.Map(manager));
            }             
            return View(shipmentDestinationViewModels);
        }

        /// <summary>
        ///  I try to learn how write summary properly
        /// </summary>
        /// <param name="shipmentDestinationViewModel"></param>
        ///  <returns>Json  =  bool</returns>        
        public JsonResult Create(string newDestinationName)
        {
            bool result = false;            
            var exp = new Expression<Func<ShipmentDestination, bool>>[]
            {
                    (manager) => manager.Destination == newDestinationName
            };

            if (_shipmentDestinationService.GetShipmentDestinations(exp).Count() == 0)
            {
                _shipmentDestinationService.Create(new ShipmentDestination { Destination = newDestinationName });
                result = true;
            }
            return Json(result);
        }        
        public JsonResult ToggleBlock(int id)
        {
            var entity = _shipmentDestinationService.GetShipmentDestinationById(id);
            bool result = false;
            if (entity != null)
            {
                _shipmentDestinationService.ToggleBlock(entity);
                result = true;
            }
            return Json(result);
        }
    }
}
