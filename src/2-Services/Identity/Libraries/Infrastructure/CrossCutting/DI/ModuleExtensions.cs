using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mediator;
using TaskoMask.Services.Identity.Infrastructure.Data.DataProviders;

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
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationModule();

            services.AddInfrastructureModule(configuration);
        }
    }
}
