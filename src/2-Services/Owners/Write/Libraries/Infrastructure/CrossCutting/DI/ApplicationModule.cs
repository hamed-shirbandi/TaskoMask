using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;

namespace TaskoMask.Services.Owners.Write.Infrastructure.CrossCutting.DI
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
            services.AddBuildingBlocksApplication(validatorAssemblyMarkerType: typeof(RegiserOwnerValidation<>));

        }


    }
}
