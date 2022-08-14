using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Monolith.Presentation.UI.Website.Controllers
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
