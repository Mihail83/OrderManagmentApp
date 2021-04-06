using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperOrderViewModelToOrder : IMapper<OrderViewModel, Order>
    {
        public Order Map(OrderViewModel model)
        {
            var order = new Order
            {
                Id = model.Id,
                AdditionalInfo = model.AdditionalInfo ?? string.Empty,
                Advance = model.Advance,
                CustomerId = model.CustomerId,
                IsArchived = model.IsArchived,
                Manager = new Manager { Name = model.Manager },
                OrderState = model.OrderState,
                ShipmentDestination = new ShipmentDestination { Destination = model.ShipmentDestination ?? string.Empty },
                ShipmentSpecialist = new ShipmentSpecialist { Specialist = model.ShipmentSpecialist ?? string.Empty }                
            };

            if (model.CurrentAgreementId==null)
            {
                order.ContractSum = model.ContractSum;
                order.Good = model.Good;
            }
            else
            {
                order.OrderAgreement = new OrderAgreement { OrderId = order.Id, AgreementId = (int)model.CurrentAgreementId };
            }

            return order;
        }
    }
}
