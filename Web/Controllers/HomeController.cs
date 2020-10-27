using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Collections.Generic;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;

namespace CorMon.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IEventStore _eventStore;

        #endregion

        #region Ctor

        public HomeController(IEventStore eventStore, IOrganizationService organizationService)
        {
            _organizationService = organizationService;
            _eventStore = eventStore;
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
                Name = "test name from home controller",
                Description = "test Description from home controller",
                UserId = "test UserId from home controller",
            };
            await _organizationService.CreateAsync(organization);


            var theEvent = new StoredEvent("testid000asda55555asd5555", "test type", "test user", "test request json", "test response json");
            await _eventStore.SaveAsync(theEvent);
            var data = await _eventStore.GetListAsync<StoredEvent>(theEvent.Id);
           
            return View();
        }





        #endregion

    }
}
