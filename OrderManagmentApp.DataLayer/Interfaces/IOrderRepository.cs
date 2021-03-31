using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Interfaces
{
    public interface IOrderRepository : IGenericCrudRepository<OrderEntity>
    {
        public IEnumerable<OrderEntity> GetAllOrdersNoArchive();
    }
}
