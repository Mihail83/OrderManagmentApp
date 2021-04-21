using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagmentApp.WEB.Controllers
{
    [Authorize(Roles = "User,Advanced_user")]
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

        //ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create
            (
            
            CustomerViewModel customerViewModel, IFormCollection collection
            )
        {
            if (ModelState.IsValid)
            {
                _customerService.SaveCustomer(_mapperToBysinessModel.Map(customerViewModel));
            }
            else
            {
                return View(customerViewModel);
            }

            return RedirectToAction(nameof(CustomerManager));
        }
        [Authorize(Roles = "Advanced_user")]
        public ActionResult Edit(int id = 1)
        {
            return View(_mapperToViewModel.Map(_customerService.GetCustomerById(id)));
        }

        [Authorize(Roles = "Advanced_user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit
            (
            CustomerViewModel customerViewModel            
            )
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(_mapperToBysinessModel.Map(customerViewModel));
            }
            else
            {
                return View(customerViewModel);
            }
            return RedirectToAction(nameof(CustomerManager));
        }
        
        ActionResult Delete(int id)
        {
            return View();
        }
    }
}
