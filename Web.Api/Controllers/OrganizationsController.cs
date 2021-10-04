using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Organizations.Services;
using TaskoMask.Application.Core.Dtos.Organizations;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrganizationsController : BaseApiController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctors

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get organization detail
        /// </summary>
        [HttpGet]
        [Route("organizations/{id}")]
        public async Task<Result<OrganizationDetailsViewModel>> Get(string id)
        {
            return await _organizationService.GetDetailsAsync(id);
        }



        /// <summary>
        /// create new organization
        /// </summary>
        [HttpPost]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Create(OrganizationInputDto input)
        {
            return await _organizationService.CreateAsync(input);
        }



        /// <summary>
        /// update existing organization
        /// </summary>
        [HttpPut]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Update(OrganizationInputDto input)
        {
            return await _organizationService.UpdateAsync(input);
        }



        #endregion

    }
}
