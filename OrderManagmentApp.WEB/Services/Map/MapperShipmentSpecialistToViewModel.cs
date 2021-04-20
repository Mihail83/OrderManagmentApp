using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperShipmentSpecialistToViewModel : IMapper<ShipmentSpecialist, ShipmentSpecialistViewModel>
    {
        public ShipmentSpecialistViewModel Map(ShipmentSpecialist model)
        {
            var ViewModel = new ShipmentSpecialistViewModel
            {
                Id = model.Id,
                Specialist = model.Specialist,
                IsDismissed = model.IsDismissed
            };
            return ViewModel;
        }
    }
}
