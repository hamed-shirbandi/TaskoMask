using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Controllers;

public abstract class BaseApiController : Controller
{
    #region Fields

    private readonly ICurrentUser _currentUser;
    protected readonly IRequestDispatcher _requestDispatcher;

    #endregion

    #region Ctors


    public BaseApiController(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
    {
        _currentUser = currentUser;
        _requestDispatcher = requestDispatcher;
    }

    #endregion

    #region Protected Methods




    /// <summary>
    ///
    /// </summary>
    protected string GetCurrentUserName()
    {
        return _currentUser.GetUserName();
    }

    /// <summary>
    ///
    /// </summary>
    protected string GetCurrentUserId()
    {
        return _currentUser.GetUserId();
    }

    #endregion

    #region Private Methods


    #endregion
}
