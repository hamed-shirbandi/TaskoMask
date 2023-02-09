using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId
{

    [Authorize("user-read-access")]
    [Tags("Activities")]
    public class GetActivitiesByTaskIdRestEndpoint : BaseApiController
    {
        public GetActivitiesByTaskIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get activities for a task
        /// </summary>
        [HttpGet]
        [Route("tasks/{taskId}/activities")]
        public async Task<Result<IEnumerable<GetActivityDto>>> Get(string taskId)
        {
            return await _inMemoryBus.SendQuery(new GetActivitiesByTaskIdRequest(taskId));
        }
    }

}