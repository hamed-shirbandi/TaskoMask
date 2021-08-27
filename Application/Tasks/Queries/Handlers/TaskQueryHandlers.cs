using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Tasks.Queries.Models;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Entities;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Tasks.Queries.Handlers
{
    public class TaskQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetTaskByIdQuery, TaskBasicInfoDto>,
        IRequestHandler<GetTasksByCardIdQuery, IEnumerable<TaskBasicInfoDto>>,
        IRequestHandler<GetTasksByOrganizationIdQuery, IEnumerable<TaskBasicInfoDto>>
        
    {
        private readonly ITaskRepository _taskRepository;
        public TaskQueryHandlers(ITaskRepository taskRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _taskRepository = taskRepository;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<TaskBasicInfoDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            return _mapper.Map<TaskBasicInfoDto>(task);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<TaskBasicInfoDto>> Handle(GetTasksByCardIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetListByCardIdAsync(request.CardId);
            return _mapper.Map<IEnumerable<TaskBasicInfoDto>>(tasks);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<TaskBasicInfoDto>> Handle(GetTasksByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetListByOrganizationIdAsync(request.OrganizationId,request.TakeCount);
            return _mapper.Map<IEnumerable<TaskBasicInfoDto>>(tasks);
        }

    }
}
