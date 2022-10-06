
namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Jwt
{
    public class JwtOptions
    {
        public string Authority { get; set; }
        public string Audience { get; set; }
        public IEnumerable<AuthorizationPolicy> Policies { get; set; }
    }

    public class AuthorizationPolicy
    {
        public string Name { get; set; }
        public bool RequireAuthenticatedUser { get; set; }
        public string[] AllowedScopes { get; set; }
    }
}
