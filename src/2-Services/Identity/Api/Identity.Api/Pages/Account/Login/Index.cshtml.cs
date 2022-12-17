using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Web.MVC.Pages;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;

namespace TaskoMask.Services.Identity.Api.Pages.Account.Login
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : BasePageModel
    {
        #region Fields

        private readonly IIdentityServerInteractionService _interactionService;

        [BindProperty]
        public InputModel Input { get; set; }

        #endregion

        #region Ctors

        public Index(IInMemoryBus inMemoryBus, IIdentityServerInteractionService interactionService) : base(inMemoryBus)
        {
            _interactionService = interactionService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnGet(string returnUrl)
        {
            await BuildModelAsync(returnUrl);

            return Page();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return await LoginFailedAsync();

            var loginRespone = await _inMemoryBus.SendQuery(new UserLoginRequest(Input.UserName, Input.Password, Input.RememberLogin));
            if (loginRespone.IsSuccess)
                return RedirectToReturnUrl(Input.ReturnUrl);

            return await LoginFailedAsync(loginRespone.Errors);
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<IActionResult> LoginFailedAsync(IEnumerable<string> errors=null)
        {
            await BuildModelAsync(Input.ReturnUrl);

            foreach (var error in errors?? Enumerable.Empty<string>())
                ModelState.AddModelError(string.Empty, error);

            return Page();
        }





        /// <summary>
        /// 
        /// </summary>
        private async Task BuildModelAsync(string returnUrl)
        {
            var context = await _interactionService.GetAuthorizationContextAsync(returnUrl);
            ViewData["ClientUri"] = context?.Client.ClientUri;

            Input = new InputModel
            {
                ReturnUrl = returnUrl
            };
        }



        private IActionResult RedirectToReturnUrl(string returnUrl)
        {
            return Redirect(returnUrl ?? "/");
        }

        #endregion
    }
}