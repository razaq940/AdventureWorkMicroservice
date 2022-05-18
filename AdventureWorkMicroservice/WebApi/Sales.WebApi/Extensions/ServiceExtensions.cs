using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Contracts;
using Sales.Entities.Models;
using Sales.LoggerService;
using Sales.Repository;
using Sales.Repository.Models;

namespace Sales.WebApi.Extensions
{
    public static class ServiceExtensions 
    {
        public static void ConfigureCors(this IServiceCollection service) =>
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        // add IIS configure options deploy to ISS
        public static void ConfigureIISIntegration(this IServiceCollection service) =>
            service.Configure<IISOptions>(options =>
            {

            });

        //create a service once per request
        public static void ConfigureLoggerService(this IServiceCollection service) =>
            service.AddScoped<ILoggerManager, LoggerManager>();

        //config to db
        public static void ConfigureDbContext(this IServiceCollection service, IConfiguration configuration) =>
            service.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("development")
            ));

        public static void ConfigureRepositoryManager(this IServiceCollection service) =>
            service.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureAddEditSalesPersonService(this IServiceCollection service) =>
            service.AddScoped<IAddEditSalesPersonService, AddEditSalesPersonService>();
        public static void ConfigureCartItemCreateOrderService(this IServiceCollection service) =>
            service.AddScoped<ICartItemCreateOrderService, CartItemCreateOrderService>();
        public static void ConfigureProductOnSaleService(this IServiceCollection service) =>
            service.AddScoped<IProductOnSaleService, ProductOnSaleService>();
    }
}
