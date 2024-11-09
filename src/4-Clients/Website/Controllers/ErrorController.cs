using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Web.MVC.Models;

namespace TaskoMask.Clients.Website.Controllers;

public class ErrorController : Controller
{
    #region Fields


    #endregion

    #region Ctors

    public ErrorController() { }

    #endregion

    #region Public Methods



    /// <summary>
    ///
    /// </summary>
    public IActionResult Known(string message)
    {
        var model = new ErrorViewModel { Message = message };

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
