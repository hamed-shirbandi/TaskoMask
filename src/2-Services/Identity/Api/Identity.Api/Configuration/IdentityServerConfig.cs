using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace TaskoMask.Services.Identity.Api.Configuration
{
    internal static class IdentityServerConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope(name:"monolith.api",displayName:"Monolith Api")
        };



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Client> Clients => new Client[]
        {
            ClientsConfig.UserPanel,
            ClientsConfig.AdminPanel,
        };
    }


    static class ClientsConfig
    {

        public static Client UserPanel => new()
        {
            ClientId = "UserPanel",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedScopes = { "monolith.api" }
        };


        public static Client AdminPanel => new()
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
                "monolith.api"
            }
        };
    }
}