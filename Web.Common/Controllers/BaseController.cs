using TaskoMask.Domain.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskoMask.Application.Core.Commands;
using AutoMapper;
using TaskoMask.Web.Common.Helpers;
using TaskoMask.Web.Common.Models;

namespace TaskoMask.Web.Common.Controllers
{
    public class BaseController : Controller
    {
        #region Fields

        protected readonly IMapper _mapper;

        #endregion

        #region Ctors

        public BaseController()
        {
        }


        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserName()
        {
            if (this.User == null)
                return "";

            return this.User.Identity.Name ?? "";
        }



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserId()
        {
            if (this.User == null)
                return "";
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            return userId;
        }



        /// <summary>
        /// use this when an ajax made the command request and you want to show an alert message on the view by js
        /// </summary>
        protected JavaScriptResult AjaxResult(Result<CommandResult> cmdResult, bool reloadPage = false, string redirectUrl = "")
        {
            if (!cmdResult.IsSuccess)
                return ScriptBox.ShowMessage(string.Join("<br/>", cmdResult.Errors.ToArray()), MsgType.error);

            if (reloadPage)
                return ScriptBox.ReloadPage();


            if (!string.IsNullOrEmpty(redirectUrl))
                return ScriptBox.RedirectToUrl(url: redirectUrl.Replace("EntityId", cmdResult.Value.EntityId));

            return ScriptBox.ShowMessage(cmdResult.Message, MsgType.success);
        }



        /// <summary>
        /// use this when a http post call made the command request
        /// </summary>
        protected IActionResult View<T>(Result<CommandResult> result, T model)
        {
            CreateMessageViewBags(result);

            return View(model);
        }



        /// <summary>
        /// use this when a http post call made the query request
        /// </summary>
        protected IActionResult View<T,E>(Result<T> result, E model)
        {
            CreateMessageViewBags(result);

            return View(model);
        }





        /// <summary>
        /// return data to view if result is success
        /// return redirect to error page if result is failed
        /// </summary>
        protected IActionResult View<T>(Result<T> queryResult)
        {
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            return View(queryResult.Value);
        }



        /// <summary>
        /// return mapped data to view if result is success
        /// return redirect to error page if result is failed
        /// </summary>
        protected IActionResult View<T, E>(Result<T> queryResult)
        {
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            var model = _mapper.Map<E>(queryResult.Value);
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        protected IActionResult RedirectToErrorPage<T>(Result<T> queryResult)
        {
            var model = new ErrorViewModel
            {
                Message = queryResult.Message,
                Errors = queryResult.Errors,
            };

            return View(viewName: "KnownError", model: model);
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// Adding application service result message to SuccessMessage or ErrorMessage ViewBags to show in DomainValidationSummary component
        /// </summary>
        private void CreateMessageViewBags<T>(Result<T> result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Message;
            else
                ViewBag.ErrorMessage = result.Message;
        }



        #endregion

    }
}