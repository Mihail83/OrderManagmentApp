using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Repositories
{
    class ManagerCRUDRepository : IGenericCrudRepository<Manager>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Manager> _dbSet;
        public ManagerCRUDRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Manager>();

        }
        public void Add(Manager entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new Manager { Id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<Manager> GetAllByExpression(IEnumerable<Expression<Func<Manager, bool>>> expressions = null)
        {
            var managerEntity = new List<Manager>();

            if (expressions == null)
            {
                managerEntity.AddRange(_dbSet.AsNoTracking());
            }
            else
            {
                throw new NotImplementedException(GetType().ToString());
            }
            return managerEntity;
        }

        public Manager GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }

        public void Update(Manager entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
