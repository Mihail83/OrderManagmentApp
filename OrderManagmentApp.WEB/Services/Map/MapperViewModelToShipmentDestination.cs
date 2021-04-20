using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperViewModelToShipmentDestination : IMapper<ShipmentDestinationViewModel, ShipmentDestination>
    {
        public ShipmentDestination Map(ShipmentDestinationViewModel model)
        {
            var ViewModel = new ShipmentDestination
            {
                Id = model.Id,
                Destination = model.Destination,
                IsDisabled = model.IsDisabled
            };
            return ViewModel;
        }
    }
}
