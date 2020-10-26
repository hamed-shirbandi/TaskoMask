using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Collections.Generic;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;

namespace CorMon.Web.Controllers
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
            var organization = new OrganizationInput 
            { 
                Name="test name from home controller",
                Description= "test Description from home controller",
                UserId = "test UserId from home controller",
            };
            await _organizationService.CreateAsync(organization);
            return View();
        }





        #endregion

    }
}
