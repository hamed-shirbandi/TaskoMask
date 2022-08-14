using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Clients.AdminPanle.Controllers
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
