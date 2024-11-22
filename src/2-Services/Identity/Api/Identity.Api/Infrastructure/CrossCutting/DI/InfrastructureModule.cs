using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;
using TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.AspNetIdentity;
using TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Identity.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.DI;

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
            consumerAssemblyMarkerType: typeof(Program),
            handlerAssemblyMarkerType: typeof(Program),
            validatorAssemblyMarkerType: typeof(Program)
        );

        services.AddMapper(typeof(MappingProfile));

        services.AddDbContext();

        services.AddAspNetIdentity(configuration);
    }

    /// <summary>
    ///
    /// </summary>
    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IdentityDbContext>();
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
