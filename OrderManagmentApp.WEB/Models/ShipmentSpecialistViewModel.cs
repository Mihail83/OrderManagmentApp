using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagmentApp.WEB.Models
{
    public class ShipmentSpecialistViewModel
    {
        public int Id { get; set; }
        public string Specialist { get; set; }       
        public bool IsDismissed { get; set; }
    }
}
