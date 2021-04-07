using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.Repositories;

namespace OrderManagmentApp.DataLayer
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection AddDataLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderManagmentAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultLocalConnection")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGenericCrudRepository<Manager>, ManagerCRUDRepository>();
            services.AddScoped<IGenericCrudRepository<ShipmentDestination>, ShipmentDestinationCRUDRepository>();
            services.AddScoped<IGenericCrudRepository<ShipmentSpecialist>, ShipmentSpecialistCRUDRepository>();
            services.AddScoped<IOrderAgreementRepository, OrderAgreementRepository>();           


            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();
            services.AddScoped<IOrderInFactoryRepository, OrderInFactoryRepository>();


            return services;
        }
    }
}
