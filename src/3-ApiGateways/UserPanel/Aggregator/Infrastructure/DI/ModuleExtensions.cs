using TaskoMask.ApiGateways.UserPanel.Aggregator.Infrastructure.Mapper;
using TaskoMask.BuildingBlocks.Infrastructure;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Infrastructure.DI;

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
        services.AddBuildingBlocksInfrastructure(
            configuration,
            consumerAssemblyMarkerType: typeof(Program),
            handlerAssemblyMarkerType: typeof(Program),
            validatorAssemblyMarkerType: typeof(Program)
        );

        services.AddMapper(typeof(MappingProfile));
    }
}
