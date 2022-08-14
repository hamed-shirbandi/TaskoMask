using TaskoMask.Services.Monolith.Application.Share.Helpers;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using AutoMapper;
using TaskoMask.BuildingBlocks.Web.MVC.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Models;
using TaskoMask.BuildingBlocks.Web.MVC.Enums;
using TaskoMask.Services.Monolith.Domain.Core.Services;
using System;

namespace TaskoMask.BuildingBlocks.Web.MVC.Controllers
{
    public class BaseMvcController : Controller
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;
        protected readonly IMapper _mapper;
        protected int recordsPerPage;
        protected int pageSize;
        protected int totalItemCount;

        #endregion

        #region Ctors


        public BaseMvcController()
        {
            InitialPagination();
        }

    

        public BaseMvcController(IMapper mapper)
        {
            _mapper = mapper;
            InitialPagination();

        }


        public BaseMvcController(IMapper mapper, IAuthenticatedUserService authenticatedUserService)
        {
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            InitialPagination();

        }


        #endregion

        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserName()
        {
            return _authenticatedUserService.GetUserName();
        }



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserId()
        {
            return _authenticatedUserService.GetUserId();
        }



        /// <summary>
        /// use this when an ajax made the command request and you want to show an alert message on the view by js
        /// </summary>
        protected JavaScriptResult AjaxResult(Result<CommandResult> cmdResult, bool reloadPage = false, string redirectUrl = "")
        {
            if (!cmdResult.IsSuccess)
                return ScriptBox.ShowMessage(GetErrorMessageFromCmdResult(cmdResult), MessageType.error);

            if (reloadPage)
                return ScriptBox.ReloadPage();


            if (!string.IsNullOrEmpty(redirectUrl))
                return ScriptBox.RedirectToUrl(url: redirectUrl.Replace("EntityId", cmdResult.Value.EntityId));

            return ScriptBox.ShowMessage(cmdResult.Message, MessageType.success);
        }



        /// <summary>
        /// use this when a http post call made the command request
        /// </summary>
        protected IActionResult View<TModel>(Result<CommandResult> result, TModel model)
        {
            //to define ViewBag messages before return view
            CreateMessageViewBags(result);

            return View(model);
        }



        /// <summary>
        /// use this when a http post call made the query request
        /// </summary>
        protected IActionResult View<TResult, TModel>(Result<TResult> result, TModel model)
        {
            //to define ViewBag messages before return view
            CreateMessageViewBags(result);

            return View(model);
        }





        /// <summary>
        /// return data to view if result is success
        /// return redirect to error page if result is failed
        /// </summary>
        protected IActionResult View<TQueryResult>(Result<TQueryResult> queryResult)
        {
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            return View(queryResult.Value);
        }




        /// <summary>
        /// return mapped data to view if result is success
        /// return redirect to error page if result is failed
        /// </summary>
        protected IActionResult View<TQueryResult, TModel>(Result<TQueryResult> queryResult)
        {
            if (!queryResult.IsSuccess)
                return RedirectToErrorPage(queryResult);

            var model = _mapper.Map<TModel>(queryResult.Value);
            return View(model);
        }


      

        /// <summary>
        /// 
        /// </summary>
        protected IActionResult RedirectToErrorPage<TQueryResult>(Result<TQueryResult> queryResult)
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
        private void CreateMessageViewBags<TResult>(Result<TResult> result)
        {
            if (result.IsSuccess)
                ViewBag.SuccessMessage = result.Message;
            else
                ViewBag.ErrorMessage = result.Message;
        }





        /// <summary>
        /// Combine message and errors in a html template
        /// </summary>
        private string GetErrorMessageFromCmdResult(Result<CommandResult> cmdResult)
        {
            return cmdResult.Message + "<br/>" + string.Join("<br/>", cmdResult.Errors.ToArray());
        }



        private void InitialPagination()
        {
            pageSize = 0;
            recordsPerPage = 15;
            totalItemCount = 0;
        }



        #endregion

    }
}