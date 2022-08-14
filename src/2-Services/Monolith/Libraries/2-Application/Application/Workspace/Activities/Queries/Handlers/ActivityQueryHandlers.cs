using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Activities.Queries.Models;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Application.Share.Dtos.Workspace.Activities;

namespace TaskoMask.Application.Workspace.Activities.Queries.Handlers
{
    public class ActivityQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetActivitiesByTaskIdQuery, IEnumerable<ActivityBasicInfoDto>>

    {

        #region Fields

        private readonly IActivityRepository _activityRepository;


        #endregion

        #region Ctors

        public ActivityQueryHandlers(IActivityRepository activityRepository,IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _activityRepository = activityRepository;
        }

        #endregion

        #region Handlers




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<ActivityBasicInfoDto>> Handle(GetActivitiesByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var activities = await _activityRepository.GetListByTaskIdAsync(request.TaskId);
            return _mapper.Map<IEnumerable<ActivityBasicInfoDto>>(activities);
        }


        #endregion
    }
}
