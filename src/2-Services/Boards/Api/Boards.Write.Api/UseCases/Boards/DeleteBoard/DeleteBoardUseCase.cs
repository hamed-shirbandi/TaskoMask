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
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Boards;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.DeleteBoard;

public class DeleteBoardUseCase : BaseCommandHandler, IRequestHandler<DeleteBoardRequest, CommandResult>
{
    #region Fields

    private readonly IBoardAggregateRepository _boardAggregateRepository;

    #endregion

    #region Ctors


    public DeleteBoardUseCase(
        IBoardAggregateRepository boardAggregateRepository,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher
    )
        : base(eventPublisher, requestDispatcher)
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

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
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
