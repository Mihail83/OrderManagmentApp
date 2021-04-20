using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagmentApp.WEB.Models
{
    public class ShipmentDestinationViewModel
    {
        public int Id { get; set; }
        public string Destination { get; set; }        
        public bool IsDisabled { get; set; }
    }
}
