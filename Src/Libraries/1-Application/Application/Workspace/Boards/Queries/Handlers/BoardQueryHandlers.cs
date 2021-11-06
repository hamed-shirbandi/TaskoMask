using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Boards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Workspace.Data;

namespace TaskoMask.Application.Workspace.Boards.Queries.Handlers
{
    public class BoardQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetBoardByIdQuery, BoardBasicInfoDto>,
        IRequestHandler<GetBoardReportQuery, BoardReportDto>,
        IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<BoardBasicInfoDto>>,
        IRequestHandler<GetBoardsByOrganizationIdQuery, IEnumerable<BoardBasicInfoDto>>
        
    {
        #region Fields

        private readonly IBoardRepository _boardRepository;

        #endregion

        #region Ctors


        public BoardQueryHandlers(IBoardRepository boardRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _boardRepository = boardRepository;
        }


        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<BoardBasicInfoDto> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            return _mapper.Map<BoardBasicInfoDto>(board);
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
        public Task<BoardReportDto> Handle(GetBoardReportQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }



        #endregion

    }
}
