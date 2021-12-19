using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;
using DNTCaptcha.Core;
using TaskoMask.Domain.Share.Models;
using AutoMapper;
using TaskoMask.Application.Administration.Operators.Services;

namespace TaskoMask.Presentation.UI.AdminPanle.Controllers
{
    public class AccountController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;
        private readonly ICookieAuthenticationService _cookieAuthenticationService;

        #endregion

        #region Ctors



        public AccountController(IOperatorService memberService, ICookieAuthenticationService cookieAuthenticationService, IMapper mapper) : base(mapper)
        {
            _operatorService = memberService;
            _cookieAuthenticationService = cookieAuthenticationService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
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
        public async Task<IActionResult> Login(UserLoginDto input, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(input);


            //get user
            var userQueryResult = await _operatorService.GetBaseUserByUserNameAsync(input.Email);
            if (!userQueryResult.IsSuccess)
                return View(userQueryResult, input);


            //validate user password
            var validateQueryResult = await _operatorService.ValidateUserPasswordAsync(input.Email, input.Password);
            if (!validateQueryResult.IsSuccess)
                return View(validateQueryResult, input);

            var user = _mapper.Map<AuthenticatedUser>(userQueryResult.Value);
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
                return RedirectToAction(actionName: "index", controllerName: "Dashboard", routeValues: new { Area = "Administration" });
        }



        #endregion


    }
}
