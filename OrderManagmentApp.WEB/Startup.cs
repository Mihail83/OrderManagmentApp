using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagmentApp.BusinessLogic;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.DataLayer;
using OrderManagmentApp.WEB.Models;
using OrderManagmentApp.WEB.Services.Map;

namespace OrderManagmentApp.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDataLayerService(Configuration);
            services.AddBusinessLogicService(Configuration);

            //services.AddScoped<IMapper<OrderState, string>, MapperOrderStateToString>();
            //services.AddScoped<IMapper<string, OrderState>, MapperStringToOrderState>();

            services.AddScoped<IMapper<Order, OrderViewModel>, MapperOrderTo_OrderViewModel>();

            services.AddScoped<IMapper<Customer, CustomerViewModel>, MapperCustomer_CustomerViewModel>();
            services.AddScoped<IMapper<CustomerViewModel, Customer>, MapperCustomerViewModel_Customer>();


            services.AddScoped<OrderService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=MainPage}/{id?}");
            });
        }
    }
}
