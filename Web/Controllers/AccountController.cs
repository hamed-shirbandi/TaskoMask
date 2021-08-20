using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Users.Services;
using TaskoMask.Application.Core.ViewMoldes.Users;
using TaskoMask.Web.Area.Admin.Controllers;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Web.Common.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskoMask.Web.Common.Services.Authentication.CookieAuthentication;

namespace TaskoMask.Web.Controllers
{
    //TODO adding forget password- 2fa - external login
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
            await _cookieAuthenticationService.SignOutAsync();

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel input, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(input);

           
            //get user
            var userQueryResult = await _userService.GetByUserNameAsync(input.Email);
            if (!userQueryResult.IsSuccess)
                return View(userQueryResult,input);


            //validate user password
            var validateQueryResult = await _userService.ValidateUserPasswordAsync(input.Email,input.Password);
            if (!validateQueryResult.IsSuccess)
                return View(userQueryResult, input);

            await _cookieAuthenticationService.SignInAsync(userQueryResult.Value, isPersistent: true);

            return RedirectToLocal(returnUrl);
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
            await _cookieAuthenticationService.SignOutAsync();
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
