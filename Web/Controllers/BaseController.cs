using TaskoMask.Domain.Core.Helpers;
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
        /// use this when a http post call made the request
        /// Adding command result message to SuccessMessage or ErrorMessage ViewBags to show in DomainValidationSummary component
        /// </summary>
        protected IActionResult View<T>(Result<CommandResult> result, T model)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Message;
            else
                ViewBag.ErrorMessage = result.Message;

            return View(model);
        }





    }
}