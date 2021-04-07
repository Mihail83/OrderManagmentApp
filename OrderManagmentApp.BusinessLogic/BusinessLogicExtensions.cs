using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;



namespace OrderManagmentApp.BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogicService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<OrderService>();            
            services.AddScoped<CustomerService>();
            services.AddScoped<AgreementService>();

            services.AddScoped<ManagerService>();
            services.AddScoped<ShipmentSpecialistService>();
            services.AddScoped<ShipmentDestinationService>();
            

            return services;
        }
    }
}
