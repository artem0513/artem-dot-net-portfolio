using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DotNetExample.Mappings
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddAutoMapperMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
