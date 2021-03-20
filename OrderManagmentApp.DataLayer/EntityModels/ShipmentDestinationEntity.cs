using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class ShipmentDestinationEntity
    {
        public int Id { get; set; }
        public string Destination { get; set; }        
        public List<OrderEntity> OrderEntities { get; set; }


    }
}
