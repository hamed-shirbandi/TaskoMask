using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Models;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.Queries.Handlers
{
    public class ActivityQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetActivitiesByTaskIdQuery, IEnumerable<GetTaskActivityDto>>

    {

        #region Fields

        private readonly IActivityRepository _activityRepository;


        #endregion

        #region Ctors

        public ActivityQueryHandlers(IActivityRepository activityRepository, IMapper mapper) : base(mapper)
        {
            _activityRepository = activityRepository;
        }

        #endregion

        #region Handlers




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetTaskActivityDto>> Handle(GetActivitiesByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var activities = await _activityRepository.GetListByTaskIdAsync(request.TaskId);
            return _mapper.Map<IEnumerable<GetTaskActivityDto>>(activities);
        }


        #endregion
    }
}
