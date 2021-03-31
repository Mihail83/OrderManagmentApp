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
        public Phones Phones { get; set; }   
        public string Emeil { get; set; }
        public string AdditionalInfo { get; set; }        
        //public bool IsLegalPerson { get; set; }
        public Company Company { get; set; }        
        public List<OrderEntity> Orders { get; set; }        
        public List<AgreementEntity> AgreementEntities { get; set; }




    }
}
