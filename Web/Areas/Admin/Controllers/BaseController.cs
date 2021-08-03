using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.web.Area.Admin.Controllers
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
        protected void ValidateCommandResult(Result<CommandResult> result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Value.Message;
            else
                ViewBag.ErrorMessage = string.Join("<br/>", result.Errors);
        }



        protected void ValidateQueryResult(Result result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Message;
            else
                ViewBag.ErrorMessage = result.Message;
        }


    }
}