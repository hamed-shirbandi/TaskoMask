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
using TaskoMask.web.Area.Admin.Models;
using TaskoMask.Application.Core.Queries;
using System;
using AutoMapper;

namespace TaskoMask.web.Area.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly IBaseApplicationService _baseApplicationService;
        protected readonly IMapper _mapper;

        public BaseController(IBaseApplicationService baseApplicationService, IMapper mapper)
        {
            _baseApplicationService = baseApplicationService;
            _mapper = mapper;
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
        /// use when you just need get data and directly send it to view as view model
        /// </summary>
        protected async Task<IActionResult> SendQueryAndReturnDataToViewAsync<T>(BaseQuery<T> query)
        {
            var queryResult = await SendQueryAsync(query);
            return ReturnDataToViewAsync(queryResult);
        }



      


        /// <summary>
        /// use when you need to map data beafor return it to view
        /// </summary>
        /// <typeparam name="T">type of data returned by query</typeparam>
        /// <typeparam name="E">type of model to map from T</typeparam>
        protected async Task<IActionResult> SendQueryAndReturnMappedDataToViewAsync<T, E>(BaseQuery<T> query)
        {
            var queryResult = await SendQueryAsync(query);
            return ReturnMappedDataToViewAsync<T, E>(queryResult);
        }




        /// <summary>
        /// use this when you just need get data and pass it to caller to continue processing
        /// </summary>
        protected async Task<Result<T>> SendQueryAsync<T>(BaseQuery<T> query)
        {
            return await _baseApplicationService.SendQueryAsync(query);
        }



        /// <summary>
        /// return data to view if result is success
        /// return redirect to error page if result is failed
        /// </summary>
        protected IActionResult ReturnDataToViewAsync<T>(Result<T> queryResult)
        {
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            return View(queryResult.Value);
        }




        /// <summary>
        /// return mapped data to view if result is success
        /// return redirect to error page if result is failed
        /// </summary>
        protected IActionResult ReturnMappedDataToViewAsync<T,E>(Result<T> queryResult)
        {
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            var model = _mapper.Map<E>(queryResult.Value);
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
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