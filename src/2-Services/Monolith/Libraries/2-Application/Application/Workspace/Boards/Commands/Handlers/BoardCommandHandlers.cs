using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Handlers
{
    public class BoardCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>,
        IRequestHandler<DeleteBoardCommand, CommandResult>
    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;
        private readonly IBoardValidatorService _boardValidatorService;

        #endregion

        #region Ctors


        public BoardCommandHandlers(IBoardAggregateRepository boardAggregateRepository, IInMemoryBus inMemoryBus, IBoardValidatorService boardValidatorService) : base(inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
            _boardValidatorService = boardValidatorService;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var board = Board.AddBoard(request.Name, request.Description, request.ProjectId, _boardValidatorService);

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

            board.DeleteBoard();

            await _boardAggregateRepository.DeleteAsync(board.Id);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }

        #endregion

    }
}
