using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Presentation.UI.UserPanel.Helpers;
using TaskoMask.Presentation.UI.UserPanel.Services.Authentication;

namespace TaskoMask.Presentation.UI.UserPanel.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : BasePageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [BindProperty]
        public OwnerRegisterDto Input { get; set; }


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

            var registerResult = await _authenticationService.Register(Input);
            if (registerResult.IsSuccess)
                return LocalRedirect(returnUrl);

            ParseErrorsViewData(registerResult);

            return Page();
        }
    }
}
