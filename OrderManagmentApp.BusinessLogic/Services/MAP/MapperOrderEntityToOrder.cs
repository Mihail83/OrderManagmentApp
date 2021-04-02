using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.EntityModels;
using OrderManagmentApp.DataLayer.Enums;



namespace OrderManagmentApp.BusinessLogic.Services.MAP
{
    public class MapperOrderEntityToOrder : IMapper<OrderEntity, Order>
    {
        private readonly IMapper<OrderState, string> _mapper;
        public MapperOrderEntityToOrder(IMapper<OrderState, string> mapper)
        {
            _mapper = mapper;
        }

        public Order Map(OrderEntity orderEntity)        
        {
            Order order = new Order
            {
                Id = orderEntity.Id,
                Advance = orderEntity.Advance,
                AdditionalInfo = orderEntity.AdditionalInfo,

                    
                    
                CustomerId = orderEntity.CustomerId,
                CustomerName = orderEntity.Customer.Name,
                DateOfCreating = orderEntity.DateOfCreating,                    
                IsArchived = orderEntity.IsArchived,
                Manager = orderEntity.Manager.Name,                
                OrderInFactory_StateOfShipment = orderEntity.OrderInFactory?.StateOfShipment ?? String.Empty,
                ShipmentDestination = orderEntity.ShipmentDestination?.Destination ?? String.Empty,                
                ShipmentSpecialist = orderEntity.ShipmentSpecialist?.Specialist ?? String.Empty,
                //MainPhoneNumber = orderEntity.Customer.PhoneNumbers.FirstNumber,
                //SecondPhoneNumber = orderEntity.Customer.PhoneNumbers.SecondNumber,
                //ThirdPhoneNumber = orderEntity.Customer.PhoneNumbers.ThirdNumber
            };
            order.CustomerPhones = new List<string> 
            {
                orderEntity.Customer?.Phones?.FirstNumber ?? String.Empty,
                orderEntity.Customer?.Phones?.SecondNumber ?? String.Empty,
                orderEntity.Customer?.Phones?.ThirdNumber ?? String.Empty
            };
            order.OrderState = _mapper.Map(orderEntity.OrderState);
            if (orderEntity.OrderAgreement?.Agreement==null)
            {
                order.ContractSum = orderEntity.ContractSum;
                order.Good = orderEntity.Good;
            }
            else
            {
                order.ContractSum = orderEntity.OrderAgreement.Agreement.Sum;
                order.Good = orderEntity.OrderAgreement.Agreement.Good;
            }
            return order;
        }
    }
}
