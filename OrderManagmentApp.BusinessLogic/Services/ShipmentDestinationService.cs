using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Linq.Expressions;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class ShipmentDestinationService
    {
        private readonly IGenericCrudRepository<ShipmentDestination> _shipmentDestinationRepository;

        public ShipmentDestinationService(IGenericCrudRepository<ShipmentDestination> shipmentDestinationRepository)
        {
            _shipmentDestinationRepository = shipmentDestinationRepository;
        }

        public List<ShipmentDestination> GetShipmentDestinations(IEnumerable<Expression<Func<ShipmentDestination, bool>>> expressions = null)
        {
            var shipmentDestination = _shipmentDestinationRepository.GetAllByExpression(expressions);
            List<ShipmentDestination> result = shipmentDestination == null ? null : new List<ShipmentDestination>(shipmentDestination);
            return result;
        }
    }
}
