using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;

namespace TaskoMask.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctor

        public HomeController(IOrganizationService organizationService)
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
            var model = new HomeIndexViewModel
            {
                OrganizationsCount = await _organizationService.CountAsync(),
                ProjectsCount = 0,
                BoardsCount = 0,
                TasksCount = 0,
            };

            return View(model);
        }





        #endregion

    }
}
