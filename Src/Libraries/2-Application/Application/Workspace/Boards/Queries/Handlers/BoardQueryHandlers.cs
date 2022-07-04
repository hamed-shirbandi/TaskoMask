using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Boards.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Data;
using TaskoMask.Domain.ReadModel.Data;

namespace TaskoMask.Application.Workspace.Boards.Queries.Handlers
{
    public class BoardQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetBoardByIdQuery, BoardOutputDto>,
        IRequestHandler<GetBoardReportQuery, BoardReportDto>,
        IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<BoardBasicInfoDto>>,
        IRequestHandler<GetBoardsByOrganizationIdQuery, IEnumerable<BoardBasicInfoDto>>,
        IRequestHandler<SearchBoardsQuery, PaginatedListReturnType<BoardOutputDto>>,
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
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            //TODO refactore read model for board to decrease db queries
            var project = await _projectRepository.GetByIdAsync(board.ProjectId);
            var organization = await _organizationRepository.GetByIdAsync(project.OrganizationId);
         
            var dto= _mapper.Map<BoardOutputDto>(board);
            dto.ProjectName = project.Name;
            dto.OrganizationName = organization.Name;
            dto.CardsCount = await _cardRepository.CountByBoardIdAsync(board.Id);

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
        public async Task<IEnumerable<BoardBasicInfoDto>> Handle(GetBoardsByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByOrganizationIdAsync(request.OrganizationId);
            return _mapper.Map<IEnumerable<BoardBasicInfoDto>>(boards);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<BoardReportDto> Handle(GetBoardReportQuery request, CancellationToken cancellationToken)
        {
            //TODO Implement GetBoardReportQuery
            return new BoardReportDto();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedListReturnType<BoardOutputDto>> Handle(SearchBoardsQuery request, CancellationToken cancellationToken)
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
                item.CardsCount = await _cardRepository.CountByBoardIdAsync(item.Id);
            }

            return new PaginatedListReturnType<BoardOutputDto>
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
