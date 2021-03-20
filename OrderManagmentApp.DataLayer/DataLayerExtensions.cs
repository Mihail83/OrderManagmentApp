using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.DataLayer.EntityModels;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.Repositories;

namespace OrderManagmentApp.DataLayer
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection AddDataLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderManagmentAppContext>(options=>options.UseSqlServer(configuration.GetConnectionString("defaultLocalConnection")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGenericCrudRepository<ManagerEntity>, ManagerCRUDRepository>();
            services.AddScoped<IGenericCrudRepository<ShipmentDestinationEntity>, ShipmentDestinationCRUDRepository>();
            services.AddScoped<IGenericCrudRepository<ShipmentSpecialistEntity>, ShipmentSpecialistCRUDRepository>();

            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITreatyRepository, TreatyRepository>();
            services.AddScoped<IOrderInALutehRepository, OrderInALutehRepository>();

            return services;
        }
    }
}
