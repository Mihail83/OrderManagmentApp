using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;



namespace OrderManagmentApp.BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
        {
            services.AddScoped<OrderService>();            
            services.AddScoped<CustomerService>();

            return services;
        }
    }
}
