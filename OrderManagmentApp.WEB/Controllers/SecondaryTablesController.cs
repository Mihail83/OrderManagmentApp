using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagmentApp.WEB.Controllers
{
    public class SecondaryTablesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
