using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class OrderEntityAgreementEntity
    {
        public int OrderEntityId { get; set;}
        public OrderEntity Order { get; set; }
        public int AgreementEntityId { get; set; }
        public AgreementEntity Agreement { get; set; }
    }
}
