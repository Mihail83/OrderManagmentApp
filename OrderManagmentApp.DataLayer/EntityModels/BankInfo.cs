using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderManagmentApp.DataLayer.EntityModels
{    
    public class BankInfo
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Account { get; set; }
    }
}
