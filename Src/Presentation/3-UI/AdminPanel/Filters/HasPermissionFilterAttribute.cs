using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Administration.Permissions.Services;
using TaskoMask.Presentation.Framework.Web.Extensions;
using TaskoMask.Presentation.Framework.Web.Helpers;

namespace TaskoMask.Presentation.UI.AdminPanle.Filters
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

            var userName = context.HttpContext.User.Identity.Name;
            var userPermissions = await _permissionService.GetSystemNameListByOperatorAsync(userName);
            if (!userPermissions.Value.Any(p => _permissions.Contains(p)))
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
