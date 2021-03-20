using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderManagmentApp.DataLayer.EntityModels
{    
    public class LegalPerson
    {
        public string PayersAccountNumber { get; set; }
        public BankInfo Bank { get; set; }
        public string Address { get; set; }
        public ulong OKPO { get; set; }
    }
}
