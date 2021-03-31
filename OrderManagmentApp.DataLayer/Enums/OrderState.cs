using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OrderManagmentApp.DataLayer.Enums
{
    public enum OrderState 
    {
        [Display(Name ="В работе")]
        InWork = 0,
        [Display(Name = "Отправить в отгрузку")]
        SetShipment,
        [Display(Name = "В отгрузке")]
        InShipment,
        [Display(Name = "На складе")]
        InStore,
        [Display(Name = "Реализовано")]
        shipped,
        [Display(Name = "Зависло")]
        StoppedInStore
    }    
}
