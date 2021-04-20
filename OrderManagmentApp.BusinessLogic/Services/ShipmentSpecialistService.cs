using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Linq.Expressions;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class ShipmentSpecialistService
    {
        private readonly IGenericCrudRepository<ShipmentSpecialist> _shipmentSpecialistRepository;

        public ShipmentSpecialistService(IGenericCrudRepository<ShipmentSpecialist> shipmentSpecialistRepository)
        {
            _shipmentSpecialistRepository = shipmentSpecialistRepository;
        }

        public List<ShipmentSpecialist> GetShipmentSpecialists(IEnumerable<Expression<Func<ShipmentSpecialist, bool>>> expressions = null)
        {
            var shipmentSpecialists = _shipmentSpecialistRepository.GetAllByExpression(expressions);
            List<ShipmentSpecialist> result = shipmentSpecialists == null ? null : new List<ShipmentSpecialist>(shipmentSpecialists);
            return result;
        }
        public void Create(ShipmentSpecialist model) 
        {
            _shipmentSpecialistRepository.Add(model);
        }
        public void ToggleBlock(ShipmentSpecialist entity)
        {
            entity.IsDismissed = !entity.IsDismissed;

            _shipmentSpecialistRepository.Update(entity);
        }
        public ShipmentSpecialist GetShipmentSpecialistId(int id)
        {
            return _shipmentSpecialistRepository.GetById(id);
        }
    }
}
