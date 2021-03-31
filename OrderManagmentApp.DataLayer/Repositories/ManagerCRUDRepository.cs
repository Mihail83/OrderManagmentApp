using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OrderManagmentApp.DataLayer.EF;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Repositories
{
    class ManagerCRUDRepository : IGenericCrudRepository<ManagerEntity>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ManagerEntity> _dbSet;
        public ManagerCRUDRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<ManagerEntity>();

        }
        public void Add(ManagerEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ManagerEntity { Id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<ManagerEntity> GetAllByExpression(IEnumerable<Expression<Func<ManagerEntity, bool>>> expressions = null)
        {
            var managerEntity = new List<ManagerEntity>();

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

        public ManagerEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }       

        public void Update(ManagerEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
