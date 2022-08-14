using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace TaskoMask.BuildingBlocks.Web.MVC.Extensions
{
    public static class MvcExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<SelectListItem> ToMvcSelectList(this TaskoMask.Services.Monolith.Application.Share.Helpers.SelectListItem[] selectListItem)
        {
            var mvcSelectListItem = new List<SelectListItem>();
            foreach (var item in selectListItem)
            {
                mvcSelectListItem.Add(new SelectListItem
                {
                    Selected=item.Selected,
                    Text=item.Text,
                    Value=item.Value
                });
            }

            return mvcSelectListItem;
        }





        /// <summary>
        /// 
        /// </summary>
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            var getError = string.Empty;
            foreach (var value in modelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    getError += error.ErrorMessage + "<br />";
                }
            }
            return getError;
        }



        /// <summary>
        /// Determines whether the HttpRequest's X-Requested-With header has XMLHttpRequest value.
        /// </summary>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request?.Headers != null && request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

    }
}
