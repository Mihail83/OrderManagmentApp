using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace OrderManagmentApp.BusinessLogic.Interfaces
{
    public interface IOrderRepository : IGenericCrudRepository<Order>
    {
        public IQueryable<Order> GetOrdersNoArchive(IEnumerable<Expression<Func<Order, bool>>> predicates = null);
    }
}
