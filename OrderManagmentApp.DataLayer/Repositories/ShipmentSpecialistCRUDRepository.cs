﻿using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
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
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new ShipmentSpecialistEntity { Id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<ShipmentSpecialistEntity> GetAllByExpression(IEnumerable<Expression<Func<ShipmentSpecialistEntity, bool>>> expressions = null)
        {
            var managerEntity = new List<ShipmentSpecialistEntity>();

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

        public ShipmentSpecialistEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ent => ent.Id == id);
        }    

        public void Update(ShipmentSpecialistEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}