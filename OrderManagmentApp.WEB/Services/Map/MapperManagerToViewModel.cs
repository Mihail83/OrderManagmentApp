using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperManagerToViewModel : IMapper<Manager, ManagerViewModel>
    {
        public ManagerViewModel Map(Manager model)
        {
            var viewModel = new ManagerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsDismissed = model.IsDismissed
            };
            return viewModel;
        }
    }
}
