using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services;

public class CurrentUser : ICurrentUser
{
    #region Fields

    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion

    #region Ctors

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion

    #region Public Methods



    /// <summary>
    ///
    /// </summary>
    public string GetUserId()
    {
        var user = _httpContextAccessor.HttpContext.User;
        if (user == null)
            return "";
        return user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
    }

    /// <summary>
    ///
    /// </summary>
    public string GetUserName()
    {
        var user = _httpContextAccessor.HttpContext.User;
        if (user == null)
            return "";
        return user.FindFirstValue(ClaimTypes.Name) ?? "";
    }

    /// <summary>
    ///
    /// </summary>
    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    #endregion

    #region Private Methods



    #endregion
}
