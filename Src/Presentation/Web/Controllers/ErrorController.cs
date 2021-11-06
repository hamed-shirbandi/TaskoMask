using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Web.Common.Models;

namespace TaskoMask.Web.Controllers
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
        public async Task<IActionResult> known(string message )
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
        public async Task<IActionResult> Unknown()
        {
            return View("Error");
        }



        
        #endregion

    }
}
