using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OrderManagmentApp.DataLayer.EF;

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
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ManagerEntity { Id = id });
        }

        public IEnumerable<ManagerEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public ManagerEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ManagerEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
