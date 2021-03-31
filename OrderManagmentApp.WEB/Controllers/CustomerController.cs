using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.WEB.Models;
using OrderManagmentApp.WEB.Services;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.WEB.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(             
            [FromServices] CustomerSupplier customerSupplier,
            [FromServices] IMapper<Customer, CustomerViewModel> mapper,
            int id = 1)
        {

           

            return View(mapper.Map(customerSupplier.GetCustomerById(id)));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            CustomerViewModel customerViewModel,
            [FromServices] CustomerToSave customerSaver,
            [FromServices] IMapper<CustomerViewModel, Customer > mapper
            )
        {
            if (ModelState.IsValid)
            {
                customerSaver.SaveEditedCustomer(mapper.Map(customerViewModel));
            }


            
                return RedirectToAction(nameof(Edit));
          
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
