using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;


namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperAgreementToAgreementViewModel : IMapper<Agreement, AgreementViewModel>
    {
        public AgreementViewModel Map(Agreement model)
        {
            var viewModel = new AgreementViewModel
            {
                Id = model.Id,
                CreateDate = model.CreateDate,
                Good = model.Good,
                Sum = model.Sum,
                Customer = model.Customer?.Name,
                CustomerId = model.CustomerId,
                OrderId = model.OrderAgreement?.OrderId
            };
            return viewModel;
        }
    }
}
