using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Tasks.Write.Application.Resources;

namespace TaskoMask.Services.Tasks.Write.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    internal static class ApplicationModule
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddBuildingBlocksApplication(validatorAssemblyMarkerType: typeof(ApplicationMessages));

        }


    }
}
