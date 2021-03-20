using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class CustomerEntity
    {        
        public int Id { get; set; }
        public string Name{ get; set; }        
        public string Address { get; set; }        
        public Phones PhoneNumbers { get; set; }   
        public string Emeil { get; set; }
        public string Comment { get; set; }        
        public bool IsLegalPerson { get; set; }
        public LegalPerson LegalPerson { get; set; }        
        public List<OrderEntity> Orders { get; set; }        
        public List<TreatyEntity> TreatyEntities { get; set; }




    }
}
