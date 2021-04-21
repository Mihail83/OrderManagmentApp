using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagmentApp.WEB.Controllers
{
    [Authorize(Roles ="admin")]
    public class ManagerController : Controller
    {
        private readonly ManagerService _managerService;
        private readonly IMapper<Manager, ManagerViewModel> _mapperToViewModel;
        private readonly IMapper<ManagerViewModel, Manager> _mapperToManager;
        public ManagerController
            (
                ManagerService managerService,
                IMapper<Manager, ManagerViewModel> mapperToViewModel,
                IMapper<ManagerViewModel, Manager > mapperToManager
            )
        {
            _managerService = managerService;
            _mapperToViewModel = mapperToViewModel;
            _mapperToManager = mapperToManager;
        }
        public IActionResult ManagerList()
        {
            var managerViewModels = new List<ManagerViewModel>();
            foreach (var manager in _managerService.GetManagers())
            {
                managerViewModels.Add(_mapperToViewModel.Map(manager));
            }             
            return View(managerViewModels);
        }

        /// <summary>
        ///  I try to learn how write summary properly
        /// </summary>
        /// <param name="managerViewModel"></param>
        ///  <returns>Json  =  bool</returns>        
        public JsonResult Create(string NewManagerName)
        {
            bool result = false;

            if (!string.IsNullOrWhiteSpace(NewManagerName) && NewManagerName.Length >1 )
            {
                //Expression<Func<Manager, bool>> expression = ;
                var exp = new Expression<Func<Manager, bool>>[]
                {
                    (manager) => manager.Name == NewManagerName
                };

                if (_managerService.GetManagers(exp).Count() == 0)
                {
                    _managerService.CreateManager(new Manager { Name = NewManagerName });
                    result = true;
                }
            }      
            return Json(result);
        }        
        public JsonResult ToggleBlock(int id)
        {
            var entity =  _managerService.GetManagerById(id);
            bool result = false;
            if (entity != null)
            {
                _managerService.ToggleBlock(entity);
                result = true;
            }
            return Json(result);
        }
    }
}
