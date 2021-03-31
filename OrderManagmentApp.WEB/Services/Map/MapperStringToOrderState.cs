﻿using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Enums;
using OrderManagmentApp.BusinessLogic.Interfaces;

namespace OrderManagmentApp.WEB.Services.Map
{
    class MapperStringToOrderState : IMapper<string, OrderState>
    {
        public OrderState Map(string orderstate) => orderstate switch
        {
            "В отгрузке" => OrderState.InShipment,
            "На складе" => OrderState.InStore,
            "В работе" => OrderState.InWork,
            "Реализовано" => OrderState.shipped,
            "Отправить в отгрузку" => OrderState.SetShipment,
            "Зависло" => OrderState.StoppedInStore,
            _ => throw new ArgumentException("Invalid mapping from string to orderState")
        };    
    }

}
