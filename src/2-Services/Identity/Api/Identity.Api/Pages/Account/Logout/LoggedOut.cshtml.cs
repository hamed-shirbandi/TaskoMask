using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskoMask.Services.Identity.Api.Pages.Account.Logout
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class LoggedOut : PageModel
    {
        private readonly IIdentityServerInteractionService _interactionService;


        public LoggedOut(IIdentityServerInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        public async Task<IActionResult> OnGet(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interactionService.GetLogoutContextAsync(logoutId);
            var postLogoutRedirectUri = logout?.PostLogoutRedirectUri;

            return Redirect(postLogoutRedirectUri??"/");
        }
    }
}