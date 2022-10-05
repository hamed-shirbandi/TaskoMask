using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;

namespace TaskoMask.Services.Identity.Api.Pages.Login
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        #region Fields

        private readonly IInMemoryBus _inMemoryBus;

        [BindProperty]
        public UserLoginRequest UserLoginRequest { get; set; }

        #endregion

        #region Ctors

        public Index(IInMemoryBus inMemoryBus)
        {
            _inMemoryBus = inMemoryBus;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public IActionResult OnGet(string returnUrl)
        {
            BuildModel(returnUrl);

            return Page();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return LoginFailed();

            var loginRespone = await _inMemoryBus.Send(UserLoginRequest);
            if (loginRespone.IsSuccess)
                return RedirectToReturnUrl(UserLoginRequest.ReturnUrl);

            return LoginFailed(loginRespone.Message);
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private IActionResult LoginFailed(string errorMessage = "")
        {
            BuildModel(UserLoginRequest.ReturnUrl);

            if (!string.IsNullOrEmpty(errorMessage))
                ModelState.AddModelError(string.Empty, errorMessage);

            return Page();
        }





        /// <summary>
        /// 
        /// </summary>
        private void BuildModel(string returnUrl)
        {
            UserLoginRequest = new UserLoginRequest
            {
                ReturnUrl = returnUrl
            };
        }



        private IActionResult RedirectToReturnUrl(string returnUrl)
        {
            return Redirect(string.IsNullOrEmpty(returnUrl)?"/":returnUrl);
        }

        #endregion
    }
}