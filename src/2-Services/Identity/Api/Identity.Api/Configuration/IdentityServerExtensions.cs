using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Identity.Api.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Configuration;

internal static class IdentityServerExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddPreConfiguredIdentityServer(this IServiceCollection services)
    {
        services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
            .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
            .AddInMemoryApiResources(IdentityServerConfig.ApiResources)
            .AddInMemoryClients(IdentityServerConfig.Clients)
            .AddAspNetIdentity<User>();
    }

    /// <summary>
    /// Determines if the authentication scheme support signout.
    /// </summary>
    public static async Task<bool> GetSchemeSupportsSignOut(this HttpContext context, string scheme)
    {
        var provider = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
        var handler = await provider.GetHandlerAsync(context, scheme);
        return handler is IAuthenticationSignOutHandler;
    }
}
