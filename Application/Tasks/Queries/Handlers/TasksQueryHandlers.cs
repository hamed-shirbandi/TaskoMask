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
using TaskoMask.Application.Tasks.Queries.Models;

namespace TaskoMask.Application.Tasks.Queries.Handlers
{
    public class TasksQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetTaskByIdQuery, TaskBasicInfoDto>,
        IRequestHandler<GetTasksByCardIdQuery, IEnumerable<TaskBasicInfoDto>>
    {
        private readonly ITaskRepository _taskRepository;
        public TasksQueryHandlers(ITaskRepository taskRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _taskRepository = taskRepository;
        }


        public async Task<TaskBasicInfoDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, typeof(Domain.Entities.Task));

            return _mapper.Map<TaskBasicInfoDto>(task);
        }




        public async Task<IEnumerable<TaskBasicInfoDto>> Handle(GetTasksByCardIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetListByCardIdAsync(request.CardId);
            return _mapper.Map<IEnumerable<TaskBasicInfoDto>>(tasks);
        }

      
    }
}
