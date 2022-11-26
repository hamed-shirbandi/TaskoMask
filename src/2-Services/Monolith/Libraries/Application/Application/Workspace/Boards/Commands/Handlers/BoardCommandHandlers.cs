using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.BuildingBlocks.Domain.Resources;

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


        public BoardCommandHandlers(IBoardAggregateRepository boardAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus, IBoardValidatorService boardValidatorService) : base(messageBus,inMemoryBus)
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

            await _boardAggregateRepository.AddAsync(board);
            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, board.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            var loadedVersion = board.Version;

            board.UpdateBoard(request.Name, request.Description, _boardValidatorService);

            await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, board.Id);

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            board.DeleteBoard();

            await _boardAggregateRepository.DeleteAsync(board.Id);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, board.Id);

        }

        #endregion

    }
}
