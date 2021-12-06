using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Tasks.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;

using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Exceptions;

using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Workspace.Data;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Workspace.Tasks.Queries.Handlers
{
    public class TaskQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetTaskByIdQuery, TaskBasicInfoDto>,
        IRequestHandler<GetTasksByCardIdQuery, IEnumerable<TaskBasicInfoDto>>,
        IRequestHandler<GetTasksByOrganizationIdQuery, IEnumerable<TaskBasicInfoDto>>,
        IRequestHandler<SearchTasksQuery, PaginatedListReturnType<TaskOutputDto>>


    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICardRepository _cardRepository;


        public TaskQueryHandlers(ITaskRepository taskRepository, IDomainNotificationHandler notifications, IMapper mapper, ICardRepository cardRepository) : base(mapper, notifications)
        {
            _taskRepository = taskRepository;
            _cardRepository = cardRepository;
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




        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedListReturnType<TaskOutputDto>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = _taskRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var tasksDto = _mapper.Map<IEnumerable<TaskOutputDto>>(tasks);

            foreach (var item in tasksDto)
            {
                var card = await _cardRepository.GetByIdAsync(item.CardId);
                item.CardName = card?.Name;
            }

            return new PaginatedListReturnType<TaskOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = tasksDto
            };
        }
    }
}
