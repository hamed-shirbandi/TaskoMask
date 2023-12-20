using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;
using TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.AspNetIdentity;
using TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Identity.Api.Infrastructure.Data.DbContext;
using TaskoMask.Services.Identity.Api.UseCases.RegisterUser;

namespace TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.DI;

/// <summary>
///
/// </summary>
public static class InfrastructureModule
{
    /// <summary>
    ///
    /// </summary>
    public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType)
    {
        services.AddBuildingBlocksInfrastructure(configuration, consumerAssemblyMarkerType, handlerAssemblyMarkerType: typeof(RegisterUserUseCase));

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
