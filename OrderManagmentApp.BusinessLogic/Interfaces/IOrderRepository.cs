using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace OrderManagmentApp.BusinessLogic.Interfaces
{
    public interface IOrderRepository : IGenericCrudRepository<Order>
    {
        public IEnumerable<Order> GetAllOrdersNoArchive(IEnumerable<Expression<Func<Order, bool>>> predicates = null);
    }
}
