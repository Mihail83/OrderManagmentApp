using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;

namespace OrderManagmentApp.WEB.Controllers
{
    public class AgreementController : Controller
    {
        readonly IMapper<Agreement, AgreementViewModel> _mapperToViewModel;
        readonly IMapper<AgreementViewModel, Agreement> _mapperToBysinessModel;
        readonly AgreementService _agreementService;
        public AgreementController
            (
            IMapper<Agreement, AgreementViewModel> mapperToViewModel,
            IMapper<AgreementViewModel, Agreement> mapperToBysinessModel,
            AgreementService agreementService
            )
        {
            _mapperToViewModel = mapperToViewModel;
            _mapperToBysinessModel = mapperToBysinessModel;
            _agreementService = agreementService;
        }

        public ActionResult AgreementManager()
        {
            var agreements = _agreementService.GetAgreementToAgreementPage();
            List<AgreementViewModel> customerViewModels= null;
            if (agreements != null)
            {
                customerViewModels = new List<AgreementViewModel>();
                foreach (var agreement in agreements)
                {
                    customerViewModels.Add(_mapperToViewModel.Map(agreement));
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgreementViewModel agreementViewModel)
        {
            if (ModelState.IsValid)
            {
                _agreementService.SaveAgreement(_mapperToBysinessModel.Map(agreementViewModel));
            }
            else
            {
                return View(agreementViewModel);
            }

            return RedirectToAction(nameof(AgreementManager));
        }


        public ActionResult Edit(int id = 1)
        {
            return View(_mapperToViewModel.Map(_agreementService.GetAgreement(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgreementViewModel agreementViewModel)
        {
            if (ModelState.IsValid)
            {
                _agreementService.UpdateAgreement(_mapperToBysinessModel.Map(agreementViewModel));
            }
            else
            {
                return View(agreementViewModel);
            }
            return RedirectToAction(nameof(AgreementManager));
        }

        //// GET: CustomerController/Delete/5
        //ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(CustomerManager));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
