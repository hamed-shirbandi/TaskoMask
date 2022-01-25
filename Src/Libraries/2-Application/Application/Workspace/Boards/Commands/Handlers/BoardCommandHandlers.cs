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
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;

namespace TaskoMask.Application.Workspace.Boards.Commands.Handlers
{
    public class BoardCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>,
        IRequestHandler<DeleteBoardCommand, CommandResult>
    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;
        private readonly IBoardValidatorService _boardValidatorService;

        #endregion

        #region Ctors


        public BoardCommandHandlers(IBoardAggregateRepository boardAggregateRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus, IBoardValidatorService boardValidatorService) : base(notifications, inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
            _boardValidatorService = boardValidatorService;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = Board.CreateBoard(request.Name, request.Description, request.ProjectId, _boardValidatorService);

            await _boardAggregateRepository.CreateAsync(board);
            await PublishDomainEventsAsync(board.DomainEvents);

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

            var loadedVersion = board.Version;

            board.UpdateBoard(request.Name, request.Description, _boardValidatorService);

            await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            var loadedVersion = board.Version;

            board.DeleteBoard();

            await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }

        #endregion

    }
}
