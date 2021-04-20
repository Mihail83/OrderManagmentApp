using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace OrderManagmentApp.Infrastructure
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TResult> UseExpresionsList<TResult>(this IQueryable<TResult> query, IEnumerable<Expression<Func<TResult, bool>>> expressions) 
        {
            if (expressions!=null)
            {
                foreach (var expression in expressions)
                {
                    query = query.Where(expression);
                }
            }
            return query;
        }
    }
}
