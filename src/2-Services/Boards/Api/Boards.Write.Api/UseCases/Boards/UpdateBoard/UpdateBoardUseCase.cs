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
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.UpdateBoard;

public class UpdateBoardUseCase : BaseCommandHandler, IRequestHandler<UpdateBoardRequest, CommandResult>
{
    #region Fields

    private readonly IBoardAggregateRepository _boardAggregateRepository;
    private readonly IBoardValidatorService _boardValidatorService;

    #endregion

    #region Ctors


    public UpdateBoardUseCase(
        IBoardAggregateRepository boardAggregateRepository,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher,
        IBoardValidatorService boardValidatorService
    )
        : base(eventPublisher, requestDispatcher)
    {
        _boardAggregateRepository = boardAggregateRepository;
        _boardValidatorService = boardValidatorService;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(UpdateBoardRequest request, CancellationToken cancellationToken)
    {
        var board = await _boardAggregateRepository.GetByIdAsync(request.Id);
        if (board == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

        var loadedVersion = board.Version;

        board.UpdateBoard(request.Name, request.Description, _boardValidatorService);

        await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

        await PublishDomainEventsAsync(board.DomainEvents);

        var boardUpdated = MapToBoardUpdatedIntegrationEvent(board.DomainEvents);

        await PublishIntegrationEventAsync(boardUpdated);

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
    }

    #endregion

    #region Private Methods


    private BoardUpdated MapToBoardUpdatedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var boardUpdatedDomainEvent = (BoardUpdatedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(BoardUpdatedEvent));
        return new BoardUpdated(boardUpdatedDomainEvent.Id, boardUpdatedDomainEvent.Name, boardUpdatedDomainEvent.Description);
    }

    #endregion
}
