using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskoMask.Services.Monolith.Application.Membership.Permissions.Services;
using TaskoMask.Services.Monolith.Domain.Core.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Extensions;
using TaskoMask.BuildingBlocks.Web.MVC.Helpers;

namespace TaskoMask.Services.Monolith.Presentation.UI.AdminPanle.Filters
{
    public class HasPermission : Attribute, IAsyncActionFilter
    {
        private readonly string[] _permissions;

        public HasPermission(string permission)
        {
            _permissions = permission.Split(',');
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _permissionService = context.HttpContext.RequestServices.GetService<IPermissionService>();
            var _authenticatedUserService = context.HttpContext.RequestServices.GetService<IAuthenticatedUserService>();

            var operatorId = _authenticatedUserService.GetUserId();
            var operatorPermissions = await _permissionService.GetSystemNameListByOperatorAsync(operatorId);
            if (!operatorPermissions.Value.Any(p => _permissions.Contains(p)))
            {
                RedirectToNotFoundPage(context);
                return;
            }

            await next();
        }





        private void RedirectToNotFoundPage(ActionExecutingContext context)
        {
            string message = "not found error";
            if (context.HttpContext.Request.IsAjaxRequest())
                context.Result = new JavaScriptResult($"window.location ='/admin/errors/known?message={message}'");

            else
                context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary
                     {
                             {"Area",""},
                             { "controller", "errors" },
                             { "action", "known" },
                             { "message", message },

                     });

        }

    }
}
