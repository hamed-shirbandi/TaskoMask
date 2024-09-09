using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationReportById;



[Authorize("user-read-access")]
[Tags("Organizations")]
public class GetOrganizationReportByIdRestEndpoint : BaseApiController
{
    public GetOrganizationReportByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// get organization Report 
    /// </summary>
    [HttpGet]
    [Route("organizations/report")]
    public async Task<Result<OrganizationReportDto>> Get(string organizationId)
    {
        return await _inMemoryBus.SendQuery(new GetOrganizationReportByIdRequest(organizationId));
    }
}