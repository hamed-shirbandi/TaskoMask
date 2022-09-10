using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.CookieAuthentication;
using DNTCaptcha.Core;
using TaskoMask.BuildingBlocks.Contracts.Models;
using AutoMapper;
using TaskoMask.Services.Monolith.Application.Membership.Operators.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;

namespace TaskoMask.Clients.AdminPanle.Controllers
{
    public class AccountController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;
        private readonly ICookieAuthenticationService _cookieAuthenticationService;

        #endregion

        #region Ctors



        public AccountController(IOperatorService ownerService, ICookieAuthenticationService cookieAuthenticationService, IMapper mapper ) : base()
        {
            _operatorService = ownerService;
            _cookieAuthenticationService = cookieAuthenticationService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = "")
        {
            // Clear the existing external cookie to ensure a clean login process
            await _cookieAuthenticationService.SignOutAsync();

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }



        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(ErrorMessage = "Please enter the text inside the image numerically",
                    CaptchaGeneratorLanguage = Language.English,
                    CaptchaGeneratorDisplayMode = DisplayMode.NumberToWord)]
        public async Task<IActionResult> Login(UserLoginDto input, string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(input);


            //TODO validate user password through Identity service
            //var validateQueryResult = await _userService.IsValidCredentialAsync(input.UserName, input.Password);
            //if (!validateQueryResult.IsSuccess)
            //    return View(validateQueryResult, input);

            //get operator
            var operatorQueryResult = await _operatorService.GetByEmailAsync(input.UserName);
            if (!operatorQueryResult.IsSuccess)
                return View(operatorQueryResult, input);

            var user = GetAuthenticatedUserModel(operatorQueryResult.Value);
            await _cookieAuthenticationService.SignInAsync(user, isPersistent: input.RememberMe);

            return RedirectToLocal(returnUrl);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _cookieAuthenticationService.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }


        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(actionName: "index", controllerName: "Dashboard", routeValues: new { Area = "Membership" });
        }




        /// <summary>
        /// 
        /// </summary>
        private AuthenticatedUserModel GetAuthenticatedUserModel(OperatorBasicInfoDto owner)
        {
            return new AuthenticatedUserModel
            {
                Id = owner.Id,
                DisplayName = owner.DisplayName,
                Email = owner.Email,
                UserName = owner.Email,
            };
        }


        #endregion


    }
}
