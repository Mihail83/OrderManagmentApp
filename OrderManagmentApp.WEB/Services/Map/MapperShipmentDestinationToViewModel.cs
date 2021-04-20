using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperShipmentDestinationToViewModel : IMapper<ShipmentDestination, ShipmentDestinationViewModel>
    {
        public ShipmentDestinationViewModel Map(ShipmentDestination model)
        {
            var ViewModel = new ShipmentDestinationViewModel
            {
                Id = model.Id,
                Destination = model.Destination,
                IsDisabled = model.IsDisabled
            };
            return ViewModel;
        }
    }
}
