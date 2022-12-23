using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Application.Queries.Models.Boards;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Handlers
{
    public class BoardQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetBoardByIdQuery, GetBoardDto>,
        IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<GetBoardDto>>,
        IRequestHandler<GetBoardsByProjectsIdQuery, IEnumerable<GetBoardDto>>,
        IRequestHandler<GetBoardsCountQuery, long>
        


    {
        #region Fields

        private readonly IBoardRepository _boardRepository;
        private readonly ICardRepository _cardRepository;

        #endregion

        #region Ctors


        public BoardQueryHandlers(IBoardRepository boardRepository , IMapper mapper, ICardRepository cardRepository) : base(mapper)
        {
            _boardRepository = boardRepository;
            _cardRepository = cardRepository;
        }


        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<GetBoardDto> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            //TODO get project and organization data from owner read service
           // var project = await _projectRepository.GetByIdAsync(board.ProjectId);
           // var organization = await _organizationRepository.GetByIdAsync(project.OrganizationId);
         
            var dto= _mapper.Map<GetBoardDto>(board);
           // dto.ProjectName = project.Name;
           // dto.OrganizationName = organization.Name;

            return dto;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetBoardDto>> Handle(GetBoardsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByProjectIdAsync(request.ProjectId);
            return _mapper.Map<IEnumerable<GetBoardDto>>(boards);
        }

        


        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetBoardDto>> Handle(GetBoardsByProjectsIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByProjectsIdAsync(request.ProjectsId);
            return _mapper.Map<IEnumerable<GetBoardDto>>(boards);
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
