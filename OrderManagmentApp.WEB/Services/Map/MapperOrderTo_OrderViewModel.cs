using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using System.Text;

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
                CustomerName = model.Customer.Name,
                Advance = model.Advance,
                AdditionalInfo = model.AdditionalInfo,
                ShipmentSpecialist = model.ShipmentSpecialist?.Specialist,
                ShipmentDestination = model.ShipmentDestination?.Destination,
                Manager = model.Manager.Name,
                OrderInFactory_StateOfShipment = model.OrderInFactory?.StateOfShipment,
                OrderState = model.OrderState
            };
            orderViewModel.CustomerPhones = new List<string>(model.Customer.Phones);
            
            if (model.OrderAgreement!=null)
            {
                var builder = new StringBuilder();
                builder.Append(model.OrderAgreement.Agreement.Id);
                builder.Append(@"/");
                builder.Append(model.OrderAgreement.Agreement.CreateDate.Year);
                orderViewModel.CurrentAgreement = builder.ToString();

                orderViewModel.Good = model.OrderAgreement.Agreement.Good;
                orderViewModel.ContractSum = model.OrderAgreement.Agreement.Sum;
                orderViewModel.CurrentAgreementId = model.OrderAgreement.Agreement.Id;
            }
            else
            {
                orderViewModel.CurrentAgreement = "Без договора";
                orderViewModel.Good = model.Good;
                orderViewModel.ContractSum = model.ContractSum;
            }
            return orderViewModel;
        }
    }
}
