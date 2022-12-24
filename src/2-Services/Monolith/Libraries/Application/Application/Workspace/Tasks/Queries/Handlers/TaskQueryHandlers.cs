using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Handlers
{
    public class TaskQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetTaskByIdQuery, GetTaskDto>,
        IRequestHandler<GetTasksByCardIdQuery, IEnumerable<GetTaskDto>>,
        IRequestHandler<GetPendingTasksByBoardsIdQuery, IEnumerable<GetTaskDto>>,
        IRequestHandler<SearchTasksQuery, PaginatedList<GetTaskDto>>,
        IRequestHandler<GetTasksCountQuery, long>

    {

        #region Fields

        private readonly ITaskRepository _taskRepository;
        private readonly ICardRepository _cardRepository;


        #endregion

        #region Ctors

        public TaskQueryHandlers(ITaskRepository taskRepository, IMapper mapper, ICardRepository cardRepository) : base(mapper)
        {
            _taskRepository = taskRepository;
            _cardRepository = cardRepository;
        }

        #endregion

        #region Handlers




        /// <summary>
        /// 
        /// </summary>
        public async Task<GetTaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            return _mapper.Map<GetTaskDto>(task);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetTaskDto>> Handle(GetTasksByCardIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetListByCardIdAsync(request.CardId);
            return _mapper.Map<IEnumerable<GetTaskDto>>(tasks);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetTaskDto>> Handle(GetPendingTasksByBoardsIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetPendingTasksByBoardsIdAsync(request.BoardsId, request.TakeCount);
            return _mapper.Map<IEnumerable<GetTaskDto>>(tasks);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedList<GetTaskDto>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = _taskRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var tasksDto = _mapper.Map<IEnumerable<GetTaskDto>>(tasks);

            foreach (var item in tasksDto)
            {
                var card = await _cardRepository.GetByIdAsync(item.CardId);
                item.CardName = card?.Name;
            }

            return new PaginatedList<GetTaskDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = tasksDto
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetTasksCountQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.CountAsync();
        }



        #endregion
    }
}
