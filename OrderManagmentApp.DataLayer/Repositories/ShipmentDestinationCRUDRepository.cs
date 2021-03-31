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
    public class ShipmentDestinationCRUDRepository : IGenericCrudRepository<ShipmentDestinationEntity>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ShipmentDestinationEntity> _dbSet;
        public ShipmentDestinationCRUDRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<ShipmentDestinationEntity>();

        }
        public void Add(ShipmentDestinationEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ShipmentDestinationEntity { Id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<ShipmentDestinationEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public ShipmentDestinationEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent=>ent.Id==id);
        }

        public void Update(ShipmentDestinationEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }      
    }
}
