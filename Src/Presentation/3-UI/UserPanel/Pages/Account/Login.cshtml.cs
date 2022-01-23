using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.Presentation.UI.UserPanel.Services.Authentication;
using TaskoMask.Application.Share.Dtos.Authorization.Users;

namespace TaskoMask.Presentation.UI.UserPanel.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [BindProperty]
        public UserLoginDto Input { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public async Task OnGetAsync()
        {
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            var returnUrl = Url.Content("~/");

            if (!ModelState.IsValid)
                return Page();

            var loginResult = await _authenticationService.Login(Input);
            
            if (loginResult.IsSuccess)
                return LocalRedirect(returnUrl);

            ModelState.AddModelError(nameof(UserLoginDto.RememberMe), loginResult.Message);
            return Page();
        }
    }
}
