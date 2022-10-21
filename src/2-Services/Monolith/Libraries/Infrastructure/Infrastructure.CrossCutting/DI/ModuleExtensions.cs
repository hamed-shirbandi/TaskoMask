using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class ModuleExtensions
    {

  
        /// <summary>
        /// 
        /// </summary>
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationModule();

            services.AddInfrastructureModule(configuration);

        }

    }
}
