using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.WEB.API
{
    
    [ApiController]
    public class CustomerSuggestionController : Controller
    {
        private OrderManagmentAppContext _appContext;
        public CustomerSuggestionController(OrderManagmentAppContext appContext) 
        {
            _appContext = appContext;
        }
       

        [Produces("application/json")]
        [HttpPost]
        [Route("api/CustomerSuggestion")]
        public  JsonResult Search(string _prefix)
        {
            string term = HttpContext.Request.Query["prefix"].ToString();
            var names = _appContext.Customers
                .Where(p => p.Name.StartsWith(term))
                .Select(customer => new { label = customer.Name,val = customer.Id  })
                .ToList();
            return Json(names);
        }
    }
}
