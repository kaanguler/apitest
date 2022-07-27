using API.Core.Interface;
using API.Infrastructure.Implements;

namespace API.Extentions
{
    public static class ApplicationServiceExtentions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            return services;
        }

      
    }
}
