using DotNetExample.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetExample.Business.Services
{
    public static class ServiceResolver
    {
        public static void ResolveServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
