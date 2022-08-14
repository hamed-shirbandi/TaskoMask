using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Application.Queries.Models.Boards;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Handlers
{
    public class BoardQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetBoardByIdQuery, BoardOutputDto>,
        IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<BoardBasicInfoDto>>,
        IRequestHandler<GetBoardsByProjectsIdQuery, IEnumerable<BoardBasicInfoDto>>,
        IRequestHandler<SearchBoardsQuery, PaginatedList<BoardOutputDto>>,
        IRequestHandler<GetBoardsCountQuery, long>
        


    {
        #region Fields

        private readonly IBoardRepository _boardRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctors


        public BoardQueryHandlers(IBoardRepository boardRepository, IDomainNotificationHandler notifications, IMapper mapper, IProjectRepository projectRepository, ICardRepository cardRepository, IOrganizationRepository organizationRepository) : base(mapper, notifications)
        {
            _boardRepository = boardRepository;
            _projectRepository = projectRepository;
            _cardRepository = cardRepository;
            _organizationRepository = organizationRepository;
        }


        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<BoardOutputDto> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            //TODO refactore read model for board to decrease db queries
            var project = await _projectRepository.GetByIdAsync(board.ProjectId);
            var organization = await _organizationRepository.GetByIdAsync(project.OrganizationId);
         
            var dto= _mapper.Map<BoardOutputDto>(board);
            dto.ProjectName = project.Name;
            dto.OrganizationName = organization.Name;

            return dto;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<BoardBasicInfoDto>> Handle(GetBoardsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByProjectIdAsync(request.ProjectId);
            return _mapper.Map<IEnumerable<BoardBasicInfoDto>>(boards);
        }

        


        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<BoardBasicInfoDto>> Handle(GetBoardsByProjectsIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByProjectsIdAsync(request.ProjectsId);
            return _mapper.Map<IEnumerable<BoardBasicInfoDto>>(boards);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedList<BoardOutputDto>> Handle(SearchBoardsQuery request, CancellationToken cancellationToken)
        {
            var boards = _boardRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var boardsDto = _mapper.Map<IEnumerable<BoardOutputDto>>(boards);

            foreach (var item in boardsDto)
            {
                //TODO refactore read model for board to decrease db queries
                var project = await _projectRepository.GetByIdAsync(item.ProjectId);
                var organization = await _organizationRepository.GetByIdAsync(project.OrganizationId);
                item.ProjectName = project.Name;
                item.OrganizationName = organization.Name;
            }

            return new PaginatedList<BoardOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = boardsDto
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetBoardsCountQuery request, CancellationToken cancellationToken)
        {
            return await _boardRepository.CountAsync();
        }



        #endregion

    }
}
