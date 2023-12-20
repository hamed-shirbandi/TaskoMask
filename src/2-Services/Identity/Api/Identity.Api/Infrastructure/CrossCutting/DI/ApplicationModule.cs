using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Identity.Api.UseCases.UpdateUser;

namespace TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.DI;

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
        services.AddBuildingBlocksApplication(typeof(UpdateUserValidation<>));
    }
}
