using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;

namespace OrderManagmentApp.WEB.Controllers
{
    public class CustomerController : Controller
    {
        readonly IMapper<Customer, CustomerViewModel> _mapperToViewModel;
        readonly IMapper<CustomerViewModel, Customer> _mapperToBysinessModel;
        readonly CustomerService _customerService;
        public CustomerController
            (
            IMapper<Customer, CustomerViewModel> mapperToViewModel,
            IMapper<CustomerViewModel, Customer> mapperToBysinessModel,
            CustomerService customerService
            )
        {
            _mapperToViewModel = mapperToViewModel;
            _mapperToBysinessModel = mapperToBysinessModel;
            _customerService = customerService;
        }

        public ActionResult CustomerManager()
        {
            var customers = _customerService.GetAllCustomer();
            List<CustomerViewModel> customerViewModels = null;
            if (customers != null)
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
            
            CustomerViewModel customerViewModel, IFormCollection collection
            )
        {
            if (ModelState.IsValid)
            {
                _customerService.SaveNewCustomer(_mapperToBysinessModel.Map(customerViewModel));
            }
            else
            {
                return View(customerViewModel);
            }

            return RedirectToAction(nameof(CustomerManager));
        }
        public ActionResult Edit(int id = 1)
        {
            return View(_mapperToViewModel.Map(_customerService.GetCustomerById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit
            (
            CustomerViewModel customerViewModel            
            )
        {
            if (ModelState.IsValid)
            {
                _customerService.SaveEditedCustomer(_mapperToBysinessModel.Map(customerViewModel));
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
