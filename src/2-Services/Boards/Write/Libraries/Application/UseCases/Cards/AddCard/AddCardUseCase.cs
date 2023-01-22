using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Domain.Data;
using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Events.Cards;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Cards.AddCard
{
    public class AddCardUseCase : BaseCommandHandler, IRequestHandler<AddCardRequest, CommandResult>

    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;

        #endregion

        #region Ctors


        public AddCardUseCase(IBoardAggregateRepository boardAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddCardRequest request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.BoardId);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            var card = Card.Create(name: request.Name, type: request.Type);
            board.AddCard(card);

            await _boardAggregateRepository.UpdateAsync(board);

            await PublishDomainEventsAsync(board.DomainEvents);

            var cardAdded = MapToCardAddedIntegrationEvent(board.DomainEvents);

            await PublishIntegrationEventAsync(cardAdded);

            return CommandResult.Create(ContractsMessages.Create_Success, card.Id);
        }


        #endregion

        #region Private Methods


        private CardAdded MapToCardAddedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var cardAddedDomainEvent = (CardAddedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(CardAddedEvent));
           
            return new CardAdded(cardAddedDomainEvent.Id, cardAddedDomainEvent.Name, cardAddedDomainEvent.Type, cardAddedDomainEvent.BoardId);
        }


        #endregion

    }
}
