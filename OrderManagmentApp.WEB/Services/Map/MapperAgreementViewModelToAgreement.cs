using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;

namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperAgreementViewModelToAgreement : IMapper<AgreementViewModel, Agreement>
    {
        public Agreement Map(AgreementViewModel model)
        {
            var result = new Agreement 
            {
                Id = model.Id,
                Good = model.Good,
                Sum = model.Sum,
                CustomerId = model.CustomerId,
                OrderAgreement = model.OrderId!=null?new OrderAgreement {AgreementId = model.Id, OrderId = (int)model.OrderId }:null
            };
            return result;            
        }
    }
}
