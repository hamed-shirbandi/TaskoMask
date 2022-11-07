using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.Services.Identity.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class ModuleExtensions
    {

  
        /// <summary>
        /// 
        /// </summary>
        public static void AddModules(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType)
        {
            services.AddInfrastructureModule(configuration, consumerAssemblyMarkerType);

            services.AddApplicationModule();
        }
    }
}
