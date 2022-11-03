using Microsoft.AspNetCore.Authentication;

namespace TaskoMask.Services.Identity.Api.Extensions
{
    public static class IdentityServerExtensions
    {
        /// <summary>
        /// Determines if the authentication scheme support signout.
        /// </summary>
        public static async Task<bool> GetSchemeSupportsSignOut(this HttpContext context, string scheme)
        {
            var provider = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            var handler = await provider.GetHandlerAsync(context, scheme);
            return (handler is IAuthenticationSignOutHandler);
        }
    }
}
