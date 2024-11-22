using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.DbContext;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.Repositories;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.Services;

namespace TaskoMask.Services.Tasks.Write.Api.Infrastructure.CrossCutting.DI;

/// <summary>
///
/// </summary>
public static class InfrastructureModule
{
    /// <summary>
    ///
    /// </summary>
    public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBuildingBlocksInfrastructure(
            configuration,
            typeof(Program),
            handlerAssemblyMarkerType: typeof(Program),
            validatorAssemblyMarkerType: typeof(Program)
        );

        services.AddMongoDbContext(configuration);

        services.AddDomainServices();

        services.AddRepositories();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("MongoDB");
        services.AddScoped<TaskWriteDbContext>().AddOptions<MongoDbOptions>().Bind(options);
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ITaskValidatorService, TaskValidatorService>();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITaskAggregateRepository, TaskAggregateRepository>();
    }
}
