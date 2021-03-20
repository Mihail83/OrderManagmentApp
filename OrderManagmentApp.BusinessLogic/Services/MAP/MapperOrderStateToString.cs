using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Enums;
using OrderManagmentApp.BusinessLogic.Interfaces; 


namespace OrderManagmentApp.BusinessLogic.Services.MAP
{
    class MapperOrderStateToString : IMapper<OrderState, string>
    {
        public string Map(OrderState model) => model switch
        {
            OrderState.InShipment => "В отгрузке",
            OrderState.InStore=> "На складе",
            OrderState.InWork=> "В работе",
            OrderState.Realize=> "Реализовано",
            OrderState.SetShipment=> "Отправить в отгрузку",
            OrderState.StoppedInStore=> "Зависло",
            _=> throw new ArgumentException("Invalid mapping from OrderState")            
        };
    }
}
