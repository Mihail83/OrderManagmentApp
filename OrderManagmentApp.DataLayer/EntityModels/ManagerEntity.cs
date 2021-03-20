﻿using System.Collections.Generic;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class ManagerEntity
    {        
        public int Id { get; set; }        
        public string ManagerName { get; set; }       
        public List<OrderEntity> OrderEntities { get; set; }
    }
}
