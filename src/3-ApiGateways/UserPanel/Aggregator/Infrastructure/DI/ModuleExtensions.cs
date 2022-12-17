using TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetOrganizationsByOwnerId;
using TaskoMask.ApiGateways.UserPanel.Aggregator.Mapper;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.DI
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
            services.AddBuildingBlocksInfrastructure(configuration,consumerAssemblyMarkerType: typeof(Program),handlerAssemblyMarkerType: typeof(GetOrganizationsByOwnerIdHandler));

            services.AddBuildingBlocksApplication(validatorAssemblyMarkerType: typeof(Program));

            services.AddMapper(typeof(MappingProfile));

        }

    }
}
