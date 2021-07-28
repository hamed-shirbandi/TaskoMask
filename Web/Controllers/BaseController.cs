using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskoMask.Application.Core.Commands;

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
        protected void ValidateResult(CommandResult result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Value.SuccessMessage;
            else
                ViewBag.ErrorMessage = result.Error;
        }

    }
}