using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.Services.Tasks.Write.Infrastructure.CrossCutting.DI
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
            services.AddInfrastructureModule(configuration);

            services.AddApplicationModule();
        }
    }
}
