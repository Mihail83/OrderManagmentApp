using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperViewModelToManager : IMapper<ManagerViewModel , Manager >
    {
        public Manager Map(ManagerViewModel model)
        {
            var Model = new Manager
            {
                Id = model.Id,
                Name = model.Name,
                IsDismissed = model.IsDismissed
            };
            return Model;
        }
    }
}
