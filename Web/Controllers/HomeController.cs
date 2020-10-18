using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Collections.Generic;

namespace CorMon.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields


        #endregion

        #region Ctor

        public HomeController()
        {

        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View();
        }


        


        #endregion

    }
}
