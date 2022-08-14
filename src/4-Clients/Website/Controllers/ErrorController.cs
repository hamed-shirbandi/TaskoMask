using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Presentation.Framework.Web.Controllers;
using TaskoMask.Services.Monolith.Presentation.Framework.Web.Models;

namespace TaskoMask.Services.Monolith.Presentation.UI.Website.Controllers
{
    public class ErrorController : BaseMvcController
    {
        #region Fields


        #endregion

        #region Ctors

        public ErrorController()
        {
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public IActionResult Known(string message )
        {
            var model = new ErrorViewModel
            {
                Message = message,
            };

            return View("KnownError", model);
        }




        /// <summary>
        /// 
        /// </summary>
        public IActionResult Unknown()
        {
            return View("Error");
        }



        
        #endregion

    }
}
