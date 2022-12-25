using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Domain.Data;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard
{
    public class DeleteBoardUseCase : BaseCommandHandler, IRequestHandler<DeleteBoardRequest, CommandResult>

    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;

        #endregion

        #region Ctors


        public DeleteBoardUseCase(IBoardAggregateRepository boardAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteBoardRequest request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            board.DeleteBoard();

            await _boardAggregateRepository.DeleteAsync(board.Id);

            await PublishDomainEventsAsync(board.DomainEvents);

            var boardDeleted = MapToBoardDeletedIntegrationEvent(board.DomainEvents);

            await PublishIntegrationEventAsync(boardDeleted);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private BoardDeleted MapToBoardDeletedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var boardDeletedDomainEvent = (BoardDeletedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(BoardDeletedEvent));
            return new BoardDeleted(boardDeletedDomainEvent.Id);
        }


        #endregion

    }
}
