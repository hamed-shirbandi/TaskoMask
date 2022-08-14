using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Models;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Activities;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Handlers
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
