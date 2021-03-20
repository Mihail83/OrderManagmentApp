using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.EntityModels;


namespace OrderManagmentApp.BusinessLogic.Services.MAP
{
    public class MapperOrderEntityToOrder : IMapper<OrderEntity, Order>
    {
        public Order Map(OrderEntity model)        
        {
            Order order = new Order
            {
                ID = model.ID,
                Advance = model.Advance,
                Comment = model.Comment,
                ContractAmount = model.ContractAmount,
                CurrentTreaty = model.CurrentTreaty,
                CustomerId = model.CustomerId,
                CustomerName = model.Customer.Name,
                DateOfCreating = model.DateOfCreating,
                Good = model.Good,
                IsArchive = model.IsArchive,
                Manager = model.Manager.ManagerName,
                ManagerId = model.Manager.Id,
                OrderInALuteh_StateOfShipment = model.OrderInALuteh.StateOfShipment,
                ShipmentDestination = model.ShipmentDestination.Destination,
                ShipmentDestinationId = model.ShipmentDestinationId,
                ShipmentSpecialist = model.ShipmentSpecialist.Specialist,
                ShipmentSpecialistId = model.ShipmentSpecialistId             
            };
            order.CustomerPhones.Add(model.Customer.PhoneNumbers.FirstNumber);
            order.CustomerPhones.Add(model.Customer.PhoneNumbers.SecondNumber);
            order.CustomerPhones.Add(model.Customer.PhoneNumbers.ThirdNumber);


            return order;
        }
    }
}
