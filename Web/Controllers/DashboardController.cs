using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly UserManager<User> _userManager;

        #endregion

        #region Ctor

        public DashboardController(IOrganizationService organizationService, UserManager<User> userManager)
        {
            _organizationService = organizationService;
            _userManager = userManager;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            var model = new DashboardIndexViewModel
            {
                Organizations = await _organizationService.GetListByUserIdAsync(userId),
                User =await _userManager.FindByIdAsync(userId),
            };
            return View(model);
        }





        #endregion

    }
}
