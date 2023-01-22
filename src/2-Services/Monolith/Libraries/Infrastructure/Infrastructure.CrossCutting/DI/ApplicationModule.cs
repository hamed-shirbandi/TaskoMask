using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Services;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.DI
{
    internal static class ApplicationModule
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddBuildingBlocksApplication(validatorAssemblyMarkerType: typeof(ApplicationModule));

            services.AddApplicationServices();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUserAccessManagementService, UserAccessManagementService>();
        }
    }
}
