using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Application.Users.Services;
using TaskoMask.web.Area.Admin.Models;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Organizations.Commands.Models;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class DashboardController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;


        #endregion

        #region Ctor

        public DashboardController(IOrganizationService organizationService, IBaseApplicationService baseApplicationService):base(baseApplicationService)
        {
            _organizationService = organizationService;
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
                return RedirectToErrorPage(organizationsDetail);


            var model = new DashboardIndexViewModel
            {
                Organizations = organizationsDetail.Value,
            };
            return View(model);
        }





        #endregion

    }
}
