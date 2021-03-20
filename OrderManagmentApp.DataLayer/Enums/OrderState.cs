using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.DataLayer.Enums
{
    public enum OrderState 
    {
        InWork = 0,
        SetShipment,
        InShipment,
        InStore,
        Realize,
        StoppedInStore
    }    
}
