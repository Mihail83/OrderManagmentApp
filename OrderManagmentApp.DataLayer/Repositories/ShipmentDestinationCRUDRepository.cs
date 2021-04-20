using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Repositories
{
    public class ShipmentDestinationCRUDRepository : IGenericCrudRepository<ShipmentDestination>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ShipmentDestination> _dbSet;
        public ShipmentDestinationCRUDRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<ShipmentDestination>();

        }
        public void Add(ShipmentDestination entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ShipmentDestination { Id = id });
            _dbContext.SaveChanges();
        }

        public IQueryable<ShipmentDestination> GetAllByExpression(IEnumerable<Expression<Func<ShipmentDestination, bool>>> expressions = null)
        {
            var shipmentDestinationEntities = _dbSet.AsNoTracking();
            
            return shipmentDestinationEntities.UseExpresionsList(expressions);
        }

        public ShipmentDestination GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }

        public void Update(ShipmentDestination entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
