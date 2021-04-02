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
        IMapper<Customer, CustomerViewModel> _mapperToViewModel;
        IMapper<CustomerViewModel, Customer> _mapperToBysinessModel;
        public CustomerController
            (
            IMapper<Customer, CustomerViewModel> mapperToViewModel,
            IMapper<CustomerViewModel, Customer> mapperToBysinessModel
            )
        {
            _mapperToViewModel = mapperToViewModel;
            _mapperToBysinessModel = mapperToBysinessModel;
        }

        public ActionResult CustomerManager([FromServices] Customers_Supplier customersSupplier)
        {
            var customers = customersSupplier.GetAllCustomer();
            List<CustomerViewModel> customerViewModels = null;
            if (customers !=null)
            {
                customerViewModels = new List<CustomerViewModel>();
                foreach (var customer in customers)
                {
                    customerViewModels.Add(_mapperToViewModel.Map(customer));
                }                
            }
            return View(customerViewModels);
        }
                
        ActionResult Details(int id)
        {
            return View();
        }
                
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create
            (
            [FromServices] CustomerServiceForSaveNew customerServiceForNew, 
            CustomerViewModel customerViewModel, IFormCollection collection
            )
        {
            if (ModelState.IsValid)
            {
                customerServiceForNew.SaveNewCustomer(_mapperToBysinessModel.Map(customerViewModel));
            }
            else
            {
                return View(customerViewModel);
            }
            
                return RedirectToAction(nameof(CustomerManager));            
        }        
        public ActionResult Edit([FromServices] CustomerSupplier customerSupplier, int id = 1)
        {
            return View(_mapperToViewModel.Map(customerSupplier.GetCustomerById(id)));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit
            (
            CustomerViewModel customerViewModel,
            [FromServices] CustomerServiceForSaveEdited customerSaver
            )
        {
            if (ModelState.IsValid)
            {
                customerSaver.SaveEditedCustomer(_mapperToBysinessModel.Map(customerViewModel));
            }
            else
            {
                return View(customerViewModel);
            }
                return RedirectToAction(nameof(CustomerManager));          
        }

        // GET: CustomerController/Delete/5
        ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(CustomerManager));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
