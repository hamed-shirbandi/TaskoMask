using Microsoft.AspNetCore.Mvc;

namespace TaskoMask.Clients.Website.Controllers;

public class HomeController : Controller
{
    #region Fields


    #endregion

    #region Ctors

    public HomeController() { }

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
