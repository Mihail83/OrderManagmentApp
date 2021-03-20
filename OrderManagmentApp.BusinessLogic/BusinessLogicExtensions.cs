using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.DataLayer.EntityModels;
using OrderManagmentApp.DataLayer.Enums;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.Repositories;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.BusinessLogic.Services.MAP;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;


namespace OrderManagmentApp.BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogicService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMapper<OrderEntity, Order>, MapperOrderEntityToOrder>();
            // services.AddScoped<IMapper<Order,OrderEntity>, MapperOrderToOrderEntity>();
            services.AddScoped<OrderSupplier>();

            services.AddScoped<IMapper<OrderState, string>, MapperOrderStateToString>();
            services.AddScoped<IMapper<string, OrderState>, MapperStringToOrderState>();
            return services;
        }
    }
}
