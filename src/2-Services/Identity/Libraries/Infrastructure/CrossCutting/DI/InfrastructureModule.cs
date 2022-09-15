using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.Services.Identity.Infrastructure.Data.DataProviders;

namespace TaskoMask.Services.Identity.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    internal static class InfrastructureModule
    {

  
        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddBuildingBlocksInfrastructureServices();
        }




        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            serviceProvider.InitialDatabase();
            serviceProvider.SeedEssentialData();
        }

    }
}
