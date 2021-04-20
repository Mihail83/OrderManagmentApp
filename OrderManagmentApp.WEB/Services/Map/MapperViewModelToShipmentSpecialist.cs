using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperViewModelToShipmentSpecialist : IMapper<ShipmentSpecialistViewModel, ShipmentSpecialist >
    {
        public ShipmentSpecialist Map(ShipmentSpecialistViewModel model)
        {
            var Model = new ShipmentSpecialist
            {
                Id = model.Id,
                Specialist = model.Specialist,
                IsDismissed = model.IsDismissed
            };
            return Model;
        }
    }
}
