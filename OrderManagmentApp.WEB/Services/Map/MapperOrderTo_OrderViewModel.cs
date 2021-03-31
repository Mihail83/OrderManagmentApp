using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;
using OrderManagmentApp.DataLayer.Enums;

namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperOrderTo_OrderViewModel : IMapper<Order, OrderViewModel>
    {     
        public OrderViewModel Map(Order model)
        {
            var orderViewModel = new OrderViewModel 
            {
                Id = model.Id,
                DateOfCreating = model.DateOfCreating,
                CustomerId = model.CustomerId,
                CustomerName = model.CustomerName,
                CustomerPhones = model.CustomerPhones,
                CurrentAgreement = model.CurrentAgreement,
                Good = model.Good,
                ContractSum = model.ContractSum,
                Advance = model.Advance,
                AdditionalInfo = model.AdditionalInfo,
                ShipmentSpecialist = model.ShipmentSpecialist,
                ShipmentDestination = model.ShipmentDestination,
                Manager = model.Manager,
                OrderInFactory_StateOfShipment = model.OrderInFactory_StateOfShipment,
                OrderState = model.OrderState                
            };
            return orderViewModel;
        }
    }
}
