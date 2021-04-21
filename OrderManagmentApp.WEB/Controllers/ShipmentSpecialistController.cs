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
    public class ShipmentSpecialistController : Controller
    {
        private readonly ShipmentSpecialistService _shipmentSpecialistService;
        private readonly IMapper<ShipmentSpecialist, ShipmentSpecialistViewModel> _mapperToViewModel;
        private readonly IMapper<ShipmentSpecialistViewModel, ShipmentSpecialist> _mapperToShipmentSpesialist;
        public ShipmentSpecialistController
            (
                ShipmentSpecialistService shipmentSpecialistService,
                IMapper<ShipmentSpecialist, ShipmentSpecialistViewModel> mapperToViewModel,
                IMapper<ShipmentSpecialistViewModel, ShipmentSpecialist> mapperToShipmentSpesialist
            )
        {
            _shipmentSpecialistService = shipmentSpecialistService;
            _mapperToViewModel = mapperToViewModel;
            _mapperToShipmentSpesialist = mapperToShipmentSpesialist;
        }
        public IActionResult ShipmentSpecialistList()
        {
            var shipmentSpecialistViewModels = new List<ShipmentSpecialistViewModel>();
            foreach (var entity in _shipmentSpecialistService.GetShipmentSpecialists())
            {
                shipmentSpecialistViewModels.Add(_mapperToViewModel.Map(entity));
            }             
            return View(shipmentSpecialistViewModels);
        }

        /// <summary>
        ///  I try to learn how write summary properly
        /// </summary>
        /// <param name="shipmentSpecialistViewModel"></param>
        ///  <returns>Json  =  bool</returns>
   
        public JsonResult Create(string newShipmentSpecialist)
        {
            bool result = false;
            var expressions = new Expression<Func<ShipmentSpecialist, bool>>[]
            {
                    (shipmentSpec) => shipmentSpec.Specialist == newShipmentSpecialist
            };

            if (_shipmentSpecialistService.GetShipmentSpecialists(expressions).Count() == 0)
            {
                _shipmentSpecialistService.Create(new ShipmentSpecialist { Specialist = newShipmentSpecialist });
                result = true;
            }
            return Json(result);
        }
      
        public JsonResult ToggleBlock(int id)
        {
            var entity =  _shipmentSpecialistService.GetShipmentSpecialistId(id);
            bool result = false;
            if (entity != null)
            {
                _shipmentSpecialistService.ToggleBlock(entity);
                result = true;
            }
            return Json(result);
        }
    }
}
