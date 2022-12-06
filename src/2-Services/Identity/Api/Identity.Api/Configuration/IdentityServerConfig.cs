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
           ApiScopesConfig.Owners_Read,
           ApiScopesConfig.Owners_Write,
           ApiScopesConfig.Boards_Read,
           ApiScopesConfig.Boards_Write,
           ApiScopesConfig.Tasks_Read,
           ApiScopesConfig.Tasks_Write,
        };



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           ApiResourcesConfig.Monolith_Api,
           ApiResourcesConfig.Owners_Api,
           ApiResourcesConfig.Boards_Api,
           ApiResourcesConfig.Tasks_Api,
           ApiResourcesConfig.Aggregator_Api
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
    static class ApiResourcesConfig
    {
        public static ApiResource Monolith_Api => new("monolith.api", "Monolith Api")
        {
            Scopes = { ApiScopesConfig.Monolith_Read.Name, ApiScopesConfig.Monolith_Write.Name }
        };


        public static ApiResource Owners_Api => new("owners.api", "Owners Api")
        {
            Scopes = { ApiScopesConfig.Owners_Read.Name, ApiScopesConfig.Owners_Write.Name }
        };


        public static ApiResource Boards_Api => new("boards.api", "Boards Api")
        {
            Scopes = { ApiScopesConfig.Boards_Read.Name, ApiScopesConfig.Boards_Write.Name }
        };

        public static ApiResource Tasks_Api => new("tasks.api", "Tasks Api")
        {
            Scopes = { ApiScopesConfig.Tasks_Read.Name, ApiScopesConfig.Tasks_Write.Name }
        };


        public static ApiResource Aggregator_Api => new("aggregator.api", "UserPanel ApiGateway Aggregator Api")
        {
            Scopes = { ApiScopesConfig.Owners_Read.Name, ApiScopesConfig.Boards_Read.Name, ApiScopesConfig.Tasks_Read.Name }
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
                ApiScopesConfig.Owners_Read.Name,
                ApiScopesConfig.Owners_Write.Name,
                ApiScopesConfig.Boards_Read.Name,
                ApiScopesConfig.Boards_Write.Name,
                ApiScopesConfig.Tasks_Read.Name,
                ApiScopesConfig.Tasks_Write.Name,
            },
            RedirectUris = { "https://localhost:5011/authentication/login-callback/" },
            PostLogoutRedirectUris = { "https://localhost:5011/authentication/logout-callback/" },
            ClientUri = "https://localhost:5011"
        };
    }




    /// <summary>
    /// 
    /// </summary>
    static class ApiScopesConfig
    {
        public static ApiScope Monolith_Read => new(name: "monolith.read", displayName: "Monolith Read APIs");
        public static ApiScope Monolith_Write => new(name: "monolith.write", displayName: "Monolith Write APIs");


        public static ApiScope Owners_Read => new(name: "owners.read", displayName: "Owners Read APIs");
        public static ApiScope Owners_Write => new(name: "owners.write", displayName: "Owners Write APIs");


        public static ApiScope Boards_Read => new(name: "boards.read", displayName: "Boards Read APIs");
        public static ApiScope Boards_Write => new(name: "boards.write", displayName: "Boards Write APIs");


        public static ApiScope Tasks_Read => new(name: "tasks.read", displayName: "Tasks Read APIs");
        public static ApiScope Tasks_Write => new(name: "tasks.write", displayName: "Tasks Write APIs");
    }

}