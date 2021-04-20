using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Linq.Expressions;
using OrderManagmentApp.BusinessLogic.FilteringExtensions;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class ManagerService
    {
        private readonly IGenericCrudRepository<Manager> _managerRepository;        

        public ManagerService(IGenericCrudRepository<Manager> managerRepository)
        {
            _managerRepository = managerRepository;
        }
        
        public IEnumerable<Manager> GetManagers(IEnumerable<Expression<Func<Manager, bool>>> expressions = null)
        {
            var managers =  _managerRepository.GetAllByExpression(expressions);
            //List<Manager> result = managers == null ? null : new List<Manager>(managers);    // need List???? or Enumerable
            return managers;        
        }
        public void CreateManager(Manager manager)
        {
            _managerRepository.Add(manager);
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NullReferenceExeption, sqlExeption"> </exception>
        public void ToggleBlock(Manager entity)
        {
            entity.IsDismissed = !entity.IsDismissed;

            _managerRepository.Update(entity);
        }
        public Manager GetManagerById(int id)
        {
            return _managerRepository.GetById(id);
        }
    }
}
