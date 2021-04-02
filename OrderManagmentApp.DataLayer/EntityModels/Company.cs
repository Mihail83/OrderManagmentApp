using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderManagmentApp.DataLayer.EntityModels
{    
    public class Company
    {
        public string Name { get; set; }
        public string TaxPayerId { get; set; }        
        public string Address { get; set; }
        public string BankAccount { get; set; }
    }
}
