using Duende.IdentityServer.Events;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Pages.Login
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        #region Fields

        private readonly IMediator _mediator;

        [BindProperty]
        public UserLoginRequest UserLoginRequest { get; set; }

        #endregion

        #region Ctors

        public Index(IMediator mediator)
        {
            _mediator = mediator;
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

            var loginRespone = await _mediator.Send(UserLoginRequest);
            if (loginRespone.IsSuccess)
                return Redirect(UserLoginRequest.ReturnUrl);

            return LoginFailed(loginRespone.Message);
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private IActionResult LoginFailed(string errorMessage="")
        {
            BuildModel(UserLoginRequest.ReturnUrl);

            if (!string.IsNullOrEmpty(errorMessage))
                ModelState.AddModelError(string.Empty,errorMessage);

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


        #endregion
    }
}