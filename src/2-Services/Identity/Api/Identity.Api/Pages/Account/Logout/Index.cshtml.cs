using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Pages.Logout
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        private readonly SignInManager<User> _signInManager;


        public Index(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> OnGet( )
        {
            return await OnPost();
        }

        public async Task<IActionResult> OnPost()
        {
            // delete local authentication cookie
            await _signInManager.SignOutAsync();
            return SignOut();
        }
    }
}