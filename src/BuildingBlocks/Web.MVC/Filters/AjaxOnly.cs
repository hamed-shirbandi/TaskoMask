using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using TaskoMask.Presentation.Framework.Web.Extensions;

namespace TaskoMask.Presentation.Framework.Web.Filters
{
    /// <summary>
    /// Determines whether the HttpRequest's X-Requested-With header has XMLHttpRequest value.
    /// </summary>
    public class AjaxOnly : ActionMethodSelectorAttribute
    {
        /// <summary>
        /// Determines whether the action selection is valid for the specified route context.
        /// </summary>
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}
