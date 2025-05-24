using DotNetExample.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetExample.Business.Repositories
{
    public static class RepositoryResolver
    {
        public static void ResolveRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
