using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.web.Area.Admin.Models;
using AutoMapper;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class DashboardController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;


        #endregion

        #region Ctors

        public DashboardController(IOrganizationService organizationService, IMapper mapper) : base(mapper)
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
            var organizationsDetailQueryResult = await _organizationService.GetUserOrganizationsDetailAsync(GetCurrentUserId());
            if (!organizationsDetailQueryResult.IsSuccess)
                return RedirectToErrorPage(organizationsDetailQueryResult);

            var model = new DashboardIndexViewModel
            {
                Organizations = organizationsDetailQueryResult.Value,
            };
            return View(model);
        }





        #endregion

    }
}
