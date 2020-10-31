using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;

namespace CorMon.Web.Controllers
{
    public class OrganizationsController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctor

        public OrganizationsController(IOrganizationService organizationService)
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
            var userid = "5f960ffd65702c25e513159c";
            var organizations = await _organizationService.GetListByUserIdAsync(userid);
            return View(organizations);
        }





        #endregion

    }
}
