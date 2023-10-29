using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Boards.Write.Api.Resources;

namespace TaskoMask.Services.Boards.Write.Api.Infrastructure.CrossCutting.DI
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
