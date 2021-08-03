using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Application.Users.Services;
using TaskoMask.web.Area.Admin.Models;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class DashboardController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public DashboardController(IOrganizationService organizationService, IUserService userService)
        {
            _organizationService = organizationService;
            _userService = userService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var organizationsDetail = await _organizationService.GetUserOrganizationsDetailAsync(GetCurrentUserId());
            if (!organizationsDetail.IsSuccess)
                //TODO redirect to custom error page
                throw new System.Exception(organizationsDetail.Message);

            var model = new DashboardIndexViewModel
            {
                Organizations= organizationsDetail.Value,
            };
            return View(model);
        }





        #endregion

    }
}
