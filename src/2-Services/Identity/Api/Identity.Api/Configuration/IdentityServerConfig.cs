using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace TaskoMask.Services.Identity.Api.Configuration
{
    internal static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope(name:"Owner.Api",displayName:"Owner Api")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="UserPanel",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "Owner.Api" }
            },

            new Client
            {
                ClientId = "AdminPanel",
                ClientSecrets = { new Secret("secret2".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5013/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5013/signout-callback-oidc" },
                AllowOfflineAccess = true,
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "Owner.Api"
                }
            }
        };
    }
}