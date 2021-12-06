using Microsoft.AspNetCore.Mvc;
using TaskoMask.Presentation.Framework.Web.Controllers;

namespace TaskoMask.Presentation.UI.AdminPanle.Controllers
{
    public class ErrorController : BaseMvcController
    {
        #region Fields


        #endregion

        #region Ctor

        public ErrorController( )
        {
           
        }


        #endregion

        #region Public Methods




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
