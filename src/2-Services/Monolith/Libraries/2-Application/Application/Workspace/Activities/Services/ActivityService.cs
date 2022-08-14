using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Activities;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Services
{
    public class ActivityService : ApplicationService, IActivityService
    {
        #region Fields


        #endregion

        #region Ctors

        public ActivityService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<ActivityBasicInfoDto>>> GetListByTaskIdAsync(string taskId)
        {
            return await SendQueryAsync(new GetActivitiesByTaskIdQuery(taskId));
        }




        #endregion
    }
}
