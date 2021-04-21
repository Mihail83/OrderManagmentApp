using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagmentApp.WEB.Controllers
{
    [Authorize(Roles ="admin")]
    public class SecondaryTablesController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }
    }
}
