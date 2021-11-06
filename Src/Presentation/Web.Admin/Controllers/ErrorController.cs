using Microsoft.AspNetCore.Mvc;
using TaskoMask.Web.Common.Controllers;

namespace Web.Admin.Controllers
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
