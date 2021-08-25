using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Web.Area.Admin.Models;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class DashboardController : BaseMvcController
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
            var asdas = await _organizationService.CreateAsync(new Application.Core.Dtos.Organizations.OrganizationInputDto
            {
                Description="1",
                Name="1",
                UserId="",
            });

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
