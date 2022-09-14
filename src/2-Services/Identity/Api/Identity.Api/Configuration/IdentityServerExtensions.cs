using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Configuration
{
    internal static class IdentityServerExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddIdentityServer(this IServiceCollection services )
        {
            services.AddIdentityServer(options =>
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
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddAspNetIdentity<User>();
        }
    }
}
