using System.ComponentModel.DataAnnotations;

namespace OrderManagmentApp.Infrastructure.Enums
{
    public enum OrderState
    {
        [Display(Name = "В работе")]
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
