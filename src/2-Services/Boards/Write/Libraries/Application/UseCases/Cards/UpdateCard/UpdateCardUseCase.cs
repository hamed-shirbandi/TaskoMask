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
using TaskoMask.Services.Boards.Write.Domain.Events.Cards;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Cards.UpdateCard
{
    public class UpdateCardUseCase : BaseCommandHandler, IRequestHandler<UpdateCardRequest, CommandResult>

    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;

        #endregion

        #region Ctors


        public UpdateCardUseCase(IBoardAggregateRepository boardAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByCardIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

            var loadedVersion = board.Version;

            board.UpdateCard(request.Id, request.Name, request.Type);

            await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

            await PublishDomainEventsAsync(board.DomainEvents);

            var cardUpdated = MapToCardUpdatedIntegrationEvent(board.DomainEvents);

            await PublishIntegrationEventAsync(cardUpdated);

            return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private CardUpdated MapToCardUpdatedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var cardUpdatedDomainEvent = (CardUpdatedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(CardUpdatedEvent));
            return new CardUpdated(cardUpdatedDomainEvent.Id, cardUpdatedDomainEvent.Name, cardUpdatedDomainEvent.Type);
        }


        #endregion
    }
}
