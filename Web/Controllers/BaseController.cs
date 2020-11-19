using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskoMask.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserName()
        {
            if (this.User != null)
                return this.User.Identity.Name;

            return "";
        }



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserId()
        {
            if (this.User != null)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(userId))
                    return userId;
            }

            return "";

        }



        /// <summary>
        /// 
        /// </summary>
        protected void ValidateResult(Result<string> result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Value;
            else
                ViewBag.ErrorMessage = result.Error;
        }

    }
}