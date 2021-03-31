using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.EntityModels;


namespace OrderManagmentApp.BusinessLogic.Services.MAP
{
    public class MapperOrderToOrderEntity : IMapper<Order, OrderEntity>
    {
        public OrderEntity Map(Order order)        
        {
            var orderEntity = new OrderEntity
            {
                Id = order.Id,   //  if new?
                Advance = order.Advance,
                AdditionalInfo = order.AdditionalInfo,
                ContractSum = order.ContractSum,
                CurrentAgreement = order.CurrentAgreement,
                CustomerId = order.CustomerId,
                Good = order.Good,
                IsArchived = order.IsArchived,
                Manager = new ManagerEntity {Name = order.Manager } ,                
                ShipmentDestination =  new ShipmentDestinationEntity {Destination = order.ShipmentDestination} ,                
                ShipmentSpecialist = new ShipmentSpecialistEntity {Specialist = order.ShipmentSpecialist } ,                          
            };
            return orderEntity;
        }
    }
}
