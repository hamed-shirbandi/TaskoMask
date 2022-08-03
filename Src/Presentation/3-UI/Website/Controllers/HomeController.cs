using Microsoft.AspNetCore.Mvc;
using TaskoMask.Presentation.Framework.Web.Controllers;

namespace TaskoMask.Presentation.UI.Website.Controllers
{
    public class HomeController : BaseMvcController
    {
        #region Fields


        #endregion

        #region Ctors

        public HomeController()
        {

        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }





        #endregion

    }
}
