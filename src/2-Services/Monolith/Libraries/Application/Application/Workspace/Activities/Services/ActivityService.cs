using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Services
{
    public class ActivityService : ApplicationService, IActivityService
    {
        #region Fields


        #endregion

        #region Ctors

        public ActivityService(IInMemoryBus inMemoryBus) : base(inMemoryBus)
        { }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<GetTaskActivityDto>>> GetListByTaskIdAsync(string taskId)
        {
            return await _inMemoryBus.SendQuery(new GetActivitiesByTaskIdQuery(taskId));
        }




        #endregion
    }
}
