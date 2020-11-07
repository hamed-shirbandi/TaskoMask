using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace TaskoMask.Web.Controllers
{
    public class ErrorController : BaseController
    {
        #region Fields


        #endregion

        #region Ctor

        public ErrorController()
        {
        }


        #endregion

        #region Public Methods




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
