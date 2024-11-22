using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Cards;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard;

public class DeleteCardUseCase : BaseCommandHandler, IRequestHandler<DeleteCardRequest, CommandResult>
{
    #region Fields

    private readonly IBoardAggregateRepository _boardAggregateRepository;

    #endregion

    #region Ctors


    public DeleteCardUseCase(IBoardAggregateRepository boardAggregateRepository, IEventPublisher eventPublisher, IRequestDispatcher requestDispatcher)
        : base(eventPublisher, requestDispatcher)
    {
        _boardAggregateRepository = boardAggregateRepository;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(DeleteCardRequest request, CancellationToken cancellationToken)
    {
        var board = await _boardAggregateRepository.GetByCardIdAsync(request.Id);
        if (board == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

        var loadedVersion = board.Version;

        board.DeleteCard(request.Id);

        await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

        await PublishDomainEventsAsync(board.DomainEvents);

        var cardDeleted = MapToCardDeletedIntegrationEvent(board.DomainEvents);

        await PublishIntegrationEventAsync(cardDeleted);

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
    }

    #endregion

    #region Private Methods


    private CardDeleted MapToCardDeletedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var cardDeletedDomainEvent = (CardDeletedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(CardDeletedEvent));
        return new CardDeleted(cardDeletedDomainEvent.Id);
    }

    #endregion
}
