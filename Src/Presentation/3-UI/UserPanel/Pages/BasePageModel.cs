using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskoMask.Presentation.UI.UserPanel.Pages
{
    public abstract class BasePageModel: PageModel
    {

        /// <summary>
        /// It creats some viewData from given Result to be used in _ServerValidationSummary partial view
        /// You need to add _ServerValidationSummary in your pages (for razorpages, not for blazor)
        /// </summary>
        protected void ParseErrorsViewData(Application.Share.Helpers.IResult result)
        {
            ViewData["ErrorMessage"] = result.Message;
            ViewData["Errors"] = result.Errors;
        }
    }
}
