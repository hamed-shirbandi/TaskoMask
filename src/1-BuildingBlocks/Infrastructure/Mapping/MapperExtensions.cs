using System;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Infrastructure.Mapping;

/// <summary>
///
/// </summary>
public static class MapperExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddMapper(this IServiceCollection services, Type mappingProfileAssemblyMarkerType)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        //this will find all profiles in mappingProfileAssemblyMarkerType assemply
        services.AddAutoMapper(mappingProfileAssemblyMarkerType);
        services.AddAutoMapper(typeof(CommonMappingProfile));
    }
}
