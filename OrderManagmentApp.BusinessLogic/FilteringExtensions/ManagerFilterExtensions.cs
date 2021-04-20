using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.Infrastructure.Enums;

namespace OrderManagmentApp.BusinessLogic.FilteringExtensions
{
    public static class ManagerFilterExtensions
    {
        public static IQueryable<Manager> FilterByName(this IQueryable<Manager> managers, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                managers =  managers.Where(manag=> manag.Name == name);
            }
            return managers;
        }
    }
}
