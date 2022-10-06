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
           ApiScopesConfig.Monolith_Read,
           ApiScopesConfig.Monolith_Write,
        };



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           ApiResourcesConfig.Monolith_Api,
        };



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Client> Clients => new Client[]
        {
            ClientsConfig.UserPanel,
        };
    }



    /// <summary>
    /// 
    /// </summary>
    static class ApiScopesConfig
    {
        public static ApiScope Monolith_Read => new(name: "monolith.read", displayName: "Monolith Read APIs");
        public static ApiScope Monolith_Write => new(name: "monolith.write", displayName: "Monolith Write APIs");

    }



    /// <summary>
    /// 
    /// </summary>
    static class ApiResourcesConfig
    {
        public static ApiResource Monolith_Api => new("monolith.api", "Monolith Api")
        {
            Scopes = { ApiScopesConfig.Monolith_Read.Name, ApiScopesConfig.Monolith_Write.Name }
        };

    }



    /// <summary>
    /// 
    /// </summary>
    static class ClientsConfig
    {

        public static Client UserPanel => new()
        {
            ClientId = "UserPanel",
            AllowedGrantTypes = GrantTypes.Code,
            RequirePkce = true,
            RequireClientSecret = false,
            AllowedCorsOrigins = { "https://localhost:5011" },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                ApiScopesConfig.Monolith_Read.Name,
                ApiScopesConfig.Monolith_Write.Name,
            },
            RedirectUris = { "https://localhost:5011/authentication/login-callback/" },
            PostLogoutRedirectUris = { "https://localhost:5011/authentication/logout-callback/" },
            ClientUri= "https://localhost:5011"
        };

    }
}