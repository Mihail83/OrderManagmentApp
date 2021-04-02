using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class AgreementEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }        
        public string Good { get; set; }
        public decimal Sum { get; set; }
        public int CustomerId { get; set; }
        public  CustomerEntity Customer { get; set; }
       
        public OrderEntityAgreementEntity OrderAgreement { get; set; }
    }
}
