using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mediator;

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
        public static void AddModules(this IServiceCollection services)
        {
            services.AddApplicationModule();

            services.AddInfrastructureModule();

            services.AddAutoMapper();

            services.AddMediator();
        }


    }
}
