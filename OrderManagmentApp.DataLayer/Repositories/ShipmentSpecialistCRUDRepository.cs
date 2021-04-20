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
    public class ShipmentSpecialistCRUDRepository : IGenericCrudRepository<ShipmentSpecialist>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ShipmentSpecialist> _dbSet;
        public ShipmentSpecialistCRUDRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<ShipmentSpecialist>();

        }
        public void Add(ShipmentSpecialist entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ShipmentSpecialist { Id = id });
            _dbContext.SaveChanges();
        }

        public IQueryable<ShipmentSpecialist> GetAllByExpression(IEnumerable<Expression<Func<ShipmentSpecialist, bool>>> expressions = null)
        {
            var shipmentSpecialistEntities = _dbSet.AsNoTracking();            
            return shipmentSpecialistEntities.UseExpresionsList(expressions);
        }

        public ShipmentSpecialist GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }

        public void Update(ShipmentSpecialist entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
