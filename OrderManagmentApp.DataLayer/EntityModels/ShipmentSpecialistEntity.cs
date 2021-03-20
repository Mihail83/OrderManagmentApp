using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class ShipmentSpecialistEntity
    {
        public int Id { get; set; }
        public string Specialist { get; set; }                
        public List<OrderEntity> OrderEntities { get; set; }
    }
}
