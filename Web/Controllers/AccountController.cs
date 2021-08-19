using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Users.Services;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Domain.Entities;
using TaskoMask.Web.Area.Admin.Controllers;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;

        #endregion

        #region Ctors


        public AccountController(SignInManager<User> signInManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
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
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
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
            await _signInManager.SignOutAsync();
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
