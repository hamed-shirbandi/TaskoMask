using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskoMask.Services.Identity.Api.Pages
{
    [AllowAnonymous]
    public class Index : PageModel
    {

        public void OnGet()
        {
        }
    }
}