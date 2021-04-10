using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;

namespace OrderManagmentApp.WEB.API
{
    
    [ApiController]
    public class AgreementController : Controller
    {
        private readonly OrderManagmentAppContext _appContext;
        private readonly AgreementService _agreementService;
        public AgreementController(OrderManagmentAppContext appContext, AgreementService agreementService) 
        {
            _appContext = appContext;
            _agreementService = agreementService;
        }
       

        [Produces("application/json")]
        [HttpGet]
        [Route("api/GetAgreementsOfCustomer")]
        public  JsonResult GetAgreementsThisCustomer(int id)
        {
            var Agreements = _appContext.Agreements
                .Where(agr => agr.CustomerId == id)
                .Select(agreement=> new {id = agreement.Id, date= agreement.CreateDate.ToShortDateString() })
                .ToList();                
                
            return Json(Agreements);
        }
    }
}
