using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Application.Workspace.Boards.Commands.Handlers
{
    public class BoardCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>
    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;

        #endregion

        #region Ctors


        public BoardCommandHandlers(IBoardAggregateRepository boardAggregateRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = Board.CreateBoard(name: request.Name, description: request.Description, projectId: request.ProjectId);

            await _boardAggregateRepository.CreateAsync(board);
            return new CommandResult(ApplicationMessages.Create_Success, board.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);
           
            board.UpdateBoard(request.Name, request.Description);

            await _boardAggregateRepository.UpdateAsync(board);
            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }


        #endregion

    }
}
