using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskoMask.Application.Core.Commands;
using System.Threading.Tasks;
using TaskoMask.Web.Controllers;
using TaskoMask.web.Models;
using TaskoMask.Application.Core.Services;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Web.Helpers;

namespace TaskoMask.web.Area.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly IBaseApplicationService _baseApplicationService;

        public BaseController(IBaseApplicationService baseApplicationService)
        {
            _baseApplicationService = baseApplicationService;
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
        /// use this when an ajax call made the command request and you want to show an alert message on the view by js
        /// </summary>
        protected async Task<JavaScriptResult> AjaxSendCommandAsync<T>(T cmd, bool reloadPage = false, string redirectUrl = "") where T : BaseCommand
        {
            var cmdResult = await _baseApplicationService.SendCommandAsync(cmd);
            if (!cmdResult.IsSuccess)
                return ScriptBox.ShowMessage(string.Join("<br/>", cmdResult.Errors.ToArray()), MsgType.error);

            if (reloadPage)
                return ScriptBox.ReloadPage();


            if (!string.IsNullOrEmpty(redirectUrl))
                return ScriptBox.RedirectToUrl(url: redirectUrl.Replace("EntityId", cmdResult.Value.EntityId));

            return ScriptBox.ShowMessage(cmdResult.Message, MsgType.success);
        }





        /// <summary>
        /// use this when an http post call made the command request or when you need to have command result to continue processing
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand
        {
            var cmdResult = await _baseApplicationService.SendCommandAsync(cmd);
            if (!cmdResult.IsSuccess)
                ValidateCommandResult(cmdResult);
            return cmdResult;
        }





        /// <summary>
        /// Adding command result message to show in DomainValidationSummary component
        /// </summary>
        protected void ValidateCommandResult(Result<CommandResult> result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Message;
            else
                ViewBag.ErrorMessage = result.Message;
        }



        /// <summary>
        /// use this when you just need get data and directly send it to view as view model
        /// </summary>
        protected async Task<IActionResult> SendQueryAndReturnViewAsync<T>(IRequest<T> query)
        {
            var queryResult = await _baseApplicationService.SendQueryAsync(query);
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            return View(queryResult.Value);

        }




        /// <summary>
        /// use this when you just need get data and pass it to caller to continue processing
        /// </summary>
        protected async Task<Result<T>> SendQueryAsync<T>(IRequest<T> query)
        {
            return await _baseApplicationService.SendQueryAsync(query);
        }


      

        protected IActionResult RedirectToErrorPage<T>(Result<T> result)
        {
            var model = new ErrorViewModel
            {
                Message = result.Message,
                Errors = result.Errors.ToArray(),
            };

            return View(viewName: "KnownError", model: model);
        }


    }
}