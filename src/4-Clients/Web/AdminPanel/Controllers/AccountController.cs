using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Presentation.Framework.Web.Services.Authentication.CookieAuthentication;
using DNTCaptcha.Core;
using TaskoMask.Domain.Share.Models;
using AutoMapper;
using TaskoMask.Application.Membership.Operators.Services;
using TaskoMask.Application.Authorization.Users.Services;

namespace TaskoMask.Presentation.UI.AdminPanle.Controllers
{
    public class AccountController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;
        private readonly ICookieAuthenticationService _cookieAuthenticationService;
        private readonly IUserService _userService;

        #endregion

        #region Ctors



        public AccountController(IOperatorService ownerService, ICookieAuthenticationService cookieAuthenticationService, IMapper mapper, IUserService userService) : base(mapper)
        {
            _operatorService = ownerService;
            _cookieAuthenticationService = cookieAuthenticationService;
            _userService = userService;
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


            //validate user password
            var validateQueryResult = await _userService.IsValidCredentialAsync(input.UserName, input.Password);
            if (!validateQueryResult.IsSuccess)
                return View(validateQueryResult, input);

            //get operator
            var operatorQueryResult = await _operatorService.GetByUserNameAsync(input.UserName);
            if (!operatorQueryResult.IsSuccess)
                return View(operatorQueryResult, input);

            var user = _mapper.Map<AuthenticatedUser>(operatorQueryResult.Value);
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



        #endregion


    }
}
