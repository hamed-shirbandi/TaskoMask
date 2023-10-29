using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace TaskoMask.Clients.UserPanel.Configuration;

public class IdentityServerAuthorizationHandler : AuthorizationMessageHandler
{
    public IdentityServerAuthorizationHandler(IConfiguration configuration, IAccessTokenProvider provider, NavigationManager navigationManager)
        : base(provider, navigationManager)
    {
        ConfigureHandler(
            authorizedUrls: new[] { configuration["Url:ApiGateway"] },
            scopes: configuration.GetSection("oidc:DefaultScopes").Get<string[]>()
        );
    }
}
