using Duende.IdentityServer.Events;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Pages.Login
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        #region Fields

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;

        [BindProperty]
        public InputModel Input { get; set; }

        #endregion

        #region Ctors

        public Index(IIdentityServerInteractionService interaction, IEventService events, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _events = events;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnGet(string returnUrl)
        {
            BuildModel(returnUrl);

            return Page();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnPost()
        {
            var context = await _interaction.GetAuthorizationContextAsync(Input.ReturnUrl);

            if (Input.Button == "cancel")
                return await LoginCanceledAsync(context);

            if (!ModelState.IsValid)
                return LoginFailed();

            var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberLogin, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                await _events.RaiseAsync(new UserLoginFailureEvent(Input.Username, "invalid credentials", clientId: context?.Client.ClientId));
                ModelState.AddModelError(string.Empty, ApplicationMessages.InvalidCredentialsErrorMessage);
                return LoginFailed();
            }

            var user = await _userManager.FindByNameAsync(Input.Username);
            await _userManager.AddLoginAsync(user, new UserLoginInfo("local", "local", "local"));
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.Client.ClientId));

            return RedirectToReturnUrl(context);
        }




        #endregion

        #region Private Methods




        /// <summary>
        /// 
        /// </summary>
        private IActionResult RedirectToReturnUrl(AuthorizationRequest context)
        {
            if (context != null)
            {
                if (context.IsNativeClient())
                    return this.LoadingPage(Input.ReturnUrl);

                return Redirect(Input.ReturnUrl);
            }

            if (Url.IsLocalUrl(Input.ReturnUrl))
                return Redirect(Input.ReturnUrl);
            else if (string.IsNullOrEmpty(Input.ReturnUrl))
                return Redirect("~/");
            else
                throw new Exception("invalid return URL");
        }



        /// <summary>
        /// 
        /// </summary>
        private IActionResult LoginFailed()
        {
            BuildModel(Input.ReturnUrl);
            return Page();
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IActionResult> LoginCanceledAsync(AuthorizationRequest context)
        {
            if (context == null)
                return Redirect("~/");

            await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
            if (context.IsNativeClient())
                return this.LoadingPage(Input.ReturnUrl);
            return Redirect(Input.ReturnUrl);
        }



        /// <summary>
        /// 
        /// </summary>
        private void BuildModel(string returnUrl)
        {
            Input = new InputModel
            {
                ReturnUrl = returnUrl
            };
        }


        #endregion
    }
}