using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Services.Application;
using TaskoMask.Application.Share.Dtos.Workspace.Activities;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Activities.Queries.Models;

namespace TaskoMask.Application.Workspace.Activities.Services
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
