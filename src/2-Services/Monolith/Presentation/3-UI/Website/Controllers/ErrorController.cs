using Microsoft.AspNetCore.Mvc;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Presentation.Framework.Web.Models;

namespace TaskoMask.Presentation.UI.Website.Controllers
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
