//using OrderManagmentApp.BusinessLogic.Interfaces;
//using OrderManagmentApp.DataLayer.Enums;
//using System;


//namespace OrderManagmentApp.WEB.Services.Map
//{
//    class MapperOrderStateToString : IMapper<OrderState, string>
//    {
//        public string Map(OrderState model) => model switch
//        {
//            OrderState.InShipment => "В отгрузке",
//            OrderState.InStore => "На складе",
//            OrderState.InWork => "В работе",
//            OrderState.shipped => "Реализовано",
//            OrderState.SetShipment => "Отправить в отгрузку",
//            OrderState.StoppedInStore => "Зависло",
//            _ => throw new ArgumentException("Invalid mapping from OrderState")
//        };
//    }
//}
