using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Controllers;

public abstract class BaseApiController : Controller
{
    #region Fields

    private readonly IAuthenticatedUserService _authenticatedUserService;
    protected readonly IRequestDispatcher _requestDispatcher;

    #endregion

    #region Ctors


    public BaseApiController(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
    {
        _authenticatedUserService = authenticatedUserService;
        _requestDispatcher = requestDispatcher;
    }

    #endregion

    #region Protected Methods




    /// <summary>
    ///
    /// </summary>
    protected string GetCurrentUserName()
    {
        return _authenticatedUserService.GetUserName();
    }

    /// <summary>
    ///
    /// </summary>
    protected string GetCurrentUserId()
    {
        return _authenticatedUserService.GetUserId();
    }

    #endregion

    #region Private Methods


    #endregion
}
