using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Linq.Expressions;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class ManagerService
    {
        private readonly IGenericCrudRepository<Manager> _managerRepository;        

        public ManagerService(IGenericCrudRepository<Manager> managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public List<Manager> GetManagers(IEnumerable<Expression<Func<Manager, bool>>> expressions = null)
        {
            var managers =  _managerRepository.GetAllByExpression(expressions);
            List<Manager> result = managers == null ? null : new List<Manager>(managers);
            return result;        
        }





    }
}
