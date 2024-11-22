using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.Mapper;

namespace TaskoMask.Services.Tasks.Read.Api.Infrastructure.DI;

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

        services.AddMongoDbContext(configuration);
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("MongoDB");
        services.AddScoped<TaskReadDbContext>().AddOptions<MongoDbOptions>().Bind(options);
    }
}
