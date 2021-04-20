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

        public IEnumerable<ShipmentDestination> GetShipmentDestinations(IEnumerable<Expression<Func<ShipmentDestination, bool>>> expressions = null)
        {
            var shipmentDestination = _shipmentDestinationRepository.GetAllByExpression(expressions);
            //List<ShipmentDestination> result = shipmentDestination == null ? null : new List<ShipmentDestination>(shipmentDestination);
            return shipmentDestination;
        }
        public void Create(ShipmentDestination model)
        {
            _shipmentDestinationRepository.Add(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NullReferenceExeption, sqlExeption"> </exception>
        public void ToggleBlock(ShipmentDestination entity)
        {
            entity.IsDisabled = !entity.IsDisabled;

            _shipmentDestinationRepository.Update(entity);
        }

        public ShipmentDestination GetShipmentDestinationById(int id)
        {
            return _shipmentDestinationRepository.GetById(id);
        }
    }
}
