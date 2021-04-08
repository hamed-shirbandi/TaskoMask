using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskoMask.Application.Resources;
using TaskoMask.Application.Services.Users;
using TaskoMask.Application.Queries.ViewMoldes.Account;
using TaskoMask.Domain.Models;
using TaskoMask.web.Area.Admin.Controllers;

namespace TaskoMask.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel input, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(input);

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, input.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                return RedirectToLocal(returnUrl);

            if (result.IsLockedOut)
                return RedirectToAction(nameof(Lockout));

            ModelState.AddModelError(nameof(LoginViewModel.Password), ApplicationMessages.User_Login_failed);
            return View(input);


        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _userService.CreateAsync(input);
            ValidateResult(result);

            return View(input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }


        #region Helpers


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
