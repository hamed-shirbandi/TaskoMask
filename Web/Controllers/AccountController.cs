using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Users.Services;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Web.Area.Admin.Controllers;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Web.Common.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskoMask.Web.Common.Services.Authentication;
using System.Security.Claims;

namespace TaskoMask.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly ICookieAuthenticationService _cookieAuthenticationService;

        #endregion

        #region Ctors


        public AccountController(IUserService userService, ICookieAuthenticationService cookieAuthenticationService)
        {
            _userService = userService;
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
            await _cookieAuthenticationService.SignOut();

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel input, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(input);

            var userQueryResult = await _userService.GetByUserNameAsync(input.Email);
            if (!userQueryResult.IsSuccess)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Email), ApplicationMessages.User_Login_failed);
                return View(input);
            }

            var result = await _cookieAuthenticationService.SignIn(userQueryResult.Value, isPersistent: true);
            if (result)
                return RedirectToLocal(returnUrl);

            ModelState.AddModelError(nameof(LoginViewModel.Password), ApplicationMessages.User_Login_failed);
            return View(input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmdResult = await _userService.CreateAsync(input);
            return View(cmdResult, input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");

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
                return RedirectToAction(actionName: nameof(DashboardController.Index), controllerName: "Dashboard", routeValues: new { Area = "admin" });
        }



        #endregion


    }
}
