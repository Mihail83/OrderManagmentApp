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
    public class ShipmentSpecialistCRUDRepository : IGenericCrudRepository<ShipmentSpecialistEntity>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ShipmentSpecialistEntity> _dbSet;
        public ShipmentSpecialistCRUDRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<ShipmentSpecialistEntity>();

        }
        public void Add(ShipmentSpecialistEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ShipmentSpecialistEntity { Id = id });
        }

        public IEnumerable<ShipmentSpecialistEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public ShipmentSpecialistEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ShipmentSpecialistEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
