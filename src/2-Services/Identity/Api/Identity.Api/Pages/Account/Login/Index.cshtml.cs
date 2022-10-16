using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Web.MVC.Pages;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;

namespace TaskoMask.Services.Identity.Api.Pages.Login
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : BasePageModel
    {
        #region Fields

        private readonly IIdentityServerInteractionService _interactionService;

        [BindProperty]
        public UserLoginRequest UserLoginRequest { get; set; }

        #endregion

        #region Ctors

        public Index(IInMemoryBus inMemoryBus, IIdentityServerInteractionService interactionService, INotificationHandler notifications) :base(inMemoryBus, notifications)
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

            var loginRespone = await SendCommandAsync(UserLoginRequest);
            if (loginRespone.IsSuccess)
                return RedirectToReturnUrl(UserLoginRequest.ReturnUrl);

            return await LoginFailedAsync(loginRespone.Message);
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<IActionResult> LoginFailedAsync(string errorMessage = "")
        {
           await BuildModelAsync(UserLoginRequest.ReturnUrl);

            if (!string.IsNullOrEmpty(errorMessage))
                ModelState.AddModelError(string.Empty, errorMessage);

            return Page();
        }





        /// <summary>
        /// 
        /// </summary>
        private async Task BuildModelAsync(string returnUrl)
        {
            var context = await _interactionService.GetAuthorizationContextAsync(returnUrl);
            ViewData["ClientUri"] = context?.Client.ClientUri;

            UserLoginRequest = new UserLoginRequest
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